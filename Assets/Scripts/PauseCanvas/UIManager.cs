using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("���")]
    public Slider volumeSlider;     //��ȡ������Ƶ���
    public GameObject pausePanel;   //��ͣ����
    public Button SettingBtn;       //��ͣ��ť

    private void Awake()
    {
        SettingBtn.onClick.AddListener(pausePanelControl);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //������ͣ����
        {
            pausePanelControl();
        }
    }
    
    public void pausePanelControl()    //�����ݶ�����Ŀ���
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
