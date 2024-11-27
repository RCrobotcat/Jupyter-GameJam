using UnityEngine;

public class LogPanelDeactivate : MonoBehaviour
{
    public void CloseLogPanelAnimationEvent()
    {
        LogManager.Instance.isAnimating = false;
        LogManager.Instance.logPanel.SetActive(LogManager.Instance.isOpen);
    }
}
