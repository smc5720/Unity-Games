using UnityEngine;
using System.Collections;


/// <summary>
/// 슬라임 오른쪽 피격상태
/// </summary>
public class SSlimeRightDamage : HState
{
    public SSlimeStateMng SlimeMng;
    public override void Enter()
    {
        SlimeMng.ChangeCharDir(E_SLIME_KEY_STATE.E_SL_KEY_RIGHT);
        SlimeMng.ChangeCharMotion("Slime_Damage");
    }

    public override void Execute(float fDt)
    {
        SlimeMng.SlimeCharVec3 = HeroStateMng.I.CharVector3 - SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition;
        SlimeMng.SlimeCharVec3.Normalize();

        SlimeMng.Slime2dAniSprite.gameObject.rigidbody.velocity = new Vector3(SlimeMng.SlimeCharVec3.x / SlimeMng.fSlimeSpeed, SlimeMng.SlimeCharVec3.y / SlimeMng.fSlimeSpeed, SlimeMng.Slime2dAniSprite.gameObject.rigidbody.velocity.z);

        if (SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
        {
            SlimeMng.LeftMove();
            SlimeMng.RightStop();
        }

        if (!SlimeMng.Slime2dAniSprite.IsPlaying("Slime_Damage"))
        {
            SlimeMng.DamageOut();
        }

        if (HeroStateMng.I.bisMonster == false)
        {
            SlimeMng.Death();
        }
    }

    public override void Exit()
    {

    }
}