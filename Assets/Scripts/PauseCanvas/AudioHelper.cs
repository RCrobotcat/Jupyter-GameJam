using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public void OnChangeFX(AudioClip audioClip)  //������������
    {
        AudioManager.Instance.OnChangeFX(audioClip);
    }
    public void OnExitSlider()
    {
        AudioManager.Instance.OnExitSlider();
    }
}
