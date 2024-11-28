using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    public GameObject TimePanelGo;
    public Bottom timeBtn;

    /// <summary>
    /// Alarm Buttons
    /// </summary>
    public Button mainBtn;
    public Button childhoodBtn;
    public Button middleBtn;
    public Button elderBtn;

    // Animation Event
    public void TimePanelClose()
    {
        timeBtn.isAnimating = false;
        TimePanelGo.SetActive(timeBtn.timePanelIsOpen);
    }
}
