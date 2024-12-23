using UnityEngine;

public class DesktopManager : Singleton<DesktopManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }

    [HideInInspector] public bool isWindowOpen = false; // 是否打开了某个小窗口
    [HideInInspector] public bool isOpen = false; // 是否打开了桌面
    [HideInInspector] public bool isAnimating = false; // 是否正在播放动画

    [Header("Desktop Data")]
    public DesktopData_SO DesktopData;

    [Header("Containers")]
    public ContainerUI DesktopUI;

    [Header("Drag Canvas")]
    public Canvas dragCanvas;
    public DragData currentDrag;

    [Header("UI Panels")]
    public GameObject DesktopPanel;
    public Transform ClientInterfacePanel;
    public TimePanel timePanel;
    public GameObject CloseBtn;
    public GameObject buttom;

    [Header("Animator")]
    public Animator DesktopUIAnimator;

    [Header("WorldSpace Tips Panel")]
    public GameObject computerTipsPanel;

    [Header("Audio Clips")]
    public AudioClip openDesktopClip;
    public AudioClip clickInterface;
    public AudioClip clickTime;

    /// <summary>
    /// 即将要传送的场景
    /// </summary>
    [HideInInspector] public string alarmSceneToBeTransited = "";

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        // LoadData();
        if (DesktopUI != null)
            DesktopUI.RefreshUI();
    }

    public bool CheckInDesktopUI(Vector3 position)
    {
        for (int i = 0; i < DesktopUI.slots.Length; i++)
        {
            RectTransform t = DesktopUI.slots[i].transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(t, position))
                return true;
        }
        return false;
    }

    public void OpenDesktopPanel()
    {
        isOpen = !isOpen;
        if (!isOpen)
        {
            isAnimating = true;
            DesktopUIAnimator.SetTrigger("Close");
        }
        else
        {
            AudioManager.Instance.OnChangeUI(openDesktopClip);
            DesktopPanel.SetActive(isOpen);
            CloseBtn.SetActive(isOpen);
            buttom.SetActive(isOpen);
        }
    }
}
