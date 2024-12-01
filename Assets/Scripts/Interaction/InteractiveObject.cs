using UnityEngine;

public class InteractiveObject : MonoBehaviour
{

    public string Io_name;

    private bool isMouseOver = false;
    public Material outlineMaterial;
    public Material emiMaterial;

    public Material[] originalMaterials; // 原始材质列表
    public Material[] materialsWithOutline; // 包含 Outline 的材质列表

    [Header("Tips Panel")]
    public GameObject TipsPanel;
    public Animator tipsPanelAnimator;
    [HideInInspector] public bool isAnimating;

    private void Awake()
    {
        if (string.IsNullOrEmpty(Io_name))
        {
            Io_name = this.name;
        }


        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            // 获取当前材质列表
            originalMaterials = renderer.materials;

            // 创建包含 Outline 的材质列表
            materialsWithOutline = new Material[originalMaterials.Length];
            for (int i = 0; i < originalMaterials.Length; i++)
            {
                materialsWithOutline[i] = originalMaterials[i];
            }




        }

    }

    private void Update()
    {
        if (!DesktopManager.Instance.isOpen && !Esc.Instance.isEscPanelActive)
            MouseDetect();
        else
        {
            if (isMouseOver)
            {
                isMouseOver = false;
                InteractionEvents.OnMouseExit?.Invoke(this);
            }
        }
    }

    private void MouseDetect()
    {
        //raycast 检测鼠标悬停等状态
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
            if (interactiveObject == this)
            {
                if (!isMouseOver)
                {
                    if (AudioManager.Instance != null)
                    {
                        if (AudioManager.Instance.audioClip != null)            //音乐管理器的空值保护机制
                        {
                            AudioManager.Instance.OnChangeFX(AudioManager.Instance.audioClip[0].clip);
                        }
                    }
                    isMouseOver = true;

                    if (TipsPanel != null)
                    {
                        if (!TipsPanel.activeSelf)
                        {
                            TipsPanel.SetActive(true);
                        }
                        else
                        {
                            tipsPanelAnimator.SetTrigger("Open");
                            isAnimating = false;
                        }

                        // 如果是可以获取的线索, 则添加日志信息
                        if (this.gameObject.GetComponent<LogGiver>() != null)
                        {
                            LogGiver logGiver = this.gameObject.GetComponent<LogGiver>();
                            logGiver.GiveLog();
                        }
                    }

                    InteractionEvents.OnMouseHover?.Invoke(this);
                }
                return;
            }
        }

        if (isMouseOver)
        {
            isMouseOver = false;

            if (TipsPanel != null && TipsPanel.activeSelf && !isAnimating)
            {
                isAnimating = true;
                tipsPanelAnimator.SetTrigger("Close");
            }

            InteractionEvents.OnMouseExit?.Invoke(this);
        }
    }
    private void OnMouseDown()
    {
        if (isMouseOver)
            InteractionEvents.OnMouseClick?.Invoke(this);
    }
}