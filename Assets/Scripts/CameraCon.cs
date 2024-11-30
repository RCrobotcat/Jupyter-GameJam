using UnityEngine;

public class CameraRenderUIControl : MonoBehaviour
{
    public Camera targetCamera;       
    public LayerMask uiLayer;         
    public LayerMask sceneLayer;      
    public Canvas uiCanvas;           
    public Canvas uiCanvas2; 
    private float timer = 0f;        
    private bool isRenderingUI = true; 

    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main; 
        }

        if (targetCamera == null)
        {
            Debug.LogError("No camera found!" );
            return;
        }

        // 初始状态：只渲染 UI 层，并激活 UI Canvas
        targetCamera.cullingMask = uiLayer;
     
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 4f && isRenderingUI)
        {
            isRenderingUI = false;
            targetCamera.cullingMask = sceneLayer;
         
       
            uiCanvas2.gameObject.SetActive(true);
            if (uiCanvas != null)
            {
                uiCanvas.gameObject.SetActive(false);
            }
            
        }
    }
}