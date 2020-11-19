using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ������ ����
/// </summary>
public enum E_SLIME_MOTION_STATE
{
    E_SL_STAND,             // 0 ���ֱ� ����
    E_SL_RIGHT_MOVE,        // 1 ������ �ٱ� ����
    E_SL_LEFT_MOVE,         // 2 ���� �ٱ� ����
    E_SL_RIGHT_DAMAGE,      // 3 ������ �ǰ� ����
    E_SL_LEFT_DAMAGE,       // 4 ���� �ǰ� ����
    E_SL_RIGHT_DEATH,       // 5 ������ ���� ����
    E_SL_LEFT_DEATH,        // 6 ���� ���� ����
    E_SL_MAX                // 7 �� ����
}

//! Ű �������� ���� ����
public enum E_SLIME_KEY_STATE
{
    E_SL_KEY_RIGHT,      // 0 Left key ����
    E_SL_KEY_LEFT,       // 1 Right key ����
    E_SL_KEY_DAMAGE,     // 2 Damage key ����
    E_SL_KEY_DEATH,      // 3 Death key ����
    E_SL_KEY_MAX         // 4 �� ����
}


/// <summary>
/// ������ ���� �޴��� Ŭ����
/// </summary>
public class SSlimeStateMng : HScene
{
    /// <summary>
    /// ����
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1                  2                  3                  4
        //[E_SL_KEY_RIGHT]   [E_SL_KEY_LEFT]   [E_SL_KEY_DAMAGE]   [E_SL_KEY_DEATH]        [CALL]
                {0,                 0,                 0,                 0,                 0},     // 0 E_SL_STAND
                {1,                 0,                 0,                 0,                 1},     // 1 E_SL_RIGHT_MOVE
                {0,                 1,                 0,                 0,                 2},     // 2 E_SL_LEFT_MOVE
                {1,                 0,                 1,                 0,                 3},     // 3 E_SL_RIGHT_DAMAGE
                {0,                 1,                 1,                 0,                 4},     // 4 E_SL_LEFT_DAMAGE
                {1,                 0,                 1,                 1,                 5},     // 5 E_SL_RIGHT_DEATH
                {0,                 1,                 1,                 1,                 6},     // 6 E_SL_LEFT_DEATH
    };

    /// <summary>
    /// Ű ���� �ǽð� ���庯��
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_SLIME_KEY_STATE.E_SL_KEY_MAX];


    /// <summary>
    /// ������ ���� ���� ����
    /// </summary>
    public E_SLIME_KEY_STATE eDir = E_SLIME_KEY_STATE.E_SL_KEY_RIGHT;

    /// <summary>
    /// ������ ���� Ȯ�� ����
    /// </summary>
    public bool bIsAlive;

    /// <summary>
    /// ������ �̵� �ӵ�
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// ������ ����
    /// </summary>
    public tk2dAnimatedSprite Slime2dAniSprite = null;

    /// <summary>
    /// ������ ü�� : 6
    /// </summary>
    public float fSlimeHP;

    /// <summary>
    /// ������ ���ΰ� ��ǥ ���� ����
    /// </summary>
    public Vector3 SlimeCharVec3;

    /// <summary>
    /// ������ �̼� ���� ����
    /// </summary>
    public float fSlimeSpeed;

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
        ChangeScene("SSlimeStand");
        fSlimeHP = 6.0f;
        fSlimeSpeed = 2.0f;
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
    /// ������ ���� ����
    /// </summary>
    public void ChangeCharDir(E_SLIME_KEY_STATE eKeyState)
    {
        Vector3 DirVec = transform.parent.localScale;

        switch (eKeyState)
        {
            case E_SLIME_KEY_STATE.E_SL_KEY_RIGHT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.parent.localScale = DirVec;
                eDir = E_SLIME_KEY_STATE.E_SL_KEY_RIGHT;
                break;

            case E_SLIME_KEY_STATE.E_SL_KEY_LEFT:
                if (DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.parent.localScale = DirVec;
                eDir = E_SLIME_KEY_STATE.E_SL_KEY_LEFT;
                break;
        }
    }

    /// <summary>
    /// ������ ��� ����
    /// </summary>
    public void ChangeCharMotion(string sMotionName)
    {
        if (Slime2dAniSprite.CurrentClip.name != sMotionName)
            Slime2dAniSprite.Play(sMotionName);
    }


    public void LeftMove()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_LEFT] = 1;
    }

    public void LeftStop()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_LEFT] = 0;
    }

    public void RightMove()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_RIGHT] = 1;
    }

    public void RightStop()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_RIGHT] = 0;
    }

    public void DamageHit()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_DAMAGE] = 1;
    }

    public void DamageOut()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_DAMAGE] = 0;
    }

    public void Death()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_DEATH] = 1;
    }

    public void Alive()
    {
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_LEFT] = 0;
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_RIGHT] = 0;
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_DAMAGE] = 0;
        nKeyStatesArrary[(int)E_SLIME_KEY_STATE.E_SL_KEY_DEATH] = 0;
    }
}
