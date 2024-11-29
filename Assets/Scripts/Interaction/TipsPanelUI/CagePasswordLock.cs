using UnityEngine;
using UnityEngine.UI;

public class CagePasswordLock : Singleton<CagePasswordLock>
{
    public GameObject TipsPanel;
    public Text tipsText;

    public GameObject PasswordLockPanel;

    [HideInInspector] public bool isPasswordLockPanelActive = false;
    public bool unlocked = false; // 笼子是否已经被解锁

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
            tipsText.text = "笼子的锁已经打开了, 看起来还要帮小猫解开毛线团。";
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
