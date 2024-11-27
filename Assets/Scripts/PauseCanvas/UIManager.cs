using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("组件")]
    public Slider volumeSlider;     //获取调节音频组件
    public GameObject pausePanel;   //暂停界面
    public Button SettingBtn;       //暂停按钮

    private void Awake()
    {
        SettingBtn.onClick.AddListener(pausePanelControl);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //控制暂停界面
        {
            pausePanelControl();
        }
    }
    
    public void pausePanelControl()    //控制暂定界面的开关
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
