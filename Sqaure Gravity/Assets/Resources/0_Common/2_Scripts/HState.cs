using UnityEngine;
using System.Collections;



//! ���������Լ� �Ҷ��� abstract���ָ� �˴ϴ�.
[System.Serializable]
public abstract class HState : MonoBehaviour
{
    /// <summary>
    /// ������ ������ �Ӵϴ�
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