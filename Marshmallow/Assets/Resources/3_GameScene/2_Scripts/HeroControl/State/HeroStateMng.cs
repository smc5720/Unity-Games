using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ĳ���� ����
/// </summary>
public enum E_CHAR_MOTION_STATE
{
    E_CH_STAND,            // 0 ���ֱ� ����
    E_CH_RIGHT_RUN,        // 1 ������ �ٱ� ����
    E_CH_LEFT_RUN,         // 2 ���� �ٱ� ����
    E_CH_UP_RUN,           // 3 ���� �ٱ� ����
    E_CH_DOWN_RUN,         // 4 �Ʒ��� �ٱ� ����
    E_CH_RIGHTUP_RUN,      // 5 ������ ���� �ٱ� ����
    E_CH_LEFTUP_RUN,       // 6 ���� ���� �ٱ� ����
    E_CH_RIGHTDOWN_RUN,    // 7 ������ �Ʒ��� �ٱ� ����
    E_CH_LEFTDOWN_RUN,     // 8 ���� �Ʒ��� �ٱ� ����
    E_CH_STAND_ATTACK,     // 9 ���ֱ� ����
    E_CH_RIGHT_ATTACK,     // 10 ������ ���� ����
    E_CH_LEFT_ATTACK,      // 11 ���� ���� ����
    E_CH_UP_ATTACK,        // 12 ���� ���� ����
    E_CH_DOWN_ATTACK,      // 13 �Ʒ��� ���� ����
    E_CH_RIGHTUP_ATTACK,   // 14 ������ ���� ���� ����
    E_CH_LEFTUP_ATTACK,    // 15 ���� ���� ���� ����
    E_CH_RIGHTDOWN_ATTACK, // 16 ������ �Ʒ��� ���� ����
    E_CH_LEFTDOWN_ATTACK,  // 17 ���� �Ʒ��� ���� ����
    E_CH_MAX               // 18 �� ����
}

//! Ű �������� ���� ����
public enum E_CHAR_KEY_STATE
{
    E_CH_KEY_RIGHT,      // 0 Left Key ����
    E_CH_KEY_LEFT,       // 1 Right key ����
    E_CH_KEY_UP,         // 2 Up Key ����
    E_CH_KEY_DOWN,       // 3 Down Key ����
    E_CH_KEY_ATTACK,     // 4 Attadk Key ����
    E_CH_KEY_RIGHT_UP,   // 5 Right Up Key ����
    E_CH_KEY_LEFT_UP,    // 6 Left Up Key ����
    E_CH_KEY_RIGHT_DOWN, // 7 Right Down Key ����
    E_CH_KEY_LEFT_DOWN,  // 8 Left Down Key ����
    E_CH_KEY_MAX         // 9 �� ����
}


/// <summary>
/// ĳ���� ���� �޴��� Ŭ����
/// </summary>
public class HeroStateMng : HScene
{
    private static HeroStateMng m_Instance = null;

