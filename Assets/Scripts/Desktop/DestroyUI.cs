using UnityEngine;

public class DestroyUI : MonoBehaviour
{
    public void destroyUI()
    {
        DesktopManager.Instance.isWindowOpen = false;
        Destroy(gameObject);
    }
}
