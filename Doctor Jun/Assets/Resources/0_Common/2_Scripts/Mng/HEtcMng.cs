using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;


/// <summary>
/// ��ġ :  0_Mngs
/// ���� UI���� �� ����ġ ���� ���� ���� �� ���� �޴����Դϴ�.
/// UI��ư Ŭ�� ���¹� �� ���� ��ġ�� �������������� ������ �δ� ���Դϴ�.
/// </summary>
public class HEtcMng : MonoBehaviour
{
    private static HEtcMng m_Instance = null;
    public static HEtcMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HEtcMng)) as HEtcMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HEtcMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }


    /// <summary>
    /// �񵿱�� �ε�
    /// </summary>
    AsyncOperation async = null;


    /// <summary>   
    /// Ŀ�´�Ƽ �˾�â���� ���
    /// ���� �������� ģ������߿� ����� ���ȴ��� �����ص�(���̵�)
    /// </summary>
    public string sCurrentSelFaceBookID = string.Empty;



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

    /// <summary>
    /// ���ѱ�� �Լ��Դϴ�.
    /// �ε��� �ڵ� ������ݴϴ�.
    /// </summary>
    /// <param name="sLevelName"></param>
    public void LoadLevelAsync(string sLevelName)
    {
        StartCoroutine(LoadingSpriteAnimation(sLevelName));
    }

    private IEnumerator LoadingSpriteAnimation(string sName)
    {
        async = Application.LoadLevelAsync(sName);

        HLoadingSpriteCtrl SpriteCtrl = HPrefabMng.I.CreateLoadingPrefab();

        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();

            //! �ε� �ִϸ��̼��� Update�մϴ�.
            if (SpriteCtrl != null)
                SpriteCtrl.UpdateFrame();
        }

        HPrefabMng.I.DestroyLoadingPrefab();
        //HPrefabMng.I.DestroyPrefabs();        --> ������ �޴���Ŭ������ void Awake()�ȿ� �־���� ������Ǹ� �� ������^^
    }



    public void SendResponseMessage(string methodString, params object[] parameters)
    {
        HPrefabMng.I.DestroyLoadingPrefab();

        HashSet<GameObject> objectsToCall;

        objectsToCall = new HashSet<GameObject>();

        Component[] targetComponents = (Component[])GameObject.FindObjectsOfType(typeof(MonoBehaviour));

        for (int index = 0; index < targetComponents.Length; index++)
        {
            objectsToCall.Add(targetComponents[index].gameObject);
        }

        string methodName = methodString;

        foreach (GameObject gameObject in objectsToCall)
        {

            if (parameters != null && parameters.Length == 1)
            {
                gameObject.SendMessage(methodName, parameters[0], SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                gameObject.SendMessage(methodName, parameters, SendMessageOptions.DontRequireReceiver);
            }
        }

        objectsToCall.Clear();
        objectsToCall = null;
    }
}
