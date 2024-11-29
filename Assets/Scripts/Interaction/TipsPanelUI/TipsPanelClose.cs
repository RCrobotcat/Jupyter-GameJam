using UnityEngine;

public class TipsPanelClose : MonoBehaviour
{
    public InteractiveObject obj;

    // Animation Event
    public void OnTipsPanelClose()
    {
        obj.isAnimating = false;
        this.gameObject.SetActive(false);
    }
}
