using System.Collections.Generic;
using UnityEngine;

public class UntangleController : Singleton<UntangleController>
{
    public List<Node> nodes;
    public List<Edge> edges;

    [HideInInspector] public bool win = false; // 是否已经成功解开Untangle谜题

    public GameObject untanglePanel;
    public GameObject winTxt;

    protected override void Awake()
    {
        base.Awake();
        win = false;
    }

    void Update()
    {
        if (IsUntangled() && !win)
        {
            win = true;
            winTxt.SetActive(true);
            Debug.Log("You Win! All lines are untangled.");
        }
    }

    bool IsUntangled()
    {
        // 检查所有连线是否相交
        for (int i = 0; i < edges.Count; i++)
        {
            for (int j = i + 1; j < edges.Count; j++)
            {
                if (AreEdgesCrossed(edges[i], edges[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }

    bool AreEdgesCrossed(Edge edge1, Edge edge2)
    {
        Vector2 p1 = edge1.nodeA.transform.position;
        Vector2 p2 = edge1.nodeB.transform.position;
        Vector2 p3 = edge2.nodeA.transform.position;
        Vector2 p4 = edge2.nodeB.transform.position;

        // 使用线段相交算法，判断两条线段是否相交
        return LineIntersect(p1, p2, p3, p4);
    }

    bool LineIntersect(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
    {
        float d1 = CrossProduct(p3 - p1, p2 - p1);
        float d2 = CrossProduct(p4 - p1, p2 - p1);
        float d3 = CrossProduct(p1 - p3, p4 - p3);
        float d4 = CrossProduct(p2 - p3, p4 - p3);

        // 判断两个线段是否相交
        return (d1 * d2 < 0) && (d3 * d4 < 0);
    }

    float CrossProduct(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.y - v1.y * v2.x;
    }
}
