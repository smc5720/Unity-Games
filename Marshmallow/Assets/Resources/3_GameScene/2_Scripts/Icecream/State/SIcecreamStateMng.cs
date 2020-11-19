using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ���̽�ũ�� ����
/// </summary>
public enum E_ICECREAM_MOTION_STATE
{
    E_IC_STAND,             // 0 ���ֱ� ����
    E_IC_RIGHT_MOVE,        // 1 ������ �ٱ� ����
    E_IC_LEFT_MOVE,         // 2 ���� �ٱ� ����
    E_IC_RIGHT_DAMAGE,      // 3 ������ �ǰ� ����
    E_IC_LEFT_DAMAGE,       // 4 ���� �ǰ� ����
    E_IC_RIGHT_DEATH,       // 5 ������ ���� ����
    E_IC_LEFT_DEATH,        // 6 ���� ���� ����
    E_IC_MAX                // 7 �� ����
}

//! Ű �������� ���� ����
public enum E_ICE_KEY_STATE
{
    E_IC_KEY_RIGHT,      // 0 Left key ����
    E_IC_KEY_LEFT,       // 1 Right key ����
    E_IC_KEY_DAMAGE,     // 2 Damage key ����
    E_IC_KEY_DEATH,      // 3 Death key ����
    E_IC_KEY_MAX         // 4 �� ����
}


/// <summary>
/// ���̽�ũ�� ���� �޴��� Ŭ����
/// </summary>
public class SIcecreamStateMng : HScene
{
    /// <summary>
    /// ����
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1                  2                  3                  4
        //[E_IC_KEY_RIGHT]   [E_IC_KEY_LEFT]   [E_IC_KEY_DAMAGE]   [E_IC_KEY_DEATH]        [CALL]
                {0,                 0,                 0,                 0,                 0},     // 0 E_IC_STAND
                {1,                 0,                 0,                 0,                 1},     // 1 E_IC_RIGHT_MOVE
                {0,                 1,                 0,                 0,                 2},     // 2 E_IC_LEFT_MOVE
                {1,                 0,                 1,                 0,                 3},     // 3 E_IC_RIGHT_DAMAGE
                {0,                 1,                 1,                 0,                 4},     // 4 E_IC_LEFT_DAMAGE
                {1,                 0,                 1,                 1,                 5},     // 5 E_IC_RIGHT_DEATH
                {0,                 1,                 1,                 1,                 6},     // 6 E_IC_LEFT_DEATH
    };

    /// <summary>
    /// Ű ���� �ǽð� ���庯��
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_ICE_KEY_STATE.E_IC_KEY_MAX];


    /// <summary>
    /// ���̽�ũ�� ���� ���� ����
    /// </summary>
    public E_ICE_KEY_STATE eDir = E_ICE_KEY_STATE.E_IC_KEY_RIGHT;

    /// <summary>
    /// ���̽�ũ�� ���� Ȯ�� ����
    /// </summary>
    public bool bIsAlive;

    /// <summary>
    /// ���̽�ũ�� �̵� �ӵ�
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// ���̽�ũ�� ����
    /// </summary>
    public tk2dAnimatedSprite Icecream2dAniSprite = null;

    /// <summary>
    /// ���̽�ũ�� ü�� : 22
    /// </summary>
    public float fIcecreamHP;

    /// <summary>
    /// ���̽�ũ�� ���ΰ� ��ǥ ���� ����
    /// </summary>
    public Vector3 IcecreamCharVec3;

    /// <summary>
    /// ���̽�ũ�� �̼� ���� ����
    /// </summary>
    public float fIcecreamSpeed;

    /// <summary>
    /// ���̽�ũ�� �Ѿ� ���� �ӵ� ���� ����
    /// </summary>
    public float fBullet;

    /// <summary>
    /// ���̽�ũ�� �Ѿ� Ÿ�̸� ����
    /// </summary>
    public float fBulletTimer;

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();
        ResourceList = new List<GameObject>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        ChangeScene("SIcecreamStand");
        fIcecreamHP = 22.0f;
        fIcecreamSpeed = 2.0f;
        fBullet = 0;
        fBulletTimer = 2.0f;
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

        // 0 E_IC_STAND   (HStandState)  ���ִ� �����Դϴ�.
        ChangeScene(nMotionTableArrary[0, 0]);
    }

    /// <summary>
    /// ���̽�ũ�� ���� ����
    /// </summary>
    public void ChangeCharDir(E_ICE_KEY_STATE eKeyState)
    {
        Vector3 DirVec = transform.parent.localScale;

        switch (eKeyState)
        {
            case E_ICE_KEY_STATE.E_IC_KEY_RIGHT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.parent.localScale = DirVec;
                eDir = E_ICE_KEY_STATE.E_IC_KEY_RIGHT;
                break;

            case E_ICE_KEY_STATE.E_IC_KEY_LEFT:
                if (DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.parent.localScale = DirVec;
                eDir = E_ICE_KEY_STATE.E_IC_KEY_LEFT;
                break;
        }
    }

    /// <summary>
    /// ���̽�ũ�� ��� ����
    /// </summary>
    public void ChangeCharMotion(string sMotionName)
    {
        if (Icecream2dAniSprite.CurrentClip.name != sMotionName)
            Icecream2dAniSprite.Play(sMotionName);
    }


    public void LeftMove()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_LEFT] = 1;
    }

    public void LeftStop()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_LEFT] = 0;
    }

    public void RightMove()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_RIGHT] = 1;
    }

    public void RightStop()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_RIGHT] = 0;
    }

    public void DamageHit()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_DAMAGE] = 1;
    }

    public void DamageOut()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_DAMAGE] = 0;
    }

    public void Death()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_DEATH] = 1;
    }

    public void Alive()
    {
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_LEFT] = 0;
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_RIGHT] = 0;
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_DAMAGE] = 0;
        nKeyStatesArrary[(int)E_ICE_KEY_STATE.E_IC_KEY_DEATH] = 0;
    }
}
