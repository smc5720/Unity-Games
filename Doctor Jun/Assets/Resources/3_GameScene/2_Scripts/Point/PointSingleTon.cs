using UnityEngine;
using System.Collections;

public class PointSingleTon : MonoBehaviour{

    private static PointSingleTon m_Instance = null;

    public static PointSingleTon I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(PointSingleTon)) as PointSingleTon;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [PointSingleTon.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// 포인트 배열 태그 값
    /// </summary>
    public int[] nPointTag = new int[11];

    /// <summary>
    /// bool형 포인트 상태 변경 변수
    /// </summary>
    public bool bPointStart;

    /// <summary>
    /// bool형 정답 입력 순서 변수
    /// </summary>
    public bool bAnswerStart;

    public int nPages;

    public int nLevel;

    public int nCheckTag;

    int nNum;

    public bool bisFail;
    public bool bisClear;

    public float fTimer;

    /// <summary>
    /// 전체 포인트 상태 변경 간격 변수
    /// </summary>
    public float fPointTimer;

    /// <summary>
    /// 전체 시간 변수
    /// </summary>
    public float fFullTimer;
    
    // Use this for initialization
	void Start () {
        fPointTimer = 0.5f;
        ShuffleTurn();
        bAnswerStart = false;
        nCheckTag = 1;
        nPages = 0;
        fTimer = 0.0f;
        bisFail = false;
        fFullTimer = 0.0f;
        bisClear = false;
        nLevel = 3;
	}
	
	// Update is called once per frame
	void Update () {
        fFullTimer += Time.deltaTime;
        AfterPattern();
        FailGame();
        ClearGame();
        nNum = Random.Range(1, 5);
	}

    /// <summary>
    /// 숫자 셔플링 알고리즘
    /// </summary>
    public void ShuffleTurn()
    {
        int nPreNum, nNextNum, nTemp;

        for (int i = 0; i < 11; i++)
        {
            nPointTag[i] = i+1;
        }

        for (int i = 0; i < 11; i++)
        {
            nPreNum = Random.Range(0, 11);
            nNextNum = Random.Range(0, 11);
            nTemp = nPointTag[nPreNum];
            nPointTag[nPreNum] = nPointTag[nNextNum];
            nPointTag[nNextNum] = nTemp;
        }

        foreach (GameObject Point in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            for (int i = 1; i <= 11; i++)
            {
                if (Point.name == i.ToString())
                {
                    Point.tag = nPointTag[i - 1].ToString();
                }
            }
        }

        bPointStart = true;
    }

    /// <summary>
    /// 패턴 보여준 후 적용 함수
    /// </summary>
    public void AfterPattern()
    {
        if (bAnswerStart == true)
        {
            if (nCheckTag == 13)
            {
                nCheckTag = 1;

                nLevel++;
                if (nLevel >= 11)
                {
                    nLevel = 11;
                }

                nPages++;
                ShuffleTurn();
                bAnswerStart = false;
            }
        }
    }

    public void FailGame()
    {
        if (bisFail == true)
        {
            fTimer += Time.deltaTime;
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "FailMark", new Vector3(-500.0f, 0.0f, -11.0f), new Vector3(512.0f, 168.0f, 1.0f), "", "");
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "Black", new Vector3(0.0f, 0.0f, -10.0f), new Vector3(480.0f, 832.0f, 1.0f), "", "");
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "Result", new Vector3(0.0f, 0.0f, -10.5f), new Vector3(400.0f, 400.0f, 1.0f), "", "StartFail");
            if (fTimer >= 1.0f)
            {
                bisFail = false;
                HPrefabMng.I.DestroyPrefab("FailMark(Clone)");
                HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "RestartPopup" + nNum.ToString(), new Vector3(0.0f, 0.0f, -1.0f), new Vector3(0.01f, 0.01f, 1.0f), "", "");
                Time.timeScale = 0;
            }
        }
    }

    public void ClearGame()
    {
        if (bisClear == true)
        {
            fTimer += Time.deltaTime;
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "ClearMark", new Vector3(0.0f, 700.0f, -11.0f), new Vector3(458.0f, 232.0f, 1.0f), "", "");
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "Black", new Vector3(0.0f, 0.0f, -10.0f), new Vector3(480.0f, 832.0f, 1.0f), "", "");
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "Result", new Vector3(0.0f, 0.0f, -10.5f), new Vector3(400.0f, 400.0f, 1.0f), "", "StartClear");
            if (fTimer >= 1.0f)
            {
                bisClear = false;
                fTimer = 0.0f;
                HPrefabMng.I.DestroyPrefab("Result(Clone)");
                HPrefabMng.I.DestroyPrefab("ClearMark(Clone)");
                HPrefabMng.I.DestroyPrefab("Black(Clone)");
            }
        }
    }
}
