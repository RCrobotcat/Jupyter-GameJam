using UnityEngine;

public class LogGiver : MonoBehaviour
{
    public LogData_SO logData; // 当前要添加的日志数据

    /// <summary>
    /// 添加日志数据到日志列表
    /// </summary>
    public void GiveLog()
    {
        LogManager.Instance.AddLogData(logData);
    }
}
