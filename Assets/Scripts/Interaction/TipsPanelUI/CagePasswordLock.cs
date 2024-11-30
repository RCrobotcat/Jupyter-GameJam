using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CagePasswordLock : Singleton<CagePasswordLock>
{
    public GameObject TipsPanel;
    public Text tipsText;

    public GameObject PasswordLockPanel;

    [HideInInspector] public bool isPasswordLockPanelActive = false;
    public bool unlocked = false; // 笼子是否已经被解锁

    public LogData_SO saveCatLog;
    public GameObject cat; // 小猫

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

    // Quit Button Event
    public void SaveCat()
    {
        DesktopManager.Instance.isWindowOpen = false;
        if (UntangleController.Instance.win)
        {
            tipsText.color = Color.green;
            tipsText.text = "小猫被成功解救了！小猫飞快地溜走了，并在地上留下了一些东西和爪印。";
            LogManager.Instance.AddLogData(saveCatLog);

            cat.transform.DOScale(Vector3.zero, 0.3f);
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
