using UnityEngine;
using System.Collections;

public class HeroMoveCtrl : MonoBehaviour
{
    /// <summary>
    /// 캐릭터 이동 속도
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// 캐릭터 관리
    /// </summary>
    public tk2dAnimatedSprite Hero2dAniSprite = null;

    /// <summary>
    /// 맵 스크롤 매니져
    /// </summary>
    public HScrollMng ScrollMng = null;

    /// <summary>
    /// 캐릭터 방향 양수/음수
    /// -1 ~ 1까지의 값이 들어옵니다.
    /// </summary>
    private float fDir = 0.0f;

    /// <summary>
    /// 캐릭터 방향 enum
    /// </summary>
    private E_H_DIR E_CharDir = E_H_DIR.E_RIGHT;

    /// <summary>
    /// UI버튼 클릭 유무 true/false
    /// </summary>
    private bool bBtnPress = false;
    private bool bBtnRelease = false;

   
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        HeroUpdate();
    }


    /// <summary>
    /// 캐릭터 위치 및 방향 업데이트
    /// </summary>
    void HeroUpdate()
    {
        // 캐릭터 방향 변경
        CheckDir();

#if UNITY_EDITOR
        fDir = Input.GetAxis("Horizontal");
#endif

        // UI 누를때
        //if(bBtnPress)
        //    GetPressGetAxis();

        // 스크롤
        ScrollMng.DoScroll(new Vector2(fDir * fcharMoveSpeed * Time.deltaTime, 0.0f));

        // 캐릭터 모션 변경
        CharMotionChange();
    }
   
    void GetPressGetAxis()
    {        
        switch (E_CharDir)
        {
            case E_H_DIR.E_RIGHT:
                Debug.Log(Time.deltaTime * 2.0f);
                fDir = Mathf.SmoothStep(fDir, 1.0f, Time.deltaTime * 2.0f);
                
                break;

            case E_H_DIR.E_LEFT:
                fDir = Mathf.SmoothStep(fDir, -1.0f, Time.deltaTime * 2.0f);
                break;
        }


        Debug.Log(fDir+"<-------------");
    }

    /// <summary>
    /// 현재 캐릭터의 방향을 체크하는 함수
    /// </summary>
    void CheckDir()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            E_CharDir = E_H_DIR.E_LEFT;
            CharDirChange();            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            E_CharDir = E_H_DIR.E_RIGHT;
            CharDirChange();
        }
#endif        
    }

    /// <summary>
    /// 캐릭터 방향 변경
    /// </summary>
    void CharDirChange()
    {
        Vector3 DirVec = transform.localScale;

        switch (E_CharDir)
        {
            case E_H_DIR.E_RIGHT:
                DirVec.x = Mathf.Abs(DirVec.x);
                transform.localScale = DirVec;
                break;

            case E_H_DIR.E_LEFT:
                if(DirVec.x > 0.0f)
                    DirVec.x = DirVec.x * -1.0f;
                transform.localScale = DirVec;
                break;
        }
    }

    /// <summary>
    /// 캐릭터 모션 변경
    /// </summary>
    void CharMotionChange()
    {
        float fTemp = Mathf.Abs(fDir);
        
        if(fTemp > 0.0f)
        {
            // 0.0f보다 크다는 말은 움직인다는 뜻
            if (Hero2dAniSprite.CurrentClip.name != "Hero_Move")
                Hero2dAniSprite.Play("Hero_Move");
        }
        else
        {
            // 안움직이고 서있다는 뜻
            if (Hero2dAniSprite.CurrentClip.name != "Hero_Stand")
                Hero2dAniSprite.Play("Hero_Stand");
        }
    }

        //void LeftBtnPress()
        //{
        //    bBtnPress = true;
        //    E_CharDir = E_H_DIR.E_LEFT;
        //    CharDirChange();       
        //}

        //void LeftBtnRelease()
        //{
        //    //bBtnPress = false;
        //}

        //void RightBtnPress()
        //{
        //    bBtnPress = true;
        //    E_CharDir = E_H_DIR.E_RIGHT;
        //    CharDirChange();
        //}

        //void RightBtnRelease()
        //{
        //    //bBtnPress = false;
        //}


    /// <summary>
    /// 기본 충돌 처리입니다 Trigger방식은 아닙니다
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}

