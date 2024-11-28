using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using JetBrains.Annotations;

public class TimePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TimePanelGo;
    public Bottom timeBtn;
    public Transform SelectedCanvas;
    public Transform current;

    /// <summary>
    /// Alarm Buttons
    /// </summary>
    [Header("Buttons")]
    public Button mainBtn;
    public Button childhoodBtn;
    public Button middleBtn;
    public Button elderBtn;

    [Header("Transforms")]
    public Transform mainTransform;
    public Transform childhoodTransform;
    public Transform middleTransform;
    public Transform elderTransform;

    void Awake()
    {
        mainBtn.onClick.AddListener(MainBtnClick);
        childhoodBtn.onClick.AddListener(ChildhoodBtnClick);
        middleBtn.onClick.AddListener(MiddleBtnClick);
        elderBtn.onClick.AddListener(ElderBtnClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject go = eventData.pointerEnter;
        switch (go.name)
        {
            case "mainBtn":
                mainTransform.SetParent(current);
                mainTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
                break;
            case "childhoodBtn":
                childhoodTransform.SetParent(current);
                childhoodTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
                break;
            case "middleBtn":
                middleTransform.SetParent(current);
                middleTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
                break;
            case "elderBtn":
                elderTransform.SetParent(current);
                elderTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetNativeScale();
    }

    void SetNativeScale()
    {
        if (mainTransform.parent != SelectedCanvas)
        {
            mainTransform.DOScale(Vector3.one, 0.3f);
            mainTransform.SetParent(SelectedCanvas);
            mainTransform.SetSiblingIndex(0);
        }

        if (childhoodTransform.parent != SelectedCanvas)
        {
            childhoodTransform.DOScale(Vector3.one, 0.3f);
            childhoodTransform.SetParent(SelectedCanvas);
            childhoodTransform.SetSiblingIndex(1);
        }

        if (middleTransform.parent != SelectedCanvas)
        {
            middleTransform.DOScale(Vector3.one, 0.3f);
            middleTransform.SetParent(SelectedCanvas);
            middleTransform.SetSiblingIndex(2);
        }

        if (elderTransform.parent != SelectedCanvas)
        {
            elderTransform.DOScale(Vector3.one, 0.3f);
            elderTransform.SetParent(SelectedCanvas);
            elderTransform.SetSiblingIndex(3);
        }
    }

    #region Button Events
    public void MainBtnClick()
    {
        Debug.Log("MainBtnClick");
        DesktopManager.Instance.OpenDesktopPanel();
        DesktopManager.Instance.CloseBtn.SetActive(false);
        DesktopManager.Instance.buttom.SetActive(false);

        DesktopManager.Instance.computerTipsPanel.SetActive(true);
        DesktopManager.Instance.alarmSceneToBeTransited = "Room_main";
    }

    public void ChildhoodBtnClick()
    {
        Debug.Log("ChildhoodBtnClick");
        DesktopManager.Instance.OpenDesktopPanel();
        DesktopManager.Instance.CloseBtn.SetActive(false);
        DesktopManager.Instance.buttom.SetActive(false);

        DesktopManager.Instance.computerTipsPanel.SetActive(true);
        DesktopManager.Instance.alarmSceneToBeTransited = "Room_childhood";
    }

    public void MiddleBtnClick()
    {
        Debug.Log("MiddleBtnClick");
        DesktopManager.Instance.OpenDesktopPanel();
        DesktopManager.Instance.CloseBtn.SetActive(false);
        DesktopManager.Instance.buttom.SetActive(false);

        DesktopManager.Instance.computerTipsPanel.SetActive(true);
        DesktopManager.Instance.alarmSceneToBeTransited = "Room_middle";
    }

    public void ElderBtnClick()
    {
        Debug.Log("ElderBtnClick");
        DesktopManager.Instance.OpenDesktopPanel();
        DesktopManager.Instance.CloseBtn.SetActive(false);
        DesktopManager.Instance.buttom.SetActive(false);

        DesktopManager.Instance.computerTipsPanel.SetActive(true);
        DesktopManager.Instance.alarmSceneToBeTransited = "Room_elder";
    }
    #endregion

    // Animation Event
    public void TimePanelClose()
    {
        timeBtn.isAnimating = false;
        TimePanelGo.SetActive(timeBtn.timePanelIsOpen);
    }
}
