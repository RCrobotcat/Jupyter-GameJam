using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// ��ǰ���û���
    /// </summary>
    [HideInInspector] public string currentUserName = "";
}