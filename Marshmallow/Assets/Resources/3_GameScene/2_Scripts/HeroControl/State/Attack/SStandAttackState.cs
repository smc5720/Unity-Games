using UnityEngine;
using System.Collections;


/// <summary>
/// 서서 공격하기 상태
/// </summary>
public class SStandAttackState : HState
{
    public GameObject JoyStickGame;
    UIJoystick vJoy;

    public override void Enter()
    {
        HeroStateMng.I.ChangeCharMotion("Hero_Attack");
    }

    public override void Execute(float fDt)
    {
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

    }

}
