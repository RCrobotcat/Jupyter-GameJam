using UnityEngine;
using UnityEngine.UI;

public class LogWindow : MonoBehaviour
{
    public string PassWord;

    public Button viewBtn;
    public InputField passwordInput;
    public GameObject contentsPanel;

    public LogData_SO logGiven;

    void Awake()
    {
        if (viewBtn != null)
            viewBtn.onClick.AddListener(ViewDiaryContents);

        if (logGiven != null)
        {
            LogManager.Instance.AddLogData(logGiven);
        }
    }

    void ViewDiaryContents()
    {
        if (passwordInput.text == PassWord)
        {
            contentsPanel.SetActive(true);
        }
    }
}
