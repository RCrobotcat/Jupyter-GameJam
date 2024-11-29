using UnityEngine;
using UnityEngine.UI;

public class LogWindow : MonoBehaviour
{
    public string PassWord;

    public Button viewBtn;
    public InputField passwordInput;
    public GameObject contentsPanel;

    void Awake()
    {
        viewBtn.onClick.AddListener(ViewDiaryContents);
    }

    void ViewDiaryContents()
    {
        if (passwordInput.text == PassWord)
        {
            contentsPanel.SetActive(true);
        }
    }
}
