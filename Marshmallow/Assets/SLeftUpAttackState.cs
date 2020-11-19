using UnityEngine;
using System.Collections;

/// <summary>
/// 캐릭터 왼쪽 위로 공격상태
/// </summary>
public class SLeftUpAttackState : HState
{
    public override void Enter()
    {
        HeroStateMng.I.ChangeCharMotion("Hero_Attack");
    }

    public override void Execute(float fDt)
    {
        if (GameObject.Find("JoyStick").GetComponent<UIJoystick>().position.x != 0 || GameObject.Find("JoyStick").GetComponent<UIJoystick>().position.y != 0)
        {
            HeroStateMng.I.fcharx = GameObject.Find("JoyStick").GetComponent<UIJoystick>().position.x;
            HeroStateMng.I.fchary = GameObject.Find("JoyStick").GetComponent<UIJoystick>().position.y;
        }
        Vector3 cPos = new Vector3(HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x + 4.0f, HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.y - 8.0f, HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.z);
        Vector3 cSca = new Vector3(10, 10, 10);
        HeroStateMng.I.fBulletCheck += Time.deltaTime;
        if (HeroStateMng.I.fBulletCheck >= HeroStateMng.I.fBulletSpeed)
        {
            GameObject.Find("SBulletPrefab" + HeroStateMng.I.nBulletNum.ToString()).GetComponent<SBulletPrefab>().enabled = true;
            HeroStateMng.I.nBulletNum++;
            if (HeroStateMng.I.nBulletNum >= 11)
            {
                HeroStateMng.I.nBulletNum = 1;
            }
            HeroStateMng.I.fBulletCheck = 0;
        }
    }

    public override void Exit()
    {
        HeroStateMng.I.ChangeCharDir(E_CHAR_KEY_STATE.E_CH_KEY_LEFT_UP);
    }
}

