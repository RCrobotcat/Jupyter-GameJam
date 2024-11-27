using UnityEngine;

[CreateAssetMenu(fileName = "New Log Data", menuName = "Logs/Log Data")]
public class LogData_SO : ScriptableObject
{
    public string LogName; // ��־����

    public AnwserTypes anwserTypes; // ��������־�����ĸ���

    [TextArea]
    public string content; // ��־����
}