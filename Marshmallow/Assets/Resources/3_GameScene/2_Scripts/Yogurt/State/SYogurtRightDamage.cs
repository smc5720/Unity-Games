using UnityEngine;
using System.Collections;


/// <summary>
/// 요구르트 오른쪽 피격상태
/// </summary>
public class SYogurtRightDamage : HState
{
    public SYogurtStateMng YogurtMng;
    public override void Enter()
    {
        YogurtMng.ChangeCharDir(E_YOGURT_KEY_STATE.E_YO_KEY_RIGHT);
        YogurtMng.ChangeCharMotion("Yogurt_Move");
    }

    public override void Execute(float fDt)
    {
        YogurtMng.YogurtCharVec3 = HeroStateMng.I.CharVector3 - YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition;
        YogurtMng.YogurtCharVec3.Normalize();

        YogurtMng.Yogurt2dAniSprite.gameObject.rigidbody.velocity = new Vector3(YogurtMng.YogurtCharVec3.x / YogurtMng.fYogurtSpeed, YogurtMng.YogurtCharVec3.y / YogurtMng.fYogurtSpeed, YogurtMng.Yogurt2dAniSprite.gameObject.rigidbody.velocity.z);

        if (YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
        {
            YogurtMng.LeftMove();
            YogurtMng.RightStop();
        }

        if (HeroStateMng.I.bisMonster == false)
        {
            YogurtMng.Death();
        }
    }

    public override void Exit()
    {

    }
}