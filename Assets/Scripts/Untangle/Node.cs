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
            // ����Ļ����ת��ΪCanvas�ı�������
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent.GetComponent<RectTransform>(),
                eventData.position, eventData.pressEventCamera, out localPointerPosition);

            // ����UI�ڵ��λ��
            rectTransform.localPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragged = false;
    }
}
