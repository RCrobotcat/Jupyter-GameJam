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
        StartCoroutine(timer_resetTips(1.5f)); // 1.5���ر���ʾ
    }

    public void Window()
    {
        // ȷ�����ڻ�ģʽ��Ч
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
    }

    public void FullScreen()
    {
        // ��ȡ���зֱ��ʲ�����Ϊȫ������߷ֱ���
        Resolution[] resolutions = Screen.resolutions;
        Resolution highestResolution = resolutions[resolutions.Length - 1];

        Screen.SetResolution(highestResolution.width, highestResolution.height, true);
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen; // ȷ���Ƕ�ռȫ��ģʽ
    }

    IEnumerator timer_resetTips(float time)
    {
        yield return new WaitForSeconds(time);
        successSetTips.SetActive(false);
    }
}
