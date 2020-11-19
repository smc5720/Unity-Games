using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// À§Ä¡ :  SceneMng
/// </summary>
public class HLogoSceneMng : HScene
{
    private static HLogoSceneMng m_Instance = null;
    public static HLogoSceneMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HLogoSceneMng)) as HLogoSceneMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HLogoSceneMng.cs]");
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
        ChangeScene("HLogoScene");        
    }
}
