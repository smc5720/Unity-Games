using UnityEngine;
using System.Collections;
using SmoothMoves;

/// <summary>
/// 케릭터 움직임, 애니메이션 제어
/// 위치 : MoveControlPrefab
/// </summary>
public class CharacterControl : MonoBehaviour 
{
    /// <summary>
    /// 버튼 상태
    /// </summary>
    public enum E_STATE_BUTTON
    {
        NONE = 0,
        CLICK,
        PRESS,
        RELEASE,
    };

    /// <summary>
    /// 왼쪽 버튼 상태
    /// </summary>
    public E_STATE_BUTTON eLeftBtn;

    /// <summary>
    /// 오른쪽 버튼 상태
    /// </summary>
    public E_STATE_BUTTON eRightBtn;

    /// <summary>
    /// 케릭터 게임오브젝트
    /// </summary>
    public GameObject CharacterGame;

    /// <summary>
    /// 케릭터 본애니메이션
    /// </summary>
    private BoneAnimation CharacterBoneAni;

	// Use this for initialization
	void Start () 
    {
        eLeftBtn = E_STATE_BUTTON.NONE;
        eRightBtn = E_STATE_BUTTON.NONE;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (CharacterGame == null)
        {
            CharacterGame = GameObject.Find("CharacterPrefab(Clone)");
            if (CharacterGame != null)
            {
                CharacterBoneAni = CharacterGame.GetComponent<BoneAnimation>();
            }
            return;
        }

        switch (eLeftBtn)
        {
            case E_STATE_BUTTON.PRESS:
                CharacterGame.transform.Translate(Vector3.left * 5.0f);
                break;
        }

        switch (eRightBtn)
        {
            case E_STATE_BUTTON.PRESS:
                CharacterGame.transform.Translate(Vector3.left * 5.0f);
                break;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CharacterBoneAni.SwapTexture("WeaponsAtlas", "rolling_pin", "WeaponsAtlas", "knife");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CharacterBoneAni.SwapTexture("WeaponsAtlas", "rolling_pin", "WeaponsAtlas", "cleaver");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CharacterBoneAni.RestoreTextures();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //!< Mix 애니메이션
            CharacterBoneAni.Play("Grooggy");
        }
	}

    ///// <summary>
    ///// 왼쪽 버튼 클릭
    ///// </summary>
    //void LeftBtnClick()
    //{
    //    Debug.Log("LeftBtnClick() in");
    //}

    ///// <summary>
    ///// 왼쪽 버튼 누르고 있을때
    ///// </summary>
    //void LeftBtnPress()
    //{
    //    Debug.Log("LeftBtnPress() in");

    //    eLeftBtn = E_STATE_BUTTON.PRESS;

    //    //HeroBoneAni["Walk"].speed = 1.0f;
    //    CharacterBoneAni.Play("Walk");
    //    CharacterGame.transform.localEulerAngles = Vector3.zero;
    //}

    ///// <summary>
    ///// 왼쪽 버튼 띄었을때
    ///// </summary>
    //void LeftBtnRelease()
    //{
    //    Debug.Log("LeftBtnRelease() in");

    //    eLeftBtn = E_STATE_BUTTON.RELEASE;

    //    CharacterBoneAni.Play("Stand");
    //}

    ///// <summary>
    ///// 오른쪽 버튼 클릭했을때
    ///// </summary>
    //void RightBtnClick()
    //{
    //    Debug.Log("RightBtnClick() in");
    //}

    ///// <summary>
    ///// 오른쪽 버튼 누르고 있을때
    ///// </summary>
    //void RightBtnPress()
    //{
    //    Debug.Log("RightBtnPress() in");

    //    eRightBtn = E_STATE_BUTTON.PRESS;

    //    //HeroBoneAni["Walk"].speed = 2.0f;
    //    CharacterBoneAni.CrossFade("Walk");
    //    CharacterGame.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
    //}

    ///// <summary>
    ///// 오른쪽 버튼 띄었을때
    ///// </summary>
    //void RightBtnRelease()
    //{
    //    Debug.Log("RightBtnRelease() in");

    //    eRightBtn= E_STATE_BUTTON.RELEASE;

    //    CharacterBoneAni.CrossFade("Stand");        
    //}
}
