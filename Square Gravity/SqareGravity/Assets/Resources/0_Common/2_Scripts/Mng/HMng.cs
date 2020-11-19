using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 위치 :  0_Mngs
/// 게임에쓰이는 데이타를 DB에서 읽어와 저장해두는 곳입니다
/// 이곳은 참조만 하는곳입니다. 
/// </summary>
public class HMng : MonoBehaviour
{
    private static HMng m_Instance = null;

    public static HMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HMng)) as HMng;

                if (null == m_Instance)
                {
                    Debug.Log("Mng Fail to get Manager Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }



    void Start()
    {
        DontDestroyOnLoad(this);        
    }

    void Update()
    {
       
    }


}