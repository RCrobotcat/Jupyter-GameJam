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
        // 确保节点 A 在左侧
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
            // 计算两节点的中点
            rectTransform.localPosition = (nodeA.rectTransform.localPosition + nodeB.rectTransform.localPosition) / 2;

            // 计算两节点之间的偏移量
            Vector3 diff = nodeB.rectTransform.localPosition - nodeA.rectTransform.localPosition;

            // 设置线条的宽度和长度
            rectTransform.sizeDelta = new Vector2(diff.magnitude, 5);

            // 计算并设置旋转角度
            if (diff.x != 0) // 防止除以零错误
            {
                rectTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
            }
        }
    }
}
