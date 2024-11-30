using UnityEngine;
using DG.Tweening;

public class LogGiver : MonoBehaviour
{
    public LogData_SO logData; // 当前要添加的日志数据
    bool _intrigger = false;

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _intrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _intrigger = false;
        }
    }

    void Update()
    {
        if (_intrigger)
        {
            if (LogManager.Instance.logList.logDatas.Find(log => log.logData == logData) == null)
            {
                player.logTipsIcon.DOColor(new Color(255, 248, 0, 255), 0.5f);
                player.logTipsText.DOColor(new Color(255, 100, 0, 255), 0.5f);
            }

            // 按E键添加日志数据
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (logData.name == "KnifeLog")
                    GameManager.Instance.getKnife = true;

                GiveLog();
            }
        }
        else
        {
            player.logTipsIcon.DOColor(new Color(255, 248, 0, 0), 0.5f);
            player.logTipsText.DOColor(new Color(255, 100, 0, 0), 0.5f);
        }
    }

    /// <summary>
    /// 添加日志数据到日志列表
    /// </summary>
    public void GiveLog()
    {
        LogManager.Instance.AddLogData(logData);
    }
}
