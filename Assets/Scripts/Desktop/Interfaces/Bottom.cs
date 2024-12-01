using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bottom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button timeBtn;
    public GameObject TimePanel;
    [HideInInspector] public bool timePanelIsOpen = false;
    [HideInInspector] public bool isAnimating = false;
    public Animator TimePanelAnimator;

    void Awake()
    {
        timeBtn.onClick.AddListener(OpenTimePanel);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.name == "TimeBtn")
        {
            Color color = timeBtn.GetComponent<Image>().color;
            color.a = 1.0f;
            timeBtn.GetComponent<Image>().color = color;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color color = timeBtn.GetComponent<Image>().color;
        color.a = 0.5f;
        timeBtn.GetComponent<Image>().color = color;

    }

    public void OpenTimePanel()
    {
        if (!isAnimating)
        {
            timePanelIsOpen = !timePanelIsOpen;
            if (!timePanelIsOpen)
            {
                isAnimating = true;
                TimePanelAnimator.SetTrigger("Close");
            }
            else
            {
                AudioManager.Instance.OnChangeUI(DesktopManager.Instance.clickTime);
                TimePanel.SetActive(timePanelIsOpen);
            }
        }
    }
}