using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public InputField usernameInput;

    public Button windowBtn;
    public Button fullscreenBtn;
    public Button setBtn;

    public Button returnToMainBtn;

    public GameObject successSetTips;

    void Awake()
    {
        windowBtn.onClick.AddListener(Window);
        fullscreenBtn.onClick.AddListener(FullScreen);

        setBtn.onClick.AddListener(SuccessSet);

        if (returnToMainBtn != null)
        {
            returnToMainBtn.onClick.AddListener(ReturnToMainMenu);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneController.Instance.ReturnToMainMenu();
    }

    public void SuccessSet()
    {
        GameManager.Instance.currentUserName = usernameInput.text;
        Debug.Log($"Current User Name: {GameManager.Instance.currentUserName}");

        successSetTips.SetActive(true);
        StartCoroutine(timer_resetTips(1.5f)); // 1.5秒后关闭提示
    }

    public void Window()
    {
        // 确保窗口化模式生效
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
    }

    public void FullScreen()
    {
        // 获取所有分辨率并设置为全屏的最高分辨率
        Resolution[] resolutions = Screen.resolutions;
        Resolution highestResolution = resolutions[resolutions.Length - 1];

        Screen.SetResolution(highestResolution.width, highestResolution.height, true);
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen; // 确保是独占全屏模式
    }

    IEnumerator timer_resetTips(float time)
    {
        yield return new WaitForSeconds(time);
        successSetTips.SetActive(false);
    }
}
