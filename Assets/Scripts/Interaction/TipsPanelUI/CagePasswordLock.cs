using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CagePasswordLock : Singleton<CagePasswordLock>
{
    public GameObject TipsPanel;
    public Text tipsText;

    public GameObject PasswordLockPanel;

    [HideInInspector] public bool isPasswordLockPanelActive = false;
    public bool unlocked = false; // �����Ƿ��Ѿ�������

    public LogData_SO saveCatLog;
    public GameObject cat; // Сè

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

    // Quit Button Event
    public void SaveCat()
    {
        DesktopManager.Instance.isWindowOpen = false;
        if (UntangleController.Instance.win)
        {
            tipsText.color = Color.green;
            tipsText.text = "Сè���ɹ�����ˣ�Сè�ɿ�������ˣ����ڵ���������һЩ������צӡ��";
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
