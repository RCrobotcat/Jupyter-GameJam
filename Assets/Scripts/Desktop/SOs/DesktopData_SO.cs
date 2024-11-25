using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Desktop Data", menuName = "Desktop/Desktop Data")]
public class DesktopData_SO : ScriptableObject
{
    public List<DesktopData> softwares = new List<DesktopData>();
}

[System.Serializable]
public class DesktopData
{
    public SoftwareData_SO softwareData;
}
