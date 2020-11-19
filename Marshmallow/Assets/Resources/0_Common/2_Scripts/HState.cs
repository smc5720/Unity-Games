using UnityEngine;
using System.Collections;



//! 순수가상함수 할때는 abstract해주면 됩니다.
[System.Serializable]
public abstract class HState : MonoBehaviour
{
    /// <summary>
    /// 전씬을 저장해 둡니다
    /// </summary>
    public HState PreScene = null;

    public abstract void Enter();
    public abstract void Execute(float fDt);
    public abstract void Exit();

    //public abstract string GetClassName();
}

[System.Serializable]
public class hsfef : MonoBehaviour
{
    public string skey = string.Empty;
}