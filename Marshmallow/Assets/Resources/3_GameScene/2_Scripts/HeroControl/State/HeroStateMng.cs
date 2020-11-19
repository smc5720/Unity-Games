using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 캐릭터 상태
/// </summary>
public enum E_CHAR_MOTION_STATE
{
    E_CH_STAND,            // 0 서있기 상태
    E_CH_RIGHT_RUN,        // 1 오른쪽 뛰기 상태
    E_CH_LEFT_RUN,         // 2 왼쪽 뛰기 상태
    E_CH_UP_RUN,           // 3 위쪽 뛰기 상태
    E_CH_DOWN_RUN,         // 4 아래쪽 뛰기 상태
    E_CH_RIGHTUP_RUN,      // 5 오른쪽 위로 뛰기 상태
    E_CH_LEFTUP_RUN,       // 6 왼쪽 위로 뛰기 상태
    E_CH_RIGHTDOWN_RUN,    // 7 오른쪽 아래로 뛰기 상태
    E_CH_LEFTDOWN_RUN,     // 8 왼쪽 아래로 뛰기 상태
    E_CH_STAND_ATTACK,     // 9 서있기 상태
    E_CH_RIGHT_ATTACK,     // 10 오른쪽 공격 상태
    E_CH_LEFT_ATTACK,      // 11 왼쪽 공격 상태
    E_CH_UP_ATTACK,        // 12 위쪽 공격 상태
    E_CH_DOWN_ATTACK,      // 13 아래쪽 공격 상태
    E_CH_RIGHTUP_ATTACK,   // 14 오른쪽 위로 공격 상태
    E_CH_LEFTUP_ATTACK,    // 15 왼쪽 위로 공격 상태
    E_CH_RIGHTDOWN_ATTACK, // 16 오른쪽 아래로 공격 상태
    E_CH_LEFTDOWN_ATTACK,  // 17 왼쪽 아래로 공격 상태
    E_CH_MAX               // 18 총 상태
}

//! 키 눌렸을때 정보 저장
public enum E_CHAR_KEY_STATE
{
    E_CH_KEY_RIGHT,      // 0 Left Key 눌림
    E_CH_KEY_LEFT,       // 1 Right key 눌림
    E_CH_KEY_UP,         // 2 Up Key 눌림
    E_CH_KEY_DOWN,       // 3 Down Key 눌림
    E_CH_KEY_ATTACK,     // 4 Attadk Key 눌림
    E_CH_KEY_RIGHT_UP,   // 5 Right Up Key 눌림
    E_CH_KEY_LEFT_UP,    // 6 Left Up Key 눌림
    E_CH_KEY_RIGHT_DOWN, // 7 Right Down Key 눌림
    E_CH_KEY_LEFT_DOWN,  // 8 Left Down Key 눌림
    E_CH_KEY_MAX         // 9 총 상태
}


