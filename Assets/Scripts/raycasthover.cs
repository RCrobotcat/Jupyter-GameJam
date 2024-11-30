using Unity.Burst.CompilerServices;
using UnityEngine;

public class ParentRaycastHover : MonoBehaviour
{
    public Material hoverMaterial; // 鼠标悬停时的材质
    public Canvas targetCanvas;    // 要激活的 Canvas
    private Material[] originalMaterials; // 保存子物体的原始材质
    private Renderer[] childRenderers;    // 子物体的渲染器
    private bool isHovering = false;      // 是否鼠标悬停
    private Camera mainCamera;            // 主摄像机

    private int layerMask; // LayerMask，只对特定层生效

    void Start()
    {
        // 获取主摄像机
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No camera tagged as 'MainCamera' found in the scene.");
        }

        // 设置 LayerMask，仅检测 Default Layer
        layerMask = LayerMask.GetMask("Default");

        // 获取父物体及所有子物体的 Renderer
        childRenderers = GetComponentsInChildren<Renderer>();

        // 保存所有子物体的原始材质
        originalMaterials = new Material[childRenderers.Length];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            originalMaterials[i] = childRenderers[i].material;
        }

        // 确保 Canvas 初始状态是隐藏的
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (mainCamera == null) return; // 如果摄像机不存在，直接返回

        // 发射 Raycast，仅针对 Default Layer
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // 判断是否命中当前父物体或其子物体
            if (IsChildOrSelf(hit.collider.gameObject))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (transform.CompareTag("Bed") && DesktopManager.Instance.alarmSceneToBeTransited != "")
                    {
                        SceneController.Instance.TransitionToSceneHandler(DesktopManager.Instance.alarmSceneToBeTransited);
                    }
                }
                if (!isHovering)
                {
                    OnMouseHoverEnter();
                }
                return;
            }
        }

        // 如果鼠标不再悬停
        if (isHovering)
        {
            OnMouseHoverExit();
        }
    }

    private void OnMouseHoverEnter()
    {
        isHovering = true;

        // 更改所有子物体的材质
        foreach (var renderer in childRenderers)
        {
            if (renderer != null && hoverMaterial != null)
            {
                renderer.material = hoverMaterial;
            }
        }

        // 激活 Canvas
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(true);
        }
    }

    private void OnMouseHoverExit()
    {
        isHovering = false;

        // 恢复所有子物体的原始材质
        for (int i = 0; i < childRenderers.Length; i++)
        {
            if (childRenderers[i] != null && originalMaterials[i] != null)
            {
                childRenderers[i].material = originalMaterials[i];
            }
        }

        // 隐藏 Canvas
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    // 判断物体是否是当前父物体或其子物体
    private bool IsChildOrSelf(GameObject obj)
    {
        return obj == gameObject || obj.transform.IsChildOf(transform);
    }
}
