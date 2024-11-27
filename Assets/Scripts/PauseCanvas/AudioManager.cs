using AmplifyShaderEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public struct AudioClips
    {
        public int ID;               //������
        public string descripttion;  //����
        public AudioClip clip;       //��Ƶ
    }
    [Header("�������")]
    public AudioMixer mixer;
    public AudioSource source_BGM;    //��������
    public AudioSource source_FX;     //��������
    [Header("��������")]
    public float amount;
    public AudioClips[] audioClip;
    [Header("�ű�")]
    public UIManager uiManager;   //��ȡ�ű�

    private void Update()
    {
        GetVloume();  //��ȡ��Ƶ����
        SetVloume();  //������Ƶ����
    }
    public void GetVloume( )
    {
        mixer.GetFloat("MasterVolume", out amount);
    }
    public void SetVloume()
    {
        mixer.SetFloat("MasterVolume", uiManager.volumeSlider.value * 100 - 80);
    }
    public void OnChangeBGM(AudioClip audioClip)  //����BGM
    {
        source_BGM.clip = audioClip;
        source_BGM.Play();
    }
    public void OnChangeFX(AudioClip audioClip)  //������������
    {
        source_FX.clip = audioClip;
        source_FX.Play();
    }

}
