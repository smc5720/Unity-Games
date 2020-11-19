using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;


/// <summary>
/// 위치 :  0_Mngs
/// 각종 UI상태 및 씬위치 상태 관련 참조 및 저장 메니져입니다.
/// UI버튼 클릭 상태및 씬 현재 위치등 각각의정보들을 저장해 두는 곳입니다.
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
    /// 비동기식 로딩
    /// </summary>
    AsyncOperation async = null;


    /// <summary>   
    /// 커뮤니티 팝업창에서 사용
    /// 현재 여러명의 친구목록중에 어떤놈을 눌렸는지 저장해둠(아이디)
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
    /// 씬넘기는 함수입니다.
    /// 로딩바 자동 출력해줍니다.
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

            //! 로딩 애니메이션을 Update합니다.
            if (SpriteCtrl != null)
                SpriteCtrl.UpdateFrame();
        }

        HPrefabMng.I.DestroyLoadingPrefab();
        //HPrefabMng.I.DestroyPrefabs();        --> 각씬의 메니져클래스에 void Awake()안에 넣었어요 씬변경되면 다 지우라고^^
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
