using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ����Ʈ ����
/// </summary>
public enum E_POINT_MOTION_STATE
{
    E_PN_OFF,          // 0 ���� ����
    E_PN_ON,           // 1 ���� ����
    E_PN_REM,          // 2 ��� ����
    E_PN_MAX           // 3 �� ����
}

//! Ű �������� ���� ����
public enum E_POINT_KEY_STATE
{
    E_PN_KEY_ON,       // 1 On key ����
    E_PN_KEY_REM,      // 2 Remember Key ����
    E_PN_KEY_MAX       // 3 �� ����
}

/// <summary>
/// ����Ʈ ���� �޴��� Ŭ����
/// </summary>
public class PointStateMng : HScene
{
    /// <summary>
    /// ����Ʈ ����
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
    /// Ű ���� �ǽð� ���庯��
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
    /// �ڵ� ���� ���� �Լ�
    /// </summary>
    void ChangeAutoState()
    {
        int nWidth = nMotionTableArrary.GetLength(1);     // ������
        int nHeight = nMotionTableArrary.GetLength(0);    // �ళ��

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

        // 0 E_PN_OFF   ����Ʈ ���� ����
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