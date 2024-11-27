using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AnwserTypes
{
    userName,
    Anwser_1,
    Anwser_2,
    Anwser_3
}
public class LogManager : Singleton<LogManager>
{
    // �����־�����б�
    public LogList_SO logList;

    public GameObject logPanel;
    public Animator logPanelAnimator;
    [HideInInspector] public bool isOpen = false;
    [HideInInspector] public bool isAnimating = false;

    [Header("Log Name")]
    public LogNameBtn logNameBtn;
    public RectTransform logListTransform;

    [Header("Log Content Text")]
    public Text logContentText;

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isAnimating)
        {
            isOpen = !isOpen;
            if (!isOpen)
            {
                logPanelAnimator.SetTrigger("Close");
                isAnimating = true;
            }
            else
            {
                logPanel.SetActive(isOpen);
            }

            SetupLogs();
        }
    }

    /// <summary>
    /// �����־����
    /// </summary>
    public void AddLogData(LogData_SO data)
    {
        LogData logData = new LogData();
        logData.logData = data;
        logList.logDatas.Add(logData);
    }

    public void SetupLogs()
    {
        logContentText.text = "";

        foreach (Transform item in logListTransform)
            Destroy(item.gameObject);

        foreach (var log in logList.logDatas)
        {
            var newLog = Instantiate(logNameBtn, logListTransform);
            newLog.SetUpNameBtn(log.logData);
            newLog.LogContentTxt = logContentText;
        }
    }
}

// ��־���ݴ洢��
[System.Serializable]
public class LogData
{
    public LogData_SO logData;
}
