using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public SlotHolder[] slots;

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].iconUI.Index = i;
            slots[i].UpdateItem();
        }
    }

    // Close Panel Animation Event
    public void AnimationEvent()
    {
        DesktopManager.Instance.isAnimating = false;
        DesktopManager.Instance.timePanel.timeBtn.timePanelIsOpen = false;
        DesktopManager.Instance.timePanel.TimePanelGo.SetActive(DesktopManager.Instance.isOpen);
        DesktopManager.Instance.DesktopPanel.SetActive(DesktopManager.Instance.isOpen);
        DesktopManager.Instance.isWindowOpen = false;
        foreach (Transform window in DesktopManager.Instance.ClientInterfacePanel)
        {
            Destroy(window.gameObject);
        }
    }
}