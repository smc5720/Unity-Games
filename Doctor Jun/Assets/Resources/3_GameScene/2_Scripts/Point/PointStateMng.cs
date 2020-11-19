using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 포인트 상태
/// </summary>
public enum E_POINT_MOTION_STATE
{
    E_PN_OFF,          // 0 꺼진 상태
    E_PN_ON,           // 1 켜진 상태
    E_PN_REM,          // 2 기억 상태
    E_PN_MAX           // 3 총 상태
}

//! 키 눌렸을때 정보 저장
public enum E_POINT_KEY_STATE
{
    E_PN_KEY_ON,       // 1 On key 눌림
    E_PN_KEY_REM,      // 2 Remember Key 눌림
    E_PN_KEY_MAX       // 3 총 상태
}

/// <summary>
/// 포인트 상태 메니져 클래스
/// </summary>
public class PointStateMng : HScene
{
    /// <summary>
    /// 포인트 상태
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1             2
        // [E_PN_KEY_ON]     [E_PN_KEY_REM]     [CALL]
                {0,                 0,            0},     // 0 E_PN_OFF          
                {1,                 0,            1},     // 1 E_PN_ON           
                {0,                 1,            2},     // 2 E_PN_REM     
    };

    /// <summary>
    /// 키 상태 실시간 저장변수
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_POINT_KEY_STATE.E_PN_KEY_MAX];

    PointSingleTon SingleTon;

    public GameObject PointGame;

    BoxCollider PointButton;

    public bool bisTurned;

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();
        ResourceList = new List<GameObject>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        bisTurned = false;
        SingleTon = PointSingleTon.I;
        PointButton = PointGame.GetComponent<BoxCollider>();
    }

    void Update()
    {
        base.Update();

        ChangeAutoState();

        CheckTurned();

        NumberChecking();

        isChecked();
    }

    /// <summary>
    /// 자동 상태 변경 함수
    /// </summary>
    void ChangeAutoState()
    {
        int nWidth = nMotionTableArrary.GetLength(1);     // 열개수
        int nHeight = nMotionTableArrary.GetLength(0);    // 행개수

        int nCnt = 0;

        for (int i = 0; i < nHeight; i++)
        {
            nCnt = 0;

            for (int j = 0; j < nWidth - 1; j++)
            {
                if (nMotionTableArrary[i, j] == nKeyStatesArrary[j])
                {
                    nCnt++;

                    if (nCnt == nWidth - 1)
                    {
                        ChangeScene(nMotionTableArrary[i, nWidth - 1]);
                        return;
                    }
                }
            }
        }

        // 0 E_PN_OFF   포인트 꺼짐 상태
        ChangeScene(nMotionTableArrary[0, 0]);
    }

    public void PointOffState()
    {
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_ON] = 0;
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_REM] = 0;
    }

    public void PointOnState()
    {
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_ON] = 1;
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_REM] = 0;
    }

    public void PointRememberState()
    {
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_ON] = 0;
        nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_REM] = 1;
    }

    public void CheckTurned()
    {
        if (SingleTon.bPointStart == false)
        {
            if (bisTurned == true)
            {
                bisTurned = false;
            }
        }
    }

    public void NumberChecking()
    {
        if (SingleTon.nCheckTag == 13)
        {
            PointOffState();
            Debug.Log(gameObject.name + " is off");
        }
    }

    public void isChecked()
    {
        if (SingleTon.bAnswerStart == true)
        {
            PointButton.enabled = true;
        }

        else if (SingleTon.bAnswerStart == false)
        {
            PointButton.enabled = false;
        }
    }
}