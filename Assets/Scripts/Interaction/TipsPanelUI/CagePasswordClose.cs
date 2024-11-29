using UnityEngine;

public class CagePasswordClose : MonoBehaviour
{
    // Animation Event
    public void ClosePasswordLockPanel()
    {
        this.gameObject.SetActive(false);
    }
}
