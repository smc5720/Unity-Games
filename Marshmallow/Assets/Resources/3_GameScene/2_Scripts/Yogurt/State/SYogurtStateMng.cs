using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// �䱸��Ʈ ����
/// </summary>
public enum E_YOGURT_MOTION_STATE
{
    E_YO_STAND,             // 0 ���ֱ� ����
    E_YO_RIGHT_MOVE,        // 1 ������ �ٱ� ����
    E_YO_LEFT_MOVE,         // 2 ���� �ٱ� ����
    E_YO_RIGHT_DAMAGE,      // 3 ������ �ǰ� ����
    E_YO_LEFT_DAMAGE,       // 4 ���� �ǰ� ����
    E_YO_RIGHT_DEATH,       // 5 ������ ���� ����
    E_YO_LEFT_DEATH,        // 6 ���� ���� ����
    E_YO_MAX                // 7 �� ����
}

//! Ű �������� ���� ����
public enum E_YOGURT_KEY_STATE
{
    E_YO_KEY_RIGHT,      // 0 Left key ����
    E_YO_KEY_LEFT,       // 1 Right key ����
    E_YO_KEY_DAMAGE,     // 2 Damage key ����
    E_YO_KEY_DEATH,      // 3 Death key ����
    E_YO_KEY_MAX         // 4 �� ����
}


/// <summary>
/// �䱸��Ʈ ���� �޴��� Ŭ����
/// </summary>
public class SYogurtStateMng : HScene
{
    /// <summary>
    /// ����
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1                  2                  3                  4
        //[E_YO_KEY_RIGHT]   [E_YO_KEY_LEFT]   [E_YO_KEY_DAMAGE]   [E_YO_KEY_DEATH]        [CALL]
                {0,                 0,                 0,                 0,                 0},     // 0 E_YO_STAND
                {1,                 0,                 0,                 0,                 1},     // 1 E_YO_RIGHT_MOVE
                {0,                 1,                 0,                 0,                 2},     // 2 E_YO_LEFT_MOVE
                {1,                 0,                 1,                 0,                 3},     // 3 E_YO_RIGHT_DAMAGE
                {0,                 1,                 1,                 0,                 4},     // 4 E_YO_LEFT_DAMAGE
                {1,                 0,                 1,                 1,                 5},     // 5 E_YO_RIGHT_DEATH
                {0,                 1,                 1,                 1,                 6},     // 6 E_YO_LEFT_DEATH
    };

    /// <summary>
    /// Ű ���� �ǽð� ���庯��
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_YOGURT_KEY_STATE.E_YO_KEY_MAX];


    /// <summary>
    /// �䱸��Ʈ ���� ���� ����
    /// </summary>
    public E_YOGURT_KEY_STATE eDir = E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT;

    /// <summary>
    /// �䱸��Ʈ ���� Ȯ�� ����
    /// </summary>
    public bool bIsAlive;

    /// <summary>
    /// �䱸��Ʈ �̵� �ӵ�
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// �䱸��Ʈ ����
    /// </summary>
    public tk2dAnimatedSprite Yogurt2dAniSprite = null;

    /// <summary>
    /// �䱸��Ʈ ü�� : 17
    /// </summary>
    public float fYogurtHP;

    /// <summary>
    /// �䱸��Ʈ ���ΰ� ��ǥ ���� ����
    /// </summary>
    public Vector3 YogurtCharVec3;

    /// <summary>
    /// �䱸��Ʈ �̼� ���� ����
    /// </summary>
    public float fYogurtSpeed;

    void Awake()
    {
        bIsAlive = true;

        cSceneList = new Dictionary<string, HState>();
        ResourceList = new List<GameObject>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        ChangeScene("SYogurtStand");
        fYogurtHP = 17.0f;
        fYogurtSpeed = 0.5f;
    }
    
    void Update()
    {
        // [�����ϻ�]�θ� ������Ʈ ȣ��^^ �̰� �����ָ� �θ��� Update�� ����ȵǿ�^^
        base.Update();

        ChangeAutoState();
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

        ChangeScene(nMotionTableArrary[0, 0]);
    }

    /// <summary>
    /// �䱸��Ʈ ���� ����
    /// </summary>
    public void ChangeCharDir(E_YOGURT_KEY_STATE eKeyState)
    {
        Vector3 DirVec = transform.parent.localScale;

        switch (eKeyState)
        {
            case E_YOGURT_KEY_STATE.E_YO_KEY_LEFT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.parent.localScale = DirVec;
                eDir = E_YOGURT_KEY_STATE.E_YO_KEY_LEFT;
                break;

            case E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT:
                if (DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.parent.localScale = DirVec;
                eDir = E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT;
                break;
        }
    }

    /// <summary>
    /// �䱸��Ʈ ��� ����
    /// </summary>
    public void ChangeCharMotion(string sMotionName)
    {
        if (Yogurt2dAniSprite.CurrentClip.name != sMotionName)
            Yogurt2dAniSprite.Play(sMotionName);
    }


    public void LeftMove()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_LEFT] = 1;
    }

    public void LeftStop()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_LEFT] = 0;
    }

    public void RightMove()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT] = 1;
    }

    public void RightStop()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT] = 0;
    }

    public void DamageHit()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_DAMAGE] = 1;
    }

    public void DamageOut()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_DAMAGE] = 0;
    }

    public void Death()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_DEATH] = 1;
    }

    public void Alive()
    {
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_LEFT] = 0;
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT] = 0;
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_DAMAGE] = 0;
        nKeyStatesArrary[(int)E_YOGURT_KEY_STATE.E_YO_KEY_DEATH] = 0;
    }
}
