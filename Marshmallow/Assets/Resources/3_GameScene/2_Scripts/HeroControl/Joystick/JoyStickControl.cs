using UnityEngine;
using System.Collections;

public class JoyStickControl : MonoBehaviour {
    UIJoystick vJoy;
    Vector3 vPos;

	// Use this for initialization
	void Start () {
        vJoy = gameObject.GetComponent<UIJoystick>();
        vPos = HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        MapMaker();
        SetDirection();
	}

    void SetDirection()
    {
            if (-0.8 < vJoy.position.normalized.x && vJoy.position.normalized.x < 0.8 && 0.6 < vJoy.position.normalized.y)
            {
                HeroStateMng.I.ChangeCharDir(E_CHAR_KEY_STATE.E_CH_KEY_UP);
                HeroStateMng.I.ChangeCharMotion("Hero_Back");

                HeroStateMng.I.UpBtnPress();
                HeroStateMng.I.DownBtnRelease();
                HeroStateMng.I.LeftBtnRelease();
                HeroStateMng.I.RightBtnRelease();
            }

            if (-0.8 < vJoy.position.normalized.x && vJoy.position.normalized.x < 0.8 && -0.6 > vJoy.position.normalized.y)
            {
                HeroStateMng.I.ChangeCharDir(E_CHAR_KEY_STATE.E_CH_KEY_DOWN);
                HeroStateMng.I.ChangeCharMotion("Hero_Forward");

                HeroStateMng.I.UpBtnRelease();
                HeroStateMng.I.DownBtnPress();
                HeroStateMng.I.LeftBtnRelease();
                HeroStateMng.I.RightBtnRelease();
            }

            if (-0.6 <= vJoy.position.normalized.y && vJoy.position.normalized.y <= 0.6 && -0.8 >= vJoy.position.normalized.x)
            {
                HeroStateMng.I.ChangeCharDir(E_CHAR_KEY_STATE.E_CH_KEY_LEFT);
                HeroStateMng.I.ChangeCharMotion("Hero_Move");

                HeroStateMng.I.UpBtnRelease();
                HeroStateMng.I.DownBtnRelease();
                HeroStateMng.I.LeftBtnPress();
                HeroStateMng.I.RightBtnRelease();
            }

            if (-0.6 <= vJoy.position.normalized.y && vJoy.position.normalized.y <= 0.6 && 0.8 <= vJoy.position.normalized.x)
            {
                HeroStateMng.I.ChangeCharDir(E_CHAR_KEY_STATE.E_CH_KEY_RIGHT);
                HeroStateMng.I.ChangeCharMotion("Hero_Move");

                HeroStateMng.I.UpBtnRelease();
                HeroStateMng.I.DownBtnRelease();
                HeroStateMng.I.LeftBtnRelease();
                HeroStateMng.I.RightBtnPress();
            }

            if (vJoy.position.normalized.x == 0 && vJoy.position.normalized.y == 0)
            {
                HeroStateMng.I.ChangeCharMotion("Hero_Stand");

                HeroStateMng.I.UpBtnRelease();
                HeroStateMng.I.DownBtnRelease();
                HeroStateMng.I.LeftBtnRelease();
                HeroStateMng.I.RightBtnRelease();
            }
    }

    void MapMaker()
    {
        if (HeroStateMng.I.bPlayerAlive == true)
        {
            vPos = HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;
            HeroStateMng.I.Hero2dAniSprite.gameObject.rigidbody.velocity = new Vector3(vJoy.position.x * HeroStateMng.I.fHeroSpeed, vJoy.position.y * HeroStateMng.I.fHeroSpeed, HeroStateMng.I.Hero2dAniSprite.gameObject.rigidbody.velocity.z);
            if (vPos.y >= 215)
            {
                HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(vPos.x, 215, vPos.z);
                if (vPos.x >= 390)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(390, 215, vPos.z);
                }

                else if (vPos.x <= -390)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(-390, 215, vPos.z);
                }
            }

            if (vPos.y <= -215)
            {
                HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(vPos.x, -215, vPos.z);
                if (vPos.x >= 390)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(390, -215, vPos.z);
                }

                else if (vPos.x <= -390)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(-390, -215, vPos.z);
                }
            }

            if (vPos.x >= 390)
            {
                HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(390, vPos.y, vPos.z);
                if (vPos.y >= 215)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(390, 215, vPos.z);
                }

                else if (vPos.y <= -215)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(390, -215, vPos.z);
                }
            }

            if (vPos.x <= -390)
            {
                HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(-390, vPos.y, vPos.z);
                if (vPos.y >= 215)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(-390, 215, vPos.z);
                }

                else if (vPos.y <= -215)
                {
                    HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition = new Vector3(-390, -215, vPos.z);
                }
            }
        }
    }
}