using UnityEngine;
using UnityEngine.UI;

public class IconUI : MonoBehaviour
{
    public Image icon = null;
    public Text _name = null;

    [HideInInspector] public SoftwareData_SO currentSoftwareData;

    public DesktopData_SO Desktop { get; set; }
    public int Index { get; set; } = -1;

    public SlotHolder currentSlot;

    public void SetMaskAlpha(float alpha)
    {
        Color maskColor = currentSlot.mask.color;
        maskColor.a = alpha;
        currentSlot.mask.color = maskColor;
    }

    public void SetUpItemUI(SoftwareData_SO item)
    {
        if (item == null)
        {
            Desktop.softwares[Index].softwareData = null;
            icon.gameObject.SetActive(false);
            SetMaskAlpha(0);
            return;
        }

        currentSoftwareData = item;
        icon.sprite = item.softwareIcon;
        _name.text = item.softwareName;
        icon.gameObject.SetActive(true);

        SetMaskAlpha(0); // Default to not hovered and not selected
    }

    public SoftwareData_SO GetItem()
    {
        return Desktop.softwares[Index].softwareData;
    }
}
