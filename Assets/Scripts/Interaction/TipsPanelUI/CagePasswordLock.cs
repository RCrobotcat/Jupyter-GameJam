using UnityEngine;
using UnityEngine.UI;

public class CagePasswordLock : Singleton<CagePasswordLock>
{
    public GameObject TipsPanel;
    public Text tipsText;

    public GameObject PasswordLockPanel;

    [HideInInspector] public bool isPasswordLockPanelActive = false;
    public bool unlocked = false; // �����Ƿ��Ѿ�������

    public InputField passwordInput;
    public Button unlockBtn;

    protected override void Awake()
    {
        base.Awake();
        unlockBtn.onClick.AddListener(UnlockCage);
    }

    void UnlockCage()
    {
        if (passwordInput.text == "03121996")
        {
            unlocked = true;
            ClosePasswordLockPanel();
            tipsText.color = Color.green;
            tipsText.text = "���ӵ����Ѿ�����, ��������Ҫ��Сè�⿪ë���š�";
            TipsPanel.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    public void OpenPasswordLockPanel()
    {
        isPasswordLockPanelActive = true;
        TipsPanel.SetActive(false);
        PasswordLockPanel.SetActive(true);
    }

    public void ClosePasswordLockPanel()
    {
        PasswordLockPanel.GetComponent<Animator>().SetTrigger("Close");
        isPasswordLockPanelActive = false;
    }
}
