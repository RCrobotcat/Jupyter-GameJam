using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 当前的用户名
    /// </summary>
    [HideInInspector] public string currentUserName = "";
}
