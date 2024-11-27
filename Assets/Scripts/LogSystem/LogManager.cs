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
    // 玩家日志数据列表
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
    /// 添加日志数据
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

// 日志数据存储类
[System.Serializable]
public class LogData
{
    public LogData_SO logData;
}
