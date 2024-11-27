using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Log List", menuName = "Logs/Log List")]
public class LogList_SO : ScriptableObject
{
    public List<LogData> logDatas = new List<LogData>();
}
