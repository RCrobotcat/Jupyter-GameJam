using UnityEngine;

public class Esc : Singleton<Esc>
{
    public GameObject EscPanel;

    public bool isEscPanelActive
    {
        get { return EscPanel.activeSelf; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscPanel.SetActive(!EscPanel.activeSelf);
        }
    }
}
