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

    public void AnimationEvent()
    {
        DesktopManager.Instance.DesktopPanel.SetActive(DesktopManager.Instance.isOpen);
    }
}