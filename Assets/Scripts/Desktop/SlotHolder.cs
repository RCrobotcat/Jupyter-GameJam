using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotHolder : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public IconUI iconUI;
    public Image mask;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount % 2 == 0 && !DesktopManager.Instance.isWindowOpen)
        {
            UseSoftware();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (iconUI.GetItem() != null)
            iconUI.SetMaskAlpha(1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (iconUI.GetItem() != null)
            iconUI.SetMaskAlpha(0);
    }

    public void UseSoftware()
    {
        if (iconUI.GetItem() != null)
        {
            Debug.Log("Using " + iconUI.GetItem().softwareName);
            Transform parent = DesktopManager.Instance.ClientInterfacePanel;
            if (iconUI.GetItem().softwareClientInterface != null)
            {
                DesktopManager.Instance.isWindowOpen = true;
                Instantiate(iconUI.GetItem().softwareClientInterface, parent);
            }
        }
    }

    public void UpdateItem()
    {
        iconUI.Desktop = DesktopManager.Instance.DesktopData;

        var item = iconUI.Desktop.softwares[iconUI.Index];
        iconUI.SetUpItemUI(item.softwareData);
    }
}
