using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
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
    public AudioSource source_UI;     //UI����
    public Slider slider;             //���ִ�С����
    [Header("��������")]
    public float amount;
    public AudioClips[] audioClip;
    public bool isFristSlider = true;

    public AudioClip ingameBgm;
    bool changedBgm = false;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        GetVloume();
        SetVloume();  //������Ƶ����

        if (SceneManager.GetActiveScene().name != "MainMenu" && !changedBgm)
        {
            source_BGM.Stop();
            OnChangeBGM(ingameBgm);
            changedBgm = true;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            changedBgm = false;
        }
    }
    public void GetVloume()
    {
        mixer.GetFloat("MasterVolume", out amount);
    }
    public void SetVloume()
    {
        if (slider == null)
        {
            isFristSlider = true;
        }
        if (GameObject.FindWithTag("Slider") != null)
        {
            slider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
            if (slider != null && isFristSlider)
            {
                slider.value = (amount + 80) / 100;
                mixer.SetFloat("MasterVolume", amount);
                isFristSlider = false;
            }
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
    public void OnChangeUI(AudioClip audioClip)  //����UI����
    {
        source_UI.clip = audioClip;
        source_UI.Play();
    }
    public void OnExitSlider()
    {
        slider = null;
    }
}
