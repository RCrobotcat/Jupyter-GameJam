using UnityEngine;

public class DesktopManager : Singleton<DesktopManager>
{
    public class DragData
    {
        public SlotHolder originalHolder;
        public RectTransform originalParent;
    }

    [Header("Desktop Data")]
    public DesktopData_SO DesktopData;

    [Header("Containers")]
    public ContainerUI DesktopUI;

    [Header("Drag Canvas")]
    public Canvas dragCanvas;
    public DragData currentDrag;

    [Header("UI Panels")]
    public GameObject DesktopPanel;

    bool isOpen = false;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        // LoadData();
        DesktopUI.RefreshUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            DesktopPanel.SetActive(isOpen);
        }
    }

    /*public void SaveData()
    {
        SaveManager.Instance.Save(inventoryData, inventoryData.name);
        SaveManager.Instance.Save(actionData, actionData.name);
        SaveManager.Instance.Save(equipmentData, equipmentData.name);
    }*/

    /*public void LoadData()
    {
        SaveManager.Instance.Load(inventoryData, inventoryData.name);
        SaveManager.Instance.Load(actionData, actionData.name);
        SaveManager.Instance.Load(equipmentData, equipmentData.name);
    }*/

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
}
