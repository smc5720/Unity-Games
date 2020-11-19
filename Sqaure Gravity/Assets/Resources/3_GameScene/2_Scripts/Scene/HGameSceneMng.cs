using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// À§Ä¡ : SceneMng
/// </summary>
public class HGameSceneMng : HScene
{
    private static HMenuSceneMng m_Instance = null;
    public static HMenuSceneMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HMenuSceneMng)) as HMenuSceneMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HMenuSceneMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();
        ResourceList = new List<GameObject>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        HPrefabMng.I.DestroyPrefabs();
        ChangeScene("HGameScene"); 
    }
}
