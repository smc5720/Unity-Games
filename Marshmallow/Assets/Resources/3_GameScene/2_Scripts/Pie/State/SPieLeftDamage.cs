using UnityEngine;
using System.Collections;


/// <summary>
/// 파이 왼쪽 피격상태
/// </summary>
public class SPieLeftDamage : HState
{
    public SPieStateMng PieMng;
    public override void Enter()
    {
        PieMng.ChangeCharDir(E_PIE_KEY_STATE.E_PI_KEY_LEFT);
        PieMng.ChangeCharMotion("Pie_Damage");
    }

    public override void Execute(float fDt)
    {
        PieMng.PieCharVec3 = HeroStateMng.I.CharVector3 - PieMng.Pie2dAniSprite.gameObject.transform.localPosition;
        PieMng.PieCharVec3.Normalize();

        PieMng.Pie2dAniSprite.gameObject.rigidbody.velocity = new Vector3(PieMng.PieCharVec3.x / PieMng.fPieSpeed, PieMng.PieCharVec3.y / PieMng.fPieSpeed, PieMng.Pie2dAniSprite.gameObject.rigidbody.velocity.z);

        if (PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
        {
            PieMng.RightMove();
            PieMng.LeftStop();
        }

        if (!PieMng.Pie2dAniSprite.IsPlaying("Pie_Damage"))
        {
            PieMng.DamageOut();
        }

        if (HeroStateMng.I.bisMonster == false)
        {
            PieMng.Death();
        }
    }

    public override void Exit()
    {

    }
}