/// <summary>
/// 캐릭터 상태 메니져 클래스
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

    // ----------------------------------시스템-----------------------------------------------

    /// <summary>
    /// 상태
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
    /// 키 상태 실시간 저장변수
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_CHAR_KEY_STATE.E_CH_KEY_MAX];


    /// <summary>
    /// 캐릭터 방향 저장 변수
    /// </summary>
    public E_CHAR_KEY_STATE eDir = E_CHAR_KEY_STATE.E_CH_KEY_RIGHT;


    /// <summary>
    /// 캐릭터 이동 속도
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// 캐릭터 관리
    /// </summary>
    public tk2dAnimatedSprite Hero2dAniSprite = null;

    /// <summary>
    /// 시간 변수(float)
    /// </summary>
    public float fTimer;

    /// <summary>
    /// 시간 변수(int)
    /// </summary>
    public int nTimer;

    /// <summary>
    /// 카운트다운 프리팹 생성 관리 변수
    /// </summary>
    public int nStartCount;

    /// <summary>
    /// 발사체 방향관리: x
    /// </summary>
    public float fcharx;

    /// <summary>
    /// 발사체 방향관리: y
    /// </summary>
    public float fchary;

    /// <summary>
    /// 발사체 데미지 관리
    /// </summary>
    public float fBulletDamage;

    /// <summary>
    /// 발사체 총 연사 속도 변수
    /// </summary>
    public float fBulletSpeed;

    /// <summary>
    /// 발사체 연사 속도 체크 변수
    /// </summary>
    public float fBulletCheck;

    /// <summary>
    /// 전체 스코어
    /// </summary>
    public int nScore;

    /// <summary>
    /// 전체 재화
    /// </summary>
    public int nMoney;

    /// <summary>
    /// 플레이어 체력 변수
    /// </summary>
    public float fHeartGage;

    /// <summary>
    /// 플레이어 조이스틱 제한 변수
    /// </summary>
    public bool bPlayerAlive;

    /// <summary>
    /// 총알 배열 관리 변수
    /// </summary>
    public int nBulletNum;

    /// <summary>
    /// 히어로 속도 조절 변수
    /// </summary>
    public float fHeroSpeed;

    /// <summary>
    /// 총 소요 시간 변수
    /// </summary>
    public float fFullTime;

    /// <summary>
    /// 시간 정지 관리 변수
    /// </summary>
    public bool bTimeMng;

    /// <summary>
    /// 주인공 벡터
    /// </summary>
    public Vector3 CharVector3;

    /// <summary>
    /// 자동 발사(Auto-Fire) 총알 벡터
    /// </summary>
    public Vector3 AutoFireVec3;

    /// <summary>
    /// 웨이브 클리어 조건 변수
    /// </summary>
    public int nClearNum;

    /// <summary>
    /// 웨이브 총 변수
    /// </summary>
    public int nWaveNum;

    /// <summary>
    /// 현재 몬스터 샤낭 수
    /// </summary>
    public int nHunted;

    /// <summary>
    /// 원가 (100$)
    /// </summary>
    public int nAOriPrize;

    /// <summary>
    /// 원가 (150$)
    /// </summary>
    public int nBOriPrize;

    /// <summary>
    /// 원가 (180$)
    /// </summary>
    public int nCOriPrize;

    /// <summary>
    /// 스피드 레벨
    /// </summary>
    public int nSpeedLevel;

    /// <summary>
    /// 스피드 아이템 현 가격
    /// </summary>
    public int nSpeedPrize;

    /// <summary>
    /// 데미지 레벨
    /// </summary>
    public int nPowerLevel;

    /// <summary>
    /// 데미지 강화 아이템 현 가격
    /// </summary>
    public int nPowerPrize;

    /// <summary>
    /// 생명력 흡수량 레벨
    /// </summary>
    public int nDrainLevel;

    /// <summary>
    /// 생명력 흡수량 현 가격
    /// </summary>
    public int nDrainPrize;

    /// <summary>
    /// 생명력 흡수 확률 레벨
    /// </summary>
    public int nDPercentLevel;

    /// <summary>
    /// 생명력 흡수 확률 현 가격
    /// </summary>
    public int nDPercentPrize;

    /// <summary>
    /// 치명타 확률 레벨
    /// </summary>
    public int nCriticalLevel;

    /// <summary>
    /// 치명타 확률 강화 아이템 현 가격
    /// </summary>
    public int nCriticalPrize;

    /// <summary>
    /// 카운트다운 프리팹 좌표 조절 벡터 (-315, 130, -16)
    /// </summary>
    public Vector3 CountPosVec3;

    /// <summary>
    /// [0, 2~9] 카운트다운 프리팹 스케일 조절 벡터 (87, 102, 1)
    /// </summary>
    public Vector3 CountScaVec3;

    /// <summary>
    /// [10] 카운트다운 프리팹 스케일 조절 벡터 (127, 103, 1)
    /// </summary>
    public Vector3 CountSca2Vec3;

    /// <summary>
    /// [1] 카운트다운 프리팹 스케일 조절 벡터 (38, 102, 1)
    /// </summary>
    public Vector3 CountSca3Vec3;

    /// <summary>
    /// 전체 몬스터 사냥 변수
    /// </summary>
    public int nMonsterKilled;

    /// <summary>
    /// 전체 총 재화 변수
    /// </summary>
    public int nFullMoney;

    /// <summary>
    /// 생명력 흡수량 변수
    /// </summary>
    public float fDrain;

    /// <summary>
    /// 생명력 흡수량 표기용 변수
    /// </summary>
    public int nDrain;

    /// <summary>
    /// 생명력 흡수 확률 변수
    /// </summary>
    public int nDPercent;

    /// <summary>
    /// 크리티컬 확률 변수
    /// </summary>
    public float fCriticalDmg;

    /// <summary>
    /// 크리티컬 확률 표기용 변수
    /// </summary>
    public int nCritical;

    /// <summary>
    /// 몬스터 조절 bool형 변수
    /// </summary>
    public bool bisMonster;

    /// <summary>
    /// 히어로 이동 제어기 관리 변수
    /// </summary>
    public float fHeroControl;

    /// <summary>
    /// 무적 시간 컨트롤러
    /// </summary>
    public float fPowerControl;

    /// <summary>
    /// 무적 시간 bool형 컨트롤러
    /// </summary>
    public bool bPowerControl;

    /// <summary>
    /// 무적 배리어 알파값
    /// </summary>
    public float fBarrierAlpha = 0;

    /// <summary>
    /// 슬라임 개채 조절 변수
    /// </summary>
    public int nSlimeControl;

    /// <summary>
    /// 파이 개채 조절 변수
    /// </summary>
    public int nPieControl;

    /// <summary>
    /// 요구르트 개채 조절 변수
    /// </summary>
    public int nYogurtControl;

    /// <summary>
    /// 아이스크림 개채 조절 변수
    /// </summary>
    public int nIcecreamControl;

    // ----------------------------------시스템-----------------------------------------------

    // ----------------------------------오브젝트---------------------------------------------

    /// <summary>
    /// 주인공 HP바
    /// </summary>
    public GameObject HeartBarGame;

    /// <summary>
    /// 주인공 무적시간 배리어
    /// </summary>
    public GameObject BarrierGame;

    // ----------------------------------오브젝트---------------------------------------------

    // ----------------------------------슬라임-----------------------------------------------

    /// <summary>
    /// 슬라임 상태매니져
    /// </summary>
    public SSlimeStateMng SlimeMng;

    /// <summary>
    /// 슬라임 유무 관련 변수
    /// </summary>
    public bool bisSlime;

    /// <summary>
    /// 슬라임 좌표 확인 변수
    /// </summary>
    public int nCheckForSlime;

    /// <summary>
    /// 슬라임 x좌표
    /// </summary>
    public float fSlimePosX;

    /// <summary>
    /// 슬라임 y좌표
    /// </summary>
    public float fSlimePosY;

    /// <summary>
    /// 슬라임 벡터
    /// </summary>
    public Vector3 SlimeVector3;

    /// <summary>
    /// 슬라임 생성 제한 int형 변수
    /// </summary>
    public int nSlimeNum;

    /// <summary>
    /// 슬라임 공격력 변수
    /// </summary>
    public float fSlimeDamage;

    public float fSlimeTimer;

    // ----------------------------------슬라임-----------------------------------------------

    // ----------------------------------파이-----------------------------------------------

    /// <summary>
    /// 파이 상태매니져
    /// </summary>
    public SPieStateMng PieMng;

    /// <summary>
    /// 파이 유무 관련 변수
    /// </summary>
    public bool bisPie;

    /// <summary>
    /// 파이 좌표 확인 변수
    /// </summary>
    public int nCheckForPie;

    /// <summary>
    /// 파이 x좌표
    /// </summary>
    public float fPiePosX;

    /// <summary>
    /// 파이 y좌표
    /// </summary>
    public float fPiePosY;

    /// <summary>
    /// 파이 벡터
    /// </summary>
    public Vector3 PieVector3;

    /// <summary>
    /// 파이 생성 제한 int형 변수
    /// </summary>
    public int nPieNum;

    /// <summary>
    /// 파이 공격력 변수
    /// </summary>
    public float fPieDamage;

    public float fPieTimer;

    // ----------------------------------파이-----------------------------------------------

    // ----------------------------------요구르트-----------------------------------------------

    /// <summary>
    /// 요구르트 상태매니져
    /// </summary>
    public SYogurtStateMng YogurtMng;

    /// <summary>
    /// 요구르트 유무 관련 변수
    /// </summary>
    public bool bisYogurt;

    /// <summary>
    /// 요구르트 좌표 확인 변수
    /// </summary>
    public int nCheckForYogurt;

    /// <summary>
    /// 요구르트 x좌표
    /// </summary>
    public float fYogurtPosX;

    /// <summary>
    /// 요구르트 y좌표
    /// </summary>
    public float fYogurtPosY;

    /// <summary>
    /// 요구르트 벡터
    /// </summary>
    public Vector3 YogurtVector3;

    /// <summary>
    /// 요구르트 생성 제한 int형 변수
    /// </summary>
    public int nYogurtNum;

    /// <summary>
    /// 요구르트 공격력 변수
    /// </summary>
    public float fYogurtDamage;

    public float fYogurtTimer;

    // ----------------------------------요구르트-----------------------------------------------

    // ----------------------------------아이스크림-----------------------------------------------

    /// <summary>
    /// 아이스크림 상태매니져
    /// </summary>
    public SIcecreamStateMng IcecreamMng;

    /// <summary>
    /// 아이스크림 유무 관련 변수
    /// </summary>
    public bool bisIcecream;

    /// <summary>
    /// 아이스크림 좌표 확인 변수
    /// </summary>
    public int nCheckForIcecream;

    /// <summary>
    /// 아이스크림 x좌표
    /// </summary>
    public float fIcecreamPosX;

    /// <summary>
    /// 아이스크림 y좌표
    /// </summary>
    public float fIcecreamPosY;

    /// <summary>
    /// 아이스크림 벡터
    /// </summary>
    public Vector3 IcecreamVector3;

    /// <summary>
    /// 아이스크림 생성 제한 int형 변수
    /// </summary>
    public int nIcecreamNum;

    /// <summary>
    /// 아이스크림 공격력 변수
    /// </summary>
    public float fIcecreamDamage;

    public float fIcecreamTimer;

    // ----------------------------------아이스크림-----------------------------------------------

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
    /// 시작 함수
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
        // [주의하삼]부모 업데이트 호출^^ 이거 안해주면 부모쪽 Update가 실행안되요^^
        base.Update();

        isMonster();

        WaveFunc();

        HPGageMng();

        PowerOver();

        ChangeAutoState();
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

        // 0 E_CH_STAND   (HStandState)  서있는 상태입니다.
        ChangeScene(nMotionTableArrary[0, 0]);
    }

    /// <summary>
    /// 캐릭터 방향 변경
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
    /// 캐릭터 모션 변경
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
    /// 몬스터 생성 유무 관리 함수
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
    /// 체력바 관리 함수
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
    /// 타이머 관리 함수
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
    /// 카운트다운 관리 함수
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
    /// 슬라임 생성 함수
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
    /// 파이 생성 함수
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
    /// 요구르트 생성 함수
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
    /// 아이스크림 생성 함수
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
    /// 웨이브 조절 및 클리어 조건 변수 조절 함수
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
    /// 슬라임 좌표 랜덤 설정 함수
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
    /// 파이 좌표 랜덤 설정 함수
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
    /// 요구르트 좌표 랜덤 설정 함수
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
    /// 아이스크림 좌표 랜덤 설정 함수
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
    /// 무적시간 관리 함수
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
    /// 사망 함수
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
    /// 웨이브 몬스터 개체 수 조절 함수
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