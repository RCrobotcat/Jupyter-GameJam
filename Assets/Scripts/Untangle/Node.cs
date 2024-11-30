using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragged = false;
    [HideInInspector] public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.black;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragged)
        {
            Vector2 localPointerPosition;
            // 将屏幕坐标转换为Canvas的本地坐标
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(),
                eventData.position, eventData.pressEventCamera, out localPointerPosition);

            // 设置UI节点的位置
            rectTransform.localPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragged = false;
    }
}
