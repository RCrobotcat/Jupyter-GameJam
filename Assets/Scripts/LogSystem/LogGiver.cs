using UnityEngine;

public class LogGiver : MonoBehaviour
{
    public LogData_SO logData; // ��ǰҪ��ӵ���־����

    /// <summary>
    /// �����־���ݵ���־�б�
    /// </summary>
    public void GiveLog()
    {
        LogManager.Instance.AddLogData(logData);
    }
}
