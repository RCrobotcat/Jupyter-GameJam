using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button startBtn;
    public Button settingBtn;
    public Button quitBtn;

    public GameObject settingPanel;

    void Awake()
    {
        SetBtnsNotHover();
        startBtn.onClick.AddListener(StartGame);
        settingBtn.onClick.AddListener(OpenSetting);
        quitBtn.onClick.AddListener(QuitGame);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject go = eventData.pointerEnter;
        // Button Hover
        switch (go.name)
        {
            case "StartBtn":
                Color color_start = startBtn.GetComponent<Image>().color;
                color_start.a = 0.8f;
                startBtn.GetComponent<Image>().color = color_start;
                break;
            case "SettingBtn":
                Color color_setting = settingBtn.GetComponent<Image>().color;
                color_setting.a = 0.8f;
                settingBtn.GetComponent<Image>().color = color_setting;
                break;
            case "QuitBtn":
                Color color_quit = quitBtn.GetComponent<Image>().color;
                color_quit.a = 0.8f;
                quitBtn.GetComponent<Image>().color = color_quit;
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetBtnsNotHover();
    }

    #region Button Click Events
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneController.Instance.StartGame();
    }

    public void OpenSetting()
    {
        Debug.Log("Open Setting");
        settingPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    #endregion

    // 把所有按钮都设置为非激活状态
    void SetBtnsNotHover()
    {
        Color color_start = startBtn.GetComponent<Image>().color;
        color_start.a = 0;
        startBtn.GetComponent<Image>().color = color_start;

        Color color_setting = settingBtn.GetComponent<Image>().color;
        color_setting.a = 0;
        settingBtn.GetComponent<Image>().color = color_setting;

        Color color_quit = quitBtn.GetComponent<Image>().color;
        color_quit.a = 0;
        quitBtn.GetComponent<Image>().color = color_quit;
    }
}
