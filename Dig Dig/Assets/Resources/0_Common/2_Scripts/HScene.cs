using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ���޴��� �ֻ��� ��ü
/// </summary>
public abstract class HScene : MonoBehaviour {

    /// <summary>
    /// ����� ��ü
    /// </summary>
    public HState cSceneCurrent = null;

    /// <summary>
    /// ���� ��ü �Դϴ�.
    /// </summary>
    public HState cPrevScene = null;
    public HState cPrevPrevScene = null;
    public HState cFrontScene = null;

    /// <summary>
    /// ���� ������ ����� ���ҽ����� ����Ʈ
    /// </summary>
    public List<GameObject> ResourceList = null;

    /// <summary>
    /// ���� �� ��ü���� �迭
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

        //! ���� ���¶� �������� ������ �� �ٲٴ°���
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
                //! �ٲ�� �̸� ����
                cFrontScene = pNewHState;

                //! ������ �� ����
                cSceneCurrent.Exit();
                cPrevPrevScene = cPrevScene;
                cPrevScene = cSceneCurrent; //!< ���� ����صӴϴ�.
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

        //! ���� ���¶� �������� ������ �� �ٲٴ°���
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
                //! �ٲ�� �̸� ����
                cFrontScene = pNewHState;

                //! ������ �� ����
                cSceneCurrent.Exit();
                cPrevPrevScene = cPrevScene;
                cPrevScene = cSceneCurrent; //!< ���� ����صӴϴ�.
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
