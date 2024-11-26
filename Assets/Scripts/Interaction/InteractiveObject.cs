using Unity.VisualScripting;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    
    public string Io_name;

    private bool isMouseOver = false;
    public Material outlineMaterial;
    public Material emiMaterial;

    public Material[] originalMaterials; // 原始材质列表
    public Material[] materialsWithOutline; // 包含 Outline 的材质列表
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
            materialsWithOutline = new Material[originalMaterials.Length + 1];
            for (int i = 0; i < originalMaterials.Length; i++)
            {
                materialsWithOutline[i] = originalMaterials[i];
            }

            // 设置 Outline 材质（需要在 Inspector 中指定）
            if (outlineMaterial != null)
            {
                materialsWithOutline[materialsWithOutline.Length - 1] = outlineMaterial;
            }
            else
            {
                Debug.LogError("Outline material not assigned in Inspector!");
            }
        }

        
        if (GetComponent<Renderer>() != null && GetComponent<Renderer>().materials.Length > 0)
        {
           
            emiMaterial= GetComponent<Renderer>().materials[0]; 
           
        }
       
        
    }

    private void Update()
    {   
        MouseDetect();
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
                    isMouseOver = true;
                    InteractionEvents.OnMouseHover?.Invoke(this);
                }
                return;
            }
        }

        if (isMouseOver)
        {
            isMouseOver = false;
            InteractionEvents.OnMouseExit?.Invoke(this);
        }
    }
    private void OnMouseDown()
    {
        InteractionEvents.OnMouseClick?.Invoke(this);
    }
}