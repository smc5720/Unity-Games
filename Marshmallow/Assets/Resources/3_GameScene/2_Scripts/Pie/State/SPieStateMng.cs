using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 파이 상태
/// </summary>
public enum E_PIE_MOTION_STATE
{
    E_PI_STAND,             // 0 서있기 상태
    E_PI_RIGHT_MOVE,        // 1 오른쪽 뛰기 상태
    E_PI_LEFT_MOVE,         // 2 왼쪽 뛰기 상태
    E_PI_RIGHT_DAMAGE,      // 3 오른쪽 피격 상태
    E_PI_LEFT_DAMAGE,       // 4 왼쪽 피격 상태
    E_PI_RIGHT_DEATH,       // 5 오른쪽 죽음 상태
    E_PI_LEFT_DEATH,        // 6 왼쪽 죽음 상태
    E_PI_MAX                // 7 총 상태
}

//! 키 눌렸을때 정보 저장
public enum E_PIE_KEY_STATE
{
    E_PI_KEY_RIGHT,      // 0 Left key 눌림
    E_PI_KEY_LEFT,       // 1 Right key 눌림
    E_PI_KEY_DAMAGE,     // 2 Damage key 눌림
    E_PI_KEY_DEATH,      // 3 Death key 눌림
    E_PI_KEY_MAX         // 4 총 상태
}


/// <summary>
/// 파이 상태 메니져 클래스
/// </summary>
public class SPieStateMng : HScene
{
    /// <summary>
    /// 상태
    /// </summary>
    public int[,] nMotionTableArrary = new int[,]
    {  
        //       0                  1                  2                  3                  4
        //[E_PI_KEY_RIGHT]   [E_PI_KEY_LEFT]   [E_PI_KEY_DAMAGE]   [E_PI_KEY_DEATH]        [CALL]
                {0,                 0,                 0,                 0,                 0},     // 0 E_PI_STAND
                {1,                 0,                 0,                 0,                 1},     // 1 E_PI_RIGHT_MOVE
                {0,                 1,                 0,                 0,                 2},     // 2 E_PI_LEFT_MOVE
                {1,                 0,                 1,                 0,                 3},     // 3 E_PI_RIGHT_DAMAGE
                {0,                 1,                 1,                 0,                 4},     // 4 E_PI_LEFT_DAMAGE
                {1,                 0,                 1,                 1,                 5},     // 5 E_PI_RIGHT_DEATH
                {0,                 1,                 1,                 1,                 6},     // 6 E_PI_LEFT_DEATH
    };

    /// <summary>
    /// 키 상태 실시간 저장변수
    /// </summary>
    public int[] nKeyStatesArrary = new int[(int)E_PIE_KEY_STATE.E_PI_KEY_MAX];


    /// <summary>
    /// 파이 방향 저장 변수
    /// </summary>
    public E_PIE_KEY_STATE eDir = E_PIE_KEY_STATE.E_PI_KEY_RIGHT;

    /// <summary>
    /// 파이 유무 확인 변수
    /// </summary>
    public bool bIsAlive;

    /// <summary>
    /// 파이 이동 속도
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// 파이 관리
    /// </summary>
    public tk2dAnimatedSprite Pie2dAniSprite = null;

    /// <summary>
    /// 파이 체력 : 10
    /// </summary>
    public float fPieHP;

    /// <summary>
    /// 파이 주인공 좌표 추적 변수
    /// </summary>
    public Vector3 PieCharVec3;

    /// <summary>
    /// 파이 이속 관련 변수
    /// </summary>
    public float fPieSpeed;

    /// <summary>
    /// 파이 총알 연사 속도 조절 변수
    /// </summary>
    public float fBullet;

    /// <summary>
    /// 파이 총알 타이머 변수
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
        ChangeScene("SPieStand");
        fPieHP = 10.0f;
        fPieSpeed = 2.0f;
        fBullet = 0;
        fBulletTimer = 2.0f;
    }

    void Update()
    {
        // [주의하삼]부모 업데이트 호출^^ 이거 안해주면 부모쪽 Update가 실행안되요^^
        base.Update();

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

        // 0 E_PI_STAND   (HStandState)  서있는 상태입니다.
        ChangeScene(nMotionTableArrary[0, 0]);
    }

    /// <summary>
    /// 파이 방향 변경
    /// </summary>
    public void ChangeCharDir(E_PIE_KEY_STATE eKeyState)
    {
        Vector3 DirVec = transform.parent.localScale;

        switch (eKeyState)
        {
            case E_PIE_KEY_STATE.E_PI_KEY_LEFT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.parent.localScale = DirVec;
                eDir = E_PIE_KEY_STATE.E_PI_KEY_LEFT;
                break;

            case E_PIE_KEY_STATE.E_PI_KEY_RIGHT:
                if (DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.parent.localScale = DirVec;
                eDir = E_PIE_KEY_STATE.E_PI_KEY_RIGHT;
                break;
        }
    }

    /// <summary>
    /// 파이 모션 변경
    /// </summary>
    public void ChangeCharMotion(string sMotionName)
    {
        if (Pie2dAniSprite.CurrentClip.name != sMotionName)
            Pie2dAniSprite.Play(sMotionName);
    }


    public void LeftMove()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_LEFT] = 1;
    }

    public void LeftStop()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_LEFT] = 0;
    }

    public void RightMove()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_RIGHT] = 1;
    }

    public void RightStop()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_RIGHT] = 0;
    }

    public void DamageHit()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_DAMAGE] = 1;
    }

    public void DamageOut()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_DAMAGE] = 0;
    }

    public void Death()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_DEATH] = 1;
    }

    public void Alive()
    {
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_LEFT] = 0;
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_RIGHT] = 0;
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_DAMAGE] = 0;
        nKeyStatesArrary[(int)E_PIE_KEY_STATE.E_PI_KEY_DEATH] = 0;
    }
}
