using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(IconUI))]
public class DragIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    IconUI currentItemUI;
    SlotHolder currentHolder;
    SlotHolder targetHolder;

    bool Swapped;

    void Awake()
    {
        currentItemUI = GetComponent<IconUI>();
        currentHolder = GetComponentInParent<SlotHolder>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Swapped = false;
        DesktopManager.Instance.currentDrag = new DesktopManager.DragData();
        DesktopManager.Instance.currentDrag.originalHolder = GetComponentInParent<SlotHolder>();
        DesktopManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;
        transform.SetParent(DesktopManager.Instance.dragCanvas.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // follow the mouse cursor
        // Debug.Log(eventData.pointerEnter.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (DesktopManager.Instance.CheckInDesktopUI(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();
                else
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();

                if (targetHolder != DesktopManager.Instance.currentDrag.originalHolder)
                {
                    SwapItem();
                }

                if (Swapped)
                {
                    currentHolder.UpdateItem();
                    targetHolder.UpdateItem();
                }
            }
        }
        transform.SetParent(DesktopManager.Instance.currentDrag.originalParent);

        // reset the position of the item to the center of the slot
        RectTransform t = transform as RectTransform;
        t.offsetMax = -Vector2.one * 5;
        t.offsetMin = Vector2.one * 5;
    }

    public void SwapItem()
    {
        var targetItem = targetHolder.iconUI.Desktop.softwares[targetHolder.iconUI.Index];
        var tempItem = currentHolder.iconUI.Desktop.softwares[currentHolder.iconUI.Index];

        currentHolder.iconUI.Desktop.softwares[currentHolder.iconUI.Index] = targetItem;
        targetHolder.iconUI.Desktop.softwares[targetHolder.iconUI.Index] = tempItem;

        Swapped = true;
    }
}
