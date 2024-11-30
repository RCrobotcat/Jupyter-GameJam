using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager: Singleton<AudioManager>
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
    public Slider slider;             //���ִ�С����
    [Header("��������")]
    public float amount;
    public AudioClips[] audioClip;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        GetVloume();  //��ȡ��Ƶ����
        SetVloume();  //������Ƶ����
    }
    public void GetVloume()
    {
        mixer.GetFloat("MasterVolume", out amount);
    }
    public void SetVloume()
    {
        if (slider != null)         //��ֵ����
        {
            mixer.SetFloat("MasterVolume", slider.value * 100 - 80);
        }
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