    public static HeroStateMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HeroStateMng)) as HeroStateMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HeroStateMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    // ----------------------------------�ý���-----------------------------------------------

    /// <summary>
    /// ����
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1                  2                  3                  4                  5
        //[E_CH_KEY_RIGHT]   [E_CH_KEY_LEFT]     [E_CH_KEY_UP]     [E_CH_KEY_DOWN]    [E_CH_KEY_ATTACK]       [CALL]
                {0,                 0,                 0,                 0,                 0,                 0},     // 0 E_CH_STAND               (SStandState.cs)
                {1,                 0,                 0,                 0,                 0,                 1},     // 1 E_CH_RIGHT_RUN           (SRightMoveState.cs)
                {0,                 1,                 0,                 0,                 0,                 2},     // 2 E_CH_LEFT_RUN            (SLeftMoveState.cs)
                {0,                 0,                 1,                 0,                 0,                 3},     // 3 E_CH_UP_RUN              (SUpMoveState.cs)
                {0,                 0,                 0,                 1,                 0,                 4},     // 4 E_CH_DOWN_RUN            (SDownMoveState.cs)
                {1,                 0,                 1,                 0,                 0,                 5},     // 5 E_CH_RIGHTUP_RUN         (SRightUpMoveState.cs)
                {0,                 1,                 1,                 0,                 0,                 6},     // 6 E_CH_LEFTUP_RUN          (SLeftUpMoveState.cs)
                {1,                 0,                 0,                 1,                 0,                 7},     // 7 E_CH_RIGHTDOWN_RUN       (SRightDownMoveState.cs)
                {0,                 1,                 0,                 1,                 0,                 8},     // 8 E_CH_LEFTDOWN_RUN        (SLeftDownMoveState.cs)
                {0,                 0,                 0,                 0,                 1,                 9},     // 9 E_CH_STAND_ATTACK        (SStandAttackState.cs)
                {1,                 0,                 0,                 0,                 1,                10},     //10 E_CH_RIGHT_ATTACK        (SRightAttackState.cs)
                {0,                 1,                 0,                 0,                 1,                11},     //11 E_CH_LEFT_ATTACK         (SLeftAttackState.cs)
                {0,                 0,                 1,                 0,                 1,                12},     //12 E_CH_UP_ATTACK           (SUpAttackState.cs)
                {0,                 0,                 0,                 1,                 1,                13},     //13 E_CH_DOWN_ATTACK         (SDownAttackState.cs)
                {1,                 0,                 1,                 0,                 1,                14},     //14 E_CH_RIGHTUP_ATTACK      (SRightUpAttackState.cs)
                {0,                 1,                 1,                 0,                 1,                15},     //15 E_CH_LEFTUP_ATTACK       (SLeftUpAttackState.cs)
                {1,                 0,                 0,                 1,                 1,                16},     //16 E_CH_RIGHTDOWN_ATTACK    (SRightDownAttackState.cs)
                {0,                 1,                 0,                 1,                 1,                17},     //17 E_CH_LEFTDOWN_ATTACK     (SLeftDownAttackState.cs)
    };

    /// <summary>
    /// Ű ���� �ǽð� ���庯��
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_CHAR_KEY_STATE.E_CH_KEY_MAX];


    /// <summary>
    /// ĳ���� ���� ���� ����
    /// </summary>
    public E_CHAR_KEY_STATE eDir = E_CHAR_KEY_STATE.E_CH_KEY_RIGHT;


    /// <summary>
    /// ĳ���� �̵� �ӵ�
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// ĳ���� ����
    /// </summary>
    public tk2dAnimatedSprite Hero2dAniSprite = null;

    /// <summary>
    /// �ð� ����(float)
    /// </summary>
    public float fTimer;

    /// <summary>
    /// �ð� ����(int)
    /// </summary>
    public int nTimer;

    /// <summary>
    /// ī��Ʈ�ٿ� ������ ���� ���� ����
    /// </summary>
    public int nStartCount;

    /// <summary>
    /// �߻�ü �������: x
    /// </summary>
    public float fcharx;

    /// <summary>
    /// �߻�ü �������: y
    /// </summary>
    public float fchary;

    /// <summary>
    /// �߻�ü ������ ����
    /// </summary>
    public float fBulletDamage;

    /// <summary>
    /// �߻�ü �� ���� �ӵ� ����
    /// </summary>
    public float fBulletSpeed;

    /// <summary>
    /// �߻�ü ���� �ӵ� üũ ����
    /// </summary>
    public float fBulletCheck;

    /// <summary>
    /// ��ü ���ھ�
    /// </summary>
    public int nScore;

    /// <summary>
    /// ��ü ��ȭ
    /// </summary>
    public int nMoney;

    /// <summary>
    /// �÷��̾� ü�� ����
    /// </summary>
    public float fHeartGage;

    /// <summary>
    /// �÷��̾� ���̽�ƽ ���� ����
    /// </summary>
    public bool bPlayerAlive;

    /// <summary>
    /// �Ѿ� �迭 ���� ����
    /// </summary>
    public int nBulletNum;

    /// <summary>
    /// ����� �ӵ� ���� ����
    /// </summary>
    public float fHeroSpeed;

    /// <summary>
    /// �� �ҿ� �ð� ����
    /// </summary>
    public float fFullTime;

    /// <summary>
    /// �ð� ���� ���� ����
    /// </summary>
    public bool bTimeMng;

    /// <summary>
    /// ���ΰ� ����
    /// </summary>
    public Vector3 CharVector3;

    /// <summary>
    /// �ڵ� �߻�(Auto-Fire) �Ѿ� ����
    /// </summary>
    public Vector3 AutoFireVec3;

    /// <summary>
    /// ���̺� Ŭ���� ���� ����
    /// </summary>
    public int nClearNum;

    /// <summary>
    /// ���̺� �� ����
    /// </summary>
    public int nWaveNum;

    /// <summary>
    /// ���� ���� ���� ��
    /// </summary>
    public int nHunted;

    /// <summary>
    /// ���� (100$)
    /// </summary>
    public int nAOriPrize;

    /// <summary>
    /// ���� (150$)
    /// </summary>
    public int nBOriPrize;

    /// <summary>
    /// ���� (180$)
    /// </summary>
    public int nCOriPrize;

    /// <summary>
    /// ���ǵ� ����
    /// </summary>
    public int nSpeedLevel;

    /// <summary>
    /// ���ǵ� ������ �� ����
    /// </summary>
    public int nSpeedPrize;

    /// <summary>
    /// ������ ����
    /// </summary>
    public int nPowerLevel;

    /// <summary>
    /// ������ ��ȭ ������ �� ����
    /// </summary>
    public int nPowerPrize;

    /// <summary>
    /// ����� ����� ����
    /// </summary>
    public int nDrainLevel;

    /// <summary>
    /// ����� ����� �� ����
    /// </summary>
    public int nDrainPrize;

    /// <summary>
    /// ����� ��� Ȯ�� ����
    /// </summary>
    public int nDPercentLevel;

    /// <summary>
    /// ����� ��� Ȯ�� �� ����
    /// </summary>
    public int nDPercentPrize;

    /// <summary>
    /// ġ��Ÿ Ȯ�� ����
    /// </summary>
    public int nCriticalLevel;

    /// <summary>
    /// ġ��Ÿ Ȯ�� ��ȭ ������ �� ����
    /// </summary>
    public int nCriticalPrize;

    /// <summary>
    /// ī��Ʈ�ٿ� ������ ��ǥ ���� ���� (-315, 130, -16)
    /// </summary>
    public Vector3 CountPosVec3;

    /// <summary>
    /// [0, 2~9] ī��Ʈ�ٿ� ������ ������ ���� ���� (87, 102, 1)
    /// </summary>
    public Vector3 CountScaVec3;

    /// <summary>
    /// [10] ī��Ʈ�ٿ� ������ ������ ���� ���� (127, 103, 1)
    /// </summary>
    public Vector3 CountSca2Vec3;

    /// <summary>
    /// [1] ī��Ʈ�ٿ� ������ ������ ���� ���� (38, 102, 1)
    /// </summary>
    public Vector3 CountSca3Vec3;

    /// <summary>
    /// ��ü ���� ��� ����
    /// </summary>
    public int nMonsterKilled;

    /// <summary>
    /// ��ü �� ��ȭ ����
    /// </summary>
    public int nFullMoney;

    /// <summary>
    /// ����� ����� ����
    /// </summary>
    public float fDrain;

    /// <summary>
    /// ����� ����� ǥ��� ����
    /// </summary>
    public int nDrain;

    /// <summary>
    /// ����� ��� Ȯ�� ����
    /// </summary>
    public int nDPercent;

    /// <summary>
    /// ũ��Ƽ�� Ȯ�� ����
    /// </summary>
    public float fCriticalDmg;

    /// <summary>
    /// ũ��Ƽ�� Ȯ�� ǥ��� ����
    /// </summary>
    public int nCritical;

    /// <summary>
    /// ���� ���� bool�� ����
    /// </summary>
    public bool bisMonster;

    /// <summary>
    /// ����� �̵� ����� ���� ����
    /// </summary>
    public float fHeroControl;

    /// <summary>
    /// ���� �ð� ��Ʈ�ѷ�
    /// </summary>
    public float fPowerControl;

    /// <summary>
    /// ���� �ð� bool�� ��Ʈ�ѷ�
    /// </summary>
    public bool bPowerControl;

    /// <summary>
    /// ���� �踮�� ���İ�
    /// </summary>
    public float fBarrierAlpha = 0;

    /// <summary>
    /// ������ ��ä ���� ����
    /// </summary>
    public int nSlimeControl;

    /// <summary>
    /// ���� ��ä ���� ����
    /// </summary>
    public int nPieControl;

    /// <summary>
    /// �䱸��Ʈ ��ä ���� ����
    /// </summary>
    public int nYogurtControl;

    /// <summary>
    /// ���̽�ũ�� ��ä ���� ����
    /// </summary>
    public int nIcecreamControl;

    // ----------------------------------�ý���-----------------------------------------------

    // ----------------------------------������Ʈ---------------------------------------------

    /// <summary>
    /// ���ΰ� HP��
    /// </summary>
    public GameObject HeartBarGame;

    /// <summary>
    /// ���ΰ� �����ð� �踮��
    /// </summary>
    public GameObject BarrierGame;

    // ----------------------------------������Ʈ---------------------------------------------

    // ----------------------------------������-----------------------------------------------

    /// <summary>
    /// ������ ���¸Ŵ���
    /// </summary>
    public SSlimeStateMng SlimeMng;

    /// <summary>
    /// ������ ���� ���� ����
    /// </summary>
    public bool bisSlime;

    /// <summary>
    /// ������ ��ǥ Ȯ�� ����
    /// </summary>
    public int nCheckForSlime;

    /// <summary>
    /// ������ x��ǥ
    /// </summary>
    public float fSlimePosX;

    /// <summary>
    /// ������ y��ǥ
    /// </summary>
    public float fSlimePosY;

    /// <summary>
    /// ������ ����
    /// </summary>
    public Vector3 SlimeVector3;

    /// <summary>
    /// ������ ���� ���� int�� ����
    /// </summary>
    public int nSlimeNum;

    /// <summary>
    /// ������ ���ݷ� ����
    /// </summary>
    public float fSlimeDamage;

    public float fSlimeTimer;

    // ----------------------------------������-----------------------------------------------

    // ----------------------------------����-----------------------------------------------

    /// <summary>
    /// ���� ���¸Ŵ���
    /// </summary>
    public SPieStateMng PieMng;

    /// <summary>
    /// ���� ���� ���� ����
    /// </summary>
    public bool bisPie;

    /// <summary>
    /// ���� ��ǥ Ȯ�� ����
    /// </summary>
    public int nCheckForPie;

    /// <summary>
    /// ���� x��ǥ
    /// </summary>
    public float fPiePosX;

    /// <summary>
    /// ���� y��ǥ
    /// </summary>
    public float fPiePosY;

    /// <summary>
    /// ���� ����
    /// </summary>
    public Vector3 PieVector3;

    /// <summary>
    /// ���� ���� ���� int�� ����
    /// </summary>
    public int nPieNum;

    /// <summary>
    /// ���� ���ݷ� ����
    /// </summary>
    public float fPieDamage;

    public float fPieTimer;

    // ----------------------------------����-----------------------------------------------

    // ----------------------------------�䱸��Ʈ-----------------------------------------------

    /// <summary>
    /// �䱸��Ʈ ���¸Ŵ���
    /// </summary>
    public SYogurtStateMng YogurtMng;

    /// <summary>
    /// �䱸��Ʈ ���� ���� ����
    /// </summary>
    public bool bisYogurt;

    /// <summary>
    /// �䱸��Ʈ ��ǥ Ȯ�� ����
    /// </summary>
    public int nCheckForYogurt;

    /// <summary>
    /// �䱸��Ʈ x��ǥ
    /// </summary>
    public float fYogurtPosX;

    /// <summary>
    /// �䱸��Ʈ y��ǥ
    /// </summary>
    public float fYogurtPosY;

    /// <summary>
    /// �䱸��Ʈ ����
    /// </summary>
    public Vector3 YogurtVector3;

    /// <summary>
    /// �䱸��Ʈ ���� ���� int�� ����
    /// </summary>
    public int nYogurtNum;

    /// <summary>
    /// �䱸��Ʈ ���ݷ� ����
    /// </summary>
    public float fYogurtDamage;

    public float fYogurtTimer;

    // ----------------------------------�䱸��Ʈ-----------------------------------------------

    // ----------------------------------���̽�ũ��-----------------------------------------------

    /// <summary>
    /// ���̽�ũ�� ���¸Ŵ���
    /// </summary>
    public SIcecreamStateMng IcecreamMng;

    /// <summary>
    /// ���̽�ũ�� ���� ���� ����
    /// </summary>
    public bool bisIcecream;

    /// <summary>
    /// ���̽�ũ�� ��ǥ Ȯ�� ����
    /// </summary>
    public int nCheckForIcecream;

    /// <summary>
    /// ���̽�ũ�� x��ǥ
    /// </summary>
    public float fIcecreamPosX;

    /// <summary>
    /// ���̽�ũ�� y��ǥ
    /// </summary>
    public float fIcecreamPosY;

    /// <summary>
    /// ���̽�ũ�� ����
    /// </summary>
    public Vector3 IcecreamVector3;

    /// <summary>
    /// ���̽�ũ�� ���� ���� int�� ����
    /// </summary>
    public int nIcecreamNum;

    /// <summary>
    /// ���̽�ũ�� ���ݷ� ����
    /// </summary>
    public float fIcecreamDamage;

    public float fIcecreamTimer;

    // ----------------------------------���̽�ũ��-----------------------------------------------

    void Awake()
    {
        cSceneList = new Dictionary<string, HState>();
        ResourceList = new List<GameObject>();

        for (int i = 0; i < SceneList.Count; i++)
            cSceneList.Add(GetClassName(SceneList[i].ToString()), SceneList[i]);
    }

    void Start()
    {
        ChangeScene("HStandState");
        NewStart();
    }

    /// <summary>
    /// ���� �Լ�
    /// </summary>
    public void NewStart()
    {
        Time.timeScale = 1;
        /*--------------------------------------*/
        nScore = 0;
        nMoney = 0;
        nBulletNum = 1;
        nWaveNum = 1;
        nHunted = 0;
        nSpeedLevel = 1;
        nPowerLevel = 1;
        nDrainLevel = 1;
        nDPercentLevel = 1;
        nCriticalLevel = 1;
        nAOriPrize = 100;
        nBOriPrize = 150;
        nCOriPrize = 180;
        nStartCount = 10;
        nSlimeNum = 0;
        nPieNum = 0;
        nYogurtNum = 0;
        nIcecreamNum = 0;
        nMonsterKilled = 0;
        nFullMoney = 0;
        nDPercent = 5;
        nDrain = 2;
        nCritical = 100;
        nSlimeControl = 0;
        nPieControl = 0;
        nYogurtControl = 0;
        nIcecreamControl = 0;
        /*--------------------------------------*/
        fBulletDamage = 1.5f;
        fBulletSpeed = 0.25f;
        fBulletCheck = 0;
        fHeroSpeed = 3.0f;
        fTimer = 11.0f;
        fFullTime = 0;
        fHeartGage = 1.0f;
        fSlimeDamage = 0.15f;
        fPieDamage = 0.2f;
        fYogurtDamage = 0.5f;
        fIcecreamDamage = 0.3f;
        fHeroControl = 0;
        fDrain = 0.02f;
        fPowerControl = 0;
        fCriticalDmg = 1.0f;
        fSlimeTimer = 0.0f;
        fPieTimer = 0.0f;
        fYogurtTimer = 0.0f;
        fIcecreamTimer = 0.0f;
        /*--------------------------------------*/
        bPlayerAlive = true;
        bisSlime = true;
        bisYogurt = true;
        bisPie = true;
        bisIcecream = true;
        bisMonster = true;
        bPowerControl = false;
        /*--------------------------------------*/
        CountPosVec3 = new Vector3(-315, 130, -16);
        CountScaVec3 = new Vector3(87, 102, 1);
        CountSca2Vec3 = new Vector3(127, 103, 1);
        CountSca3Vec3 = new Vector3(38, 102, 1);
        WaveMonster();
    }

    void Update()
    {
        // [�����ϻ�]�θ� ������Ʈ ȣ��^^ �̰� �����ָ� �θ��� Update�� ����ȵǿ�^^
        base.Update();

        isMonster();

        WaveFunc();

        HPGageMng();

        PowerOver();

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

        // 0 E_CH_STAND   (HStandState)  ���ִ� �����Դϴ�.
        ChangeScene(nMotionTableArrary[0, 0]);
    }

    /// <summary>
    /// ĳ���� ���� ����
    /// </summary>
    public void ChangeCharDir(E_CHAR_KEY_STATE eKeyState)
    {
        Vector3 DirVec = transform.parent.localScale;

        switch (eKeyState)
        {
            case E_CHAR_KEY_STATE.E_CH_KEY_RIGHT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.parent.localScale = DirVec;
                eDir = E_CHAR_KEY_STATE.E_CH_KEY_RIGHT;
                break;

            case E_CHAR_KEY_STATE.E_CH_KEY_LEFT:
                if (DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.parent.localScale = DirVec;
                eDir = E_CHAR_KEY_STATE.E_CH_KEY_LEFT;
                break;
        }
    }

    /// <summary>
    /// ĳ���� ��� ����
    /// </summary>
    public void ChangeCharMotion(string sMotionName)
    {
        if (Hero2dAniSprite.CurrentClip.name != sMotionName)
            Hero2dAniSprite.Play(sMotionName);
    }


    public void LeftBtnPress()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_LEFT] = 1;
    }

    public void LeftBtnRelease()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_LEFT] = 0;
    }

    public void RightBtnPress()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_RIGHT] = 1;
    }

    public void RightBtnRelease()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_RIGHT] = 0;
    }

    public void UpBtnPress()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_UP] = 1;
    }

    public void UpBtnRelease()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_UP] = 0;
    }

    public void DownBtnPress()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_DOWN] = 1;
    }

    public void DownBtnRelease()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_DOWN] = 0;
    }

    public void AttackBtnPress()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_ATTACK] = 1;
    }

    public void AttackBtnRelease()
    {
        nKeyStatesArrary[(int)E_CHAR_KEY_STATE.E_CH_KEY_ATTACK] = 0;
    }

    /// <summary>
    /// ���� ���� ���� ���� �Լ�
    /// </summary>
    public void isMonster()
    {
        HeroStateMng.I.CharVector3 = HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;

        if (bisSlime == true)
        {
            fSlimeTimer += Time.deltaTime;
            if (fSlimeTimer >= 1.0f)
            {
                if (nSlimeControl != 0)
                {
                    CreateSlime();
                    bisSlime = false;
                }
            }
        }

        else if (bisSlime == false)
        {
            fSlimeTimer = 0.0f;
        }

        if (bisPie == true)
        {
            fPieTimer += Time.deltaTime;
            if (fPieTimer >= 1.0f)
            {
                if (nPieControl != 0)
                {
                    CreatePie();
                    bisPie = false;
                }
            }
        }

        else if (bisPie == false)
        {
            fPieTimer = 0.0f;
        }

        if (bisYogurt == true)
        {
            fYogurtTimer += Time.deltaTime;
            if (fYogurtTimer >= 1.0f)
            {
                if (nYogurtControl != 0)
                {
                    CreateYogurt();
                    bisYogurt = false;
                }
            }
        }

        else if (bisYogurt == false)
        {
            fYogurtTimer = 0.0f;
        }

        if (bisIcecream == true)
        {
            fIcecreamTimer += Time.deltaTime;
            if (fIcecreamTimer >= 1.0f)
            {
                if (nIcecreamControl != 0)
                {
                    CreateIcecream();
                    bisIcecream = false;
                }
            }
        }

        else if (bisIcecream == false)
        {
            fIcecreamTimer = 0.0f;
        }

    }

    /// <summary>
    /// ü�¹� ���� �Լ�
    /// </summary>
    public void HPGageMng()
    {
        HeartBarGame.GetComponent<UISprite>().fillAmount = fHeartGage;
        if (fHeroSpeed == 0)
        {
            fHeroControl += Time.deltaTime;
            if (fHeroControl >= 3)
            {
                fHeroSpeed = 3.0f;
                fHeroControl = 0;
            }
        }

        if (fHeartGage <= 0.0f)
        {
            HeroDeath();
        }
    }

    /// <summary>
    /// Ÿ�̸� ���� �Լ�
    /// </summary>
    public void Timer()
    {
        fTimer -= Time.deltaTime;
        nTimer = (int)fTimer;
        CountDown();
        if (fTimer <= 0)
        {
            HPrefabMng.I.DestroyPrefab("SUpgradePopupPrefab(Clone)");
            fTimer = 11.0f;
            nStartCount = 10;
            nWaveNum++;
            nHunted = 0;
            WaveMonster();
            fHeroSpeed = 3.0f;
            bisMonster = true;
        }
    }

    /// <summary>
    /// ī��Ʈ�ٿ� ���� �Լ�
    /// </summary>
    public void CountDown()
    {
        if (nStartCount == 10)
        {
            HPrefabMng.I.CreatePrefab("Panel", E_H_RESOURCELOAD.E_3_GameScene, "10Prefab", CountPosVec3, CountSca2Vec3, "", "CountDown");
            nStartCount--;
        }

        else if (nStartCount == nTimer)
        {
            if (nStartCount == 1)
            {
                HPrefabMng.I.CreatePrefab("Panel", E_H_RESOURCELOAD.E_3_GameScene, "1Prefab", CountPosVec3, CountSca3Vec3, "", "CountDown");
                nStartCount--;
            }

            else
            {
                HPrefabMng.I.CreatePrefab("Panel", E_H_RESOURCELOAD.E_3_GameScene, (nStartCount.ToString() + "Prefab"), CountPosVec3, CountScaVec3, "", "CountDown");
                nStartCount--;
            }
        }
    }

    /// <summary>
    /// ������ ���� �Լ�
    /// </summary>
    public void CreateSlime()
    {
        if (nSlimeControl >= 1)
        {
            ShuffleSlimePos();

            GameObject.Find("SlimePrefab1").transform.localPosition = new Vector3(fSlimePosX, fSlimePosY, -1);
            GameObject.Find("SlimeStateMng1").GetComponent<SSlimeStateMng>().bIsAlive = true;
        }

        if (nSlimeControl >= 2)
        {
            nCheckForSlime = 0;

            ShuffleSlimePos();

            GameObject.Find("SlimePrefab2").transform.localPosition = new Vector3(fSlimePosX, fSlimePosY, -1);
            GameObject.Find("SlimeStateMng2").GetComponent<SSlimeStateMng>().bIsAlive = true;
        }

        if (nSlimeControl >= 3)
        {

            nCheckForSlime = 0;

            ShuffleSlimePos();

            GameObject.Find("SlimePrefab3").transform.localPosition = new Vector3(fSlimePosX, fSlimePosY, -1);
            GameObject.Find("SlimeStateMng3").GetComponent<SSlimeStateMng>().bIsAlive = true;
        }

        if (nSlimeControl >= 4)
        {
            nCheckForSlime = 0;

            ShuffleSlimePos();

            GameObject.Find("SlimePrefab4").transform.localPosition = new Vector3(fSlimePosX, fSlimePosY, -1);
            GameObject.Find("SlimeStateMng4").GetComponent<SSlimeStateMng>().bIsAlive = true;
        }

        if (nSlimeControl >= 5)
        {
            nCheckForSlime = 0;

            ShuffleSlimePos();

            GameObject.Find("SlimePrefab5").transform.localPosition = new Vector3(fSlimePosX, fSlimePosY, -1);
            GameObject.Find("SlimeStateMng5").GetComponent<SSlimeStateMng>().bIsAlive = true;
        }

        if (nSlimeControl >= 5)
        {
            nSlimeNum = 5;
        }

        if (nSlimeControl < 5)
        {
            nSlimeNum = nSlimeControl;
        }
    }

    /// <summary>
    /// ���� ���� �Լ�
    /// </summary>
    public void CreatePie()
    {
        if (nPieControl >= 1)
        {
            nCheckForPie = 0;

            ShufflePiePos();

            GameObject.Find("PiePrefab1").transform.localPosition = new Vector3(fPiePosX, fPiePosY, -1);
            GameObject.Find("PieStateMng1").GetComponent<SPieStateMng>().bIsAlive = true;
        }

        if (nPieControl >= 2)
        {
            nCheckForPie = 0;

            ShufflePiePos();

            GameObject.Find("PiePrefab2").transform.localPosition = new Vector3(fPiePosX, fPiePosY, -1);
            GameObject.Find("PieStateMng2").GetComponent<SPieStateMng>().bIsAlive = true;
        }

        if (nPieControl >= 3)
        {
            nCheckForPie = 0;

            ShufflePiePos();

            GameObject.Find("PiePrefab3").transform.localPosition = new Vector3(fPiePosX, fPiePosY, -1);
            GameObject.Find("PieStateMng3").GetComponent<SPieStateMng>().bIsAlive = true;
        }

        if (nPieControl >= 3)
        {
            nPieNum = 3;
        }

        if (nPieControl < 3)
        {
            nPieNum = nPieControl;
        }
    }

    /// <summary>
    /// �䱸��Ʈ ���� �Լ�
    /// </summary>
    public void CreateYogurt()
    {
        if (nYogurtControl >= 1)
        {
            ShuffleYogurtPos();

            GameObject.Find("YogurtPrefab").transform.localPosition = new Vector3(fYogurtPosX, fYogurtPosY, -1);
            GameObject.Find("YogurtStateMng").GetComponent<SYogurtStateMng>().bIsAlive = true;
        }

        if (nYogurtControl >= 1)
        {
            nYogurtNum = 1;
        }

        if (nYogurtControl < 1)
        {
            nYogurtNum = nYogurtControl;
        }
    }

    /// <summary>
    /// ���̽�ũ�� ���� �Լ�
    /// </summary>
    public void CreateIcecream()
    {
        if (nIcecreamControl >= 1)
        {
            ShuffleIcecreamPos();

            GameObject.Find("IcecreamPrefab").transform.localPosition = new Vector3(fIcecreamPosX, fIcecreamPosY, -1);
            GameObject.Find("IcecreamStateMng").GetComponent<SIcecreamStateMng>().bIsAlive = true;
        }

        if (nIcecreamControl >= 1)
        {
            nIcecreamNum = 1;
        }

        if (nIcecreamControl < 1)
        {
            nIcecreamNum = nIcecreamControl;
        }
    }

    /// <summary>
    /// ���̺� ���� �� Ŭ���� ���� ���� ���� �Լ�
    /// </summary>
    public void WaveFunc()
    {
        if (nClearNum <= nHunted)
        {
            if (nWaveNum == 10)
            {
                HeroDeath();
            }

            if (nWaveNum <= 9)
            {
                HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "SUpgradePopupPrefab", new Vector3(0, 0, 0) , new Vector3(1, 1, 1), "", "");
                foreach (GameObject Monster in GameObject.FindObjectsOfType(typeof(GameObject)))
                {
                    if (Monster.tag == "Slime" || Monster.tag == "Pie" || Monster.tag == "Yogurt" || Monster.tag == "Icecream")
                    {
                        Monster.transform.localPosition = new Vector3(-800, 600, -1);
                        Monster.rigidbody.velocity = new Vector3(0, 0, 0);
                    }
                }
                AttackBtnRelease();
                fHeroSpeed = 0;
                bisMonster = false;
                Timer();
            }
        }
    }

    /// <summary>
    /// ������ ��ǥ ���� ���� �Լ�
    /// </summary>
    public void ShuffleSlimePos()
    {
        nCheckForSlime = 0;

        for (int i = 0; i < 1000; i++)
        {
            fSlimePosX = Random.Range(-600.0f, 600.0f);
            fSlimePosY = Random.Range(-320.0f, 320.0f);

            if ((fSlimePosX <= -450 || fSlimePosX >= 460) || (fSlimePosY <= -275 || fSlimePosY >= 290))
            {
                nCheckForSlime = 1;
                break;
            }
        }

        if (nCheckForSlime == 0)
        {
            fSlimePosY = Random.Range(290.0f, 320.0f);
        }
    }

    /// <summary>
    /// ���� ��ǥ ���� ���� �Լ�
    /// </summary>
    public void ShufflePiePos()
    {
        nCheckForPie = 0;

        for (int i = 0; i < 1000; i++)
        {
            fPiePosX = Random.Range(-600.0f, 600.0f);
            fPiePosY = Random.Range(-320.0f, 320.0f);

            if ((fPiePosX <= -450 || fPiePosX >= 460) || (fPiePosY <= -275 || fPiePosY >= 290))
            {
                nCheckForPie = 1;
                break;
            }
        }

        if (nCheckForPie == 0)
        {
            fPiePosY = Random.Range(290.0f, 320.0f);
        }
    }

    /// <summary>
    /// �䱸��Ʈ ��ǥ ���� ���� �Լ�
    /// </summary>
    public void ShuffleYogurtPos()
    {
        nCheckForYogurt = 0;

        for (int i = 0; i < 1000; i++)
        {
            fYogurtPosX = Random.Range(-600.0f, 600.0f);
            fYogurtPosY = Random.Range(-320.0f, 320.0f);

            if ((fYogurtPosX <= -450 || fYogurtPosX >= 460) || (fYogurtPosY <= -275 || fYogurtPosY >= 290))
            {
                nCheckForYogurt = 1;
                break;
            }
        }

        if (nCheckForYogurt == 0)
        {
            fYogurtPosY = Random.Range(290.0f, 320.0f);
        }
    }

    /// <summary>
    /// ���̽�ũ�� ��ǥ ���� ���� �Լ�
    /// </summary>
    public void ShuffleIcecreamPos()
    {
        nCheckForIcecream = 0;

        for (int i = 0; i < 1000; i++)
        {
            fIcecreamPosX = Random.Range(-600.0f, 600.0f);
            fIcecreamPosY = Random.Range(-320.0f, 320.0f);

            if ((fIcecreamPosX <= -450 || fIcecreamPosX >= 460) || (fIcecreamPosY <= -275 || fIcecreamPosY >= 290))
            {
                nCheckForIcecream = 1;
                break;
            }
        }

        if (nCheckForIcecream == 0)
        {
            fIcecreamPosY = Random.Range(290.0f, 320.0f);
        }
    }

    /// <summary>
    /// �����ð� ���� �Լ�
    /// </summary>
    public void PowerOver()
    {
        if (bPowerControl == true)
        {
            BarrierGame.transform.localPosition = new Vector3(Hero2dAniSprite.gameObject.transform.localPosition.x, Hero2dAniSprite.gameObject.transform.localPosition.y, -1.5f);
            BarrierGame.GetComponent<UISprite>().alpha = fBarrierAlpha;

            if (fPowerControl < 1.5f)
            {
                Hero2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = false;
                
                if (fBarrierAlpha < 1.0f)
                {
                    fBarrierAlpha += Time.deltaTime*2;
                }

                if (fBarrierAlpha >= 1.0f)
                {
                    fBarrierAlpha = 1.0f;
                }

                fPowerControl += Time.deltaTime;
            }

            if (fPowerControl >= 1.5f)
            {
                if (fBarrierAlpha > 0.0f)
                {
                    fBarrierAlpha -= Time.deltaTime*2;
                }

                if (fBarrierAlpha <= 0)
                {
                    fBarrierAlpha = 0;
                    Hero2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = true;
                    fPowerControl = 0;
                    BarrierGame.transform.localPosition = new Vector3(800, 600, -1.5f);
                    bPowerControl = false;
                }
            }
        }
    }

    /// <summary>
    /// ��� �Լ�
    /// </summary>
    public void HeroDeath()
    {
        Hero2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
        Hero2dAniSprite.Play("Hero_Death");
        bPlayerAlive = false;
        HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "EndPopupPrefab", "", "");
        bTimeMng = false;
        Time.timeScale = 0;
        GameObject.Find("JoyStick").GetComponent<SphereCollider>().enabled = false;
    }

    /// <summary>
    /// ���̺� ���� ��ü �� ���� �Լ�
    /// </summary>
    public void WaveMonster()
    {
        switch (nWaveNum)
        {
            case 1:
                nSlimeControl    =  5;
                nPieControl      =  0;
                nYogurtControl   =  0;
                nIcecreamControl =  0;
                nClearNum        =  5;
                break;

            case 2:
                nSlimeControl    = 10;
                nPieControl      =  0;
                nYogurtControl   =  0;
                nIcecreamControl =  0;
                nClearNum        = 10;
                break;

            case 3:
                nSlimeControl    = 10;
                nPieControl      =  5;
                nYogurtControl   =  0;
                nIcecreamControl =  0;
                nClearNum        = 15;
                break;

            case 4:
                nSlimeControl    =  7;
                nPieControl      =  7;
                nYogurtControl   =  0;
                nIcecreamControl =  0;
                nClearNum        = 14;
                break;

            case 5:
                nSlimeControl    = 10;
                nPieControl      = 10;
                nYogurtControl   =  0;
                nIcecreamControl =  0;
                nClearNum        = 20;
                break;

            case 6:
                nSlimeControl    = 10;
                nPieControl      =  5;
                nYogurtControl   =  2;
                nIcecreamControl =  0;
                nClearNum        = 17;
                break;

            case 7:
                nSlimeControl    =  5;
                nPieControl      =  8;
                nYogurtControl   =  3;
                nIcecreamControl =  0;
                nClearNum        = 16;
                break;

            case 8:
                nSlimeControl    = 15;
                nPieControl      =  5;
                nYogurtControl   =  2;
                nIcecreamControl =  3;
                nClearNum        = 25;
                break;

            case 9:
                nSlimeControl    =  5;
                nPieControl      =  8;
                nYogurtControl   =  3;
                nIcecreamControl =  5;
                nClearNum        = 21;
                break;

            case 10:
                nSlimeControl    = 30;
                nPieControl      = 20;
                nYogurtControl   = 10;
                nIcecreamControl = 15;
                nClearNum        = 75;
                break;
        }
    }
}