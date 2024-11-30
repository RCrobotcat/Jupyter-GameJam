using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour
{
    public Node nodeA;
    public Node nodeB;

    private RectTransform rectTransform;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetNodes(GameObject one, GameObject two)
    {
        nodeA = one.GetComponent<Node>();
        nodeB = two.GetComponent<Node>();

        RectTransform aux;
        // ȷ���ڵ� A �����
        if (nodeA.rectTransform.localPosition.x > nodeB.rectTransform.localPosition.x)
        {
            aux = nodeA.rectTransform;
            nodeA.rectTransform = nodeB.rectTransform;
            nodeB.rectTransform = aux;
        }
    }

    void Update()
    {
        if (nodeA != null && nodeB != null && nodeA.gameObject.activeSelf && nodeB.gameObject.activeSelf)
        {
            // �������ڵ���е�
            rectTransform.localPosition = (nodeA.rectTransform.localPosition + nodeB.rectTransform.localPosition) / 2;

            // �������ڵ�֮���ƫ����
            Vector3 diff = nodeB.rectTransform.localPosition - nodeA.rectTransform.localPosition;

            // ���������Ŀ�Ⱥͳ���
            rectTransform.sizeDelta = new Vector2(diff.magnitude, 5);

            // ���㲢������ת�Ƕ�
            if (diff.x != 0) // ��ֹ���������
            {
                rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
            }
        }
    }
}
