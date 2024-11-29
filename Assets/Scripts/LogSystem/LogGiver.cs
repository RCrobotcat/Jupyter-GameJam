using UnityEngine;
using DG.Tweening;

public class LogGiver : MonoBehaviour
{
    public LogData_SO logData; // ��ǰҪ��ӵ���־����
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
            player.logTipsIcon.DOColor(new Color(255, 248, 0, 255), 0.5f);
            player.logTipsText.DOColor(new Color(255, 100, 0, 255), 0.5f);

            // ��E�������־����
            if (Input.GetKeyDown(KeyCode.E))
            {
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
    /// �����־���ݵ���־�б�
    /// </summary>
    public void GiveLog()
    {
        LogManager.Instance.AddLogData(logData);
    }
}
