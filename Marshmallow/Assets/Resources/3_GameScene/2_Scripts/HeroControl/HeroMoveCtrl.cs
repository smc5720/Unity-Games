using UnityEngine;
using System.Collections;

public class HeroMoveCtrl : MonoBehaviour
{
    /// <summary>
    /// ĳ���� �̵� �ӵ�
    /// </summary>
    public float fcharMoveSpeed = 1.0f;

    /// <summary>
    /// ĳ���� ����
    /// </summary>
    public tk2dAnimatedSprite Hero2dAniSprite = null;

    /// <summary>
    /// �� ��ũ�� �Ŵ���
    /// </summary>
    public HScrollMng ScrollMng = null;

    /// <summary>
    /// ĳ���� ���� ���/����
    /// -1 ~ 1������ ���� ���ɴϴ�.
    /// </summary>
    private float fDir = 0.0f;

    /// <summary>
    /// ĳ���� ���� enum
    /// </summary>
    private E_H_DIR E_CharDir = E_H_DIR.E_RIGHT;

    /// <summary>
    /// UI��ư Ŭ�� ���� true/false
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
    /// ĳ���� ��ġ �� ���� ������Ʈ
    /// </summary>
    void HeroUpdate()
    {
        // ĳ���� ���� ����
        CheckDir();

#if UNITY_EDITOR
        fDir = Input.GetAxis("Horizontal");
#endif

        // UI ������
        //if(bBtnPress)
        //    GetPressGetAxis();

        // ��ũ��
        ScrollMng.DoScroll(new Vector2(fDir * fcharMoveSpeed * Time.deltaTime, 0.0f));

        // ĳ���� ��� ����
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
    /// ���� ĳ������ ������ üũ�ϴ� �Լ�
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
    /// ĳ���� ���� ����
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
    /// ĳ���� ��� ����
    /// </summary>
    void CharMotionChange()
    {
        float fTemp = Mathf.Abs(fDir);
        
        if(fTemp > 0.0f)
        {
            // 0.0f���� ũ�ٴ� ���� �����δٴ� ��
            if (Hero2dAniSprite.CurrentClip.name != "Hero_Move")
                Hero2dAniSprite.Play("Hero_Move");
        }
        else
        {
            // �ȿ����̰� ���ִٴ� ��
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
    /// �⺻ �浹 ó���Դϴ� Trigger����� �ƴմϴ�
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}

