using UnityEngine;

public class DesktopManager : Singleton<DesktopManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }

    [HideInInspector] public bool isWindowOpen; // �Ƿ����ĳ��С����
    [HideInInspector] public bool isOpen = false; // �Ƿ��������
    [HideInInspector] public bool isAnimating = false; // �Ƿ����ڲ��Ŷ���

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

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        // LoadData();
        DesktopUI.RefreshUI();
    }

    public bool CheckInDesktopUI(Vector3 position)
    {
        for (int i = 0; i < DesktopUI.slots.Length; i++)
        {
            // same as => (RectTransform) inventoryUI.slots[i].transform, typecasting
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
            DesktopPanel.SetActive(isOpen);
            CloseBtn.SetActive(isOpen);
            buttom.SetActive(isOpen);
        }
    }
}
