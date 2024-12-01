using UnityEngine;
using UnityEngine.UI;

public class Email_middle : MonoBehaviour
{
    public Sprite flower; // ����������
    public Sprite flowerRing; // ��������ָ
    public Sprite receivePage; // ���ܽ���

    public Image sendItem;
    public Button sendBtn;

    public Image page;

    public LogData_SO receiveEmailLog;

    bool isSend = false;

    public AudioClip emailSend;

    void Awake()
    {
        sendBtn.onClick.AddListener(SendEmail);
    }

    void Update()
    {
        if (GameManager.Instance.getFlower)
        {
            sendItem.sprite = flower;
            if (!isSend)
                sendItem.gameObject.SetActive(true);
        }
        else
        {
            sendItem.gameObject.SetActive(false);
        }
    }

    void SendEmail()
    {
        if (GameManager.Instance.getFlower)
        {
            isSend = true;
            AudioManager.Instance.OnChangeUI(emailSend);
            page.sprite = receivePage;
            if (receiveEmailLog != null)
                LogManager.Instance.AddLogData(receiveEmailLog);
            sendItem.gameObject.SetActive(false);
            sendBtn.gameObject.SetActive(false);
        }
    }
}
