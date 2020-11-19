using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 씬메니져 최상위 객체
/// </summary>
public abstract class HScene : MonoBehaviour {

    /// <summary>
    /// 현재씬 객체
    /// </summary>
    public HState cSceneCurrent = null;

    /// <summary>
    /// 전씬 객체 입니다.
    /// </summary>
    public HState cPrevScene = null;
    public HState cPrevPrevScene = null;
    public HState cFrontScene = null;

    /// <summary>
    /// 현재 씬에서 사용할 리소스저장 리스트
    /// </summary>
    public List<GameObject> ResourceList = null;

    /// <summary>
    /// 실제 씬 객체저장 배열
    /// </summary>
    //public List<string> ScenekeyList;
    public List<HState> SceneList;
    protected Dictionary<string, HState> cSceneList;

    
	
	// Update is called once per frame
    public void Update() 
    {
        if (GetCurrentScene() != null)
        {
            GetCurrentScene().Execute(Time.deltaTime);
        }
	}

    public HState GetCurrentScene(string sSceneName)
    {
        if (cSceneList.ContainsKey(sSceneName))
        {
            return cSceneList[sSceneName];
        }
        else
        {
            Debug.Log("NoScene");
            return null;
        }
    }

    public void ChangeScene(string sSceneName)
    {
        HState pNewHState = null;
        if (cSceneList.ContainsKey(sSceneName))
        {
            pNewHState = cSceneList[sSceneName];
        }
        else
        {
            Debug.Log("NoScene");
            return;
        }

        if (pNewHState == null)
            return;

        //! 현재 상태랑 같은놈이 들어오면 안 바꾸는거죠
        if (cSceneCurrent == pNewHState)
            return;

        if (pNewHState != null)
        {
            if (cSceneCurrent == null)
            {
                cSceneCurrent = pNewHState;
                cSceneCurrent.Enter();
            }
            else
            {
                //! 바뀔넘 미리 저장
                cFrontScene = pNewHState;

                //! 선택한 씬 저장
                cSceneCurrent.Exit();
                cPrevPrevScene = cPrevScene;
                cPrevScene = cSceneCurrent; //!< 전을 백업해둡니다.
                cSceneCurrent = pNewHState;
                cSceneCurrent.Enter();
            }
        }
    }

    public void ChangeScene(int nSceneNum)
    {
        HState pNewHState = null;

        if (SceneList.Count < nSceneNum)
        {
            Debug.Log("NoScene");
            return;
        }

        pNewHState = SceneList[nSceneNum];

        if (pNewHState == null)
        {
            Debug.Log("NoScene");
            return;
        }

        //! 현재 상태랑 같은놈이 들어오면 안 바꾸는거죠
        if (cSceneCurrent == pNewHState)
            return;

        if (pNewHState != null)
        {
            if (cSceneCurrent == null)
            {
                cSceneCurrent = pNewHState;
                cSceneCurrent.Enter();
            }
            else
            {
                //! 바뀔넘 미리 저장
                cFrontScene = pNewHState;

                //! 선택한 씬 저장
                cSceneCurrent.Exit();
                cPrevPrevScene = cPrevScene;
                cPrevScene = cSceneCurrent; //!< 전을 백업해둡니다.
                cSceneCurrent = pNewHState;
                cSceneCurrent.Enter();
            }
        }
    }

    public HState GetCurrentScene()
    {
        return cSceneCurrent;
    }

    public HState GetPrevHState()
    {
        return cPrevScene;
    }

    public HState GetPrevPrevHState()
    {
        return cPrevPrevScene;
    }

    public HState GetFrontHState()
    {
        return cFrontScene;
    }

    public string GetClassName(string sName)
    {
        if(sName != string.Empty)
        {
            Debug.Log(sName);
            int nStartNum = sName.IndexOf("(");
            int nEndNum = sName.IndexOf(")");
            
            string sTemp = sName.Substring(nStartNum+1, (nEndNum-nStartNum)-1);

            return sTemp;            
        }
        else
        {
            return string.Empty;
        }

        return string.Empty;
    }
}
