using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ġ :  0_Mngs
/// ���ӿ����̴� ����Ÿ�� DB���� �о�� �����صδ� ���Դϴ�
/// �̰��� ������ �ϴ°��Դϴ�. 
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