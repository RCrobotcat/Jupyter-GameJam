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

    [HideInInspector] public bool getSeed = false; // 是否获得种子
    [HideInInspector] public bool raiseFlower = false; // 是否种植花朵
}
