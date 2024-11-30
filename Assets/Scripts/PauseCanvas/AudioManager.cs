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
        public int ID;               //数组编号
        public string descripttion;  //描述
        public AudioClip clip;       //音频
    }
    [Header("基本组件")]
    public AudioMixer mixer;
    public AudioSource source_BGM;    //背景音乐
    public AudioSource source_FX;     //其他音乐 
    public Slider slider;             //音乐大小控制
    [Header("基本参数")]
    public float amount;
    public AudioClips[] audioClip;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        GetVloume();  //获取音频参数
        SetVloume();  //设置音频参数
    }
    public void GetVloume()
    {
        mixer.GetFloat("MasterVolume", out amount);
    }
    public void SetVloume()
    {
        if (slider != null)         //空值保护
        {
            mixer.SetFloat("MasterVolume", slider.value * 100 - 80);
        }
    }
    public void OnChangeBGM(AudioClip audioClip)  //更换BGM
    {
        source_BGM.clip = audioClip;
        source_BGM.Play();
    }
    public void OnChangeFX(AudioClip audioClip)  //更换其他音乐
    {
        source_FX.clip = audioClip;
        source_FX.Play();
    }

}
