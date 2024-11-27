using UnityEngine;

[CreateAssetMenu(fileName = "New Log Data", menuName = "Logs/Log Data")]
public class LogData_SO : ScriptableObject
{
    public string LogName; // 日志名称

    public AnwserTypes anwserTypes; // 该线索日志属于哪个答案

    [TextArea]
    public string content; // 日志内容
}