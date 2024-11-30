using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public SceneFader sceneFaderPrefab;

    public LogList_SO logList;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 传送到特定场景
    /// </summary>
    /// <param name="SceneName">要传送到的场景名字</param>
    public void TransitionToSceneHandler(string SceneName)
    {
        StartCoroutine(TransitionToScene(SceneName));
    }
    IEnumerator TransitionToScene(string SceneName)
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(1.5f));
        yield return SceneManager.LoadSceneAsync(SceneName);
        yield return StartCoroutine(fade.FadeIn(1.5f));
        yield break;

    }

    public void StartGame()
    {
        logList.logDatas.Clear();
        StartCoroutine(LoadMainRoomScene());
    }
    IEnumerator LoadMainRoomScene()
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(1.5f));
        yield return SceneManager.LoadSceneAsync("Reality_Room_main");
        yield return StartCoroutine(fade.FadeIn(1.5f));
        yield break;
    }

    public void ReturnToMainMenu()
    {
        logList.logDatas.Clear();
        StartCoroutine(LoadMainMenu());
    }
    IEnumerator LoadMainMenu()
    {
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(1.5f));
        yield return SceneManager.LoadSceneAsync("MainMenu");
        yield return StartCoroutine(fade.FadeIn(1.5f));
        yield break;
    }
}