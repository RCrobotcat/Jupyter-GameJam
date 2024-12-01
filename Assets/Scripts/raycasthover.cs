using Unity.Burst.CompilerServices;
using UnityEngine;

public class ParentRaycastHover : MonoBehaviour
{
    public Material hoverMaterial;
    public Canvas targetCanvas;
    private Material[] originalMaterials;
    private Renderer[] childRenderers;
    private bool isHovering = false;
    private Camera mainCamera;

    private int layerMask;

    void Start()
    {

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No camera tagged as 'MainCamera' found in the scene.");
        }


        layerMask = LayerMask.GetMask("Default");

        // 获取父物体及所有子物体的 Renderer
        childRenderers = GetComponentsInChildren<Renderer>();


        originalMaterials = new Material[childRenderers.Length];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            originalMaterials[i] = childRenderers[i].material;
        }


        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (mainCamera == null) return;

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

                    if (transform.CompareTag("Exit") && GameManager.Instance.loginSuccess)
                    {
                        SceneController.Instance.TransitionToSceneHandler("Exit");
                    }
                }
                if (!isHovering)
                {
                    if (AudioManager.Instance != null && !DesktopManager.Instance.isOpen)
                    {
                        if (AudioManager.Instance.audioClip != null)            //音乐管理器的空值保护机制
                        {
                            AudioManager.Instance.OnChangeUI(AudioManager.Instance.audioClip[0].clip);
                        }
                    }
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


        foreach (var renderer in childRenderers)
        {
            if (renderer != null && hoverMaterial != null)
            {
                renderer.material = hoverMaterial;
            }
        }


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
