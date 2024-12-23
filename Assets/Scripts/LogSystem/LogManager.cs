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
    public AudioClip openSound;

    [Header("Log Name")]
    public LogNameBtn logNameBtn;
    public RectTransform logListTransform;

    [Header("Log Content Text")]
    public Text logContentText;

    [Header("Tips Panel")]
    public GameObject logAddedTips;

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isAnimating)
        {
            if (logAddedTips.activeSelf)
                logAddedTips.SetActive(false);

            isOpen = !isOpen;
            if (!isOpen)
            {
                logPanelAnimator.SetTrigger("Close");
                isAnimating = true;
            }
            else
            {
                AudioManager.Instance.OnChangeUI(openSound);
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
        if (logList.logDatas.Find(log => log.logData == data) != null)
        {
            // Debug.Log("Already Contained this log in loglist.");
            return;
        }

        logAddedTips.SetActive(true);
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
