using UnityEngine;
using UnityEngine.UI;

public class IngameUIManager : Singleton<IngameUIManager>
{
    [Header("UI Components")]
    public GameObject infoPanel; 
    public Text nameText;
    public Text descriptionText; 
    public Button closeButton; 

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            // 初始化时隐藏
            HideInfoPanel();

            if (closeButton != null)
                closeButton.onClick.AddListener(HideInfoPanel);
        }
    }
    private void OnEnable()
    {
        // 订阅鼠标点击事件
        InteractionEvents.OnMouseClick += ShowInfoPanel;
    }

    private void OnDisable()
    {
        // 取消订阅鼠标点击事件
        InteractionEvents.OnMouseClick -= ShowInfoPanel;
    }
 
    /// 显示信息
    private void ShowInfoPanel(InteractiveObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("InteractiveObject is null.");
            return;
        }
        
        InteractiveObjectInfo info = InteractionManager.Instance.GetInfoByName(obj.Io_name);
        if (info != null)
        {
            nameText.text = info.name; // 设置名称
            descriptionText.text = info.description; // 设置描述
        }
        

        // 显示面板
        infoPanel.SetActive(true);
    }
    
    /// 隐藏面板
    public void HideInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}