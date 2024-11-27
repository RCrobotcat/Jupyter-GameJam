using UnityEngine;
using UnityEngine.UI;

public class LogNameBtn : MonoBehaviour
{
    public Text logNameTxt;
    public LogData_SO currentLogData;
    public Text LogContentTxt;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(UpdateLogContent);
    }

    void UpdateLogContent()
    {
        LogContentTxt.text = currentLogData.content;
    }

    public void SetUpNameBtn(LogData_SO logData)
    {
        currentLogData = logData;
        logNameTxt.text = logData.LogName;
    }
}