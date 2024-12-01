using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public void OnChangeFX(AudioClip audioClip)  //∏¸ªª∆‰À˚“Ù¿÷
    {
        AudioManager.Instance.OnChangeFX(audioClip);
    }
    public void OnExitSlider()
    {
        AudioManager.Instance.OnExitSlider();
    }
}
