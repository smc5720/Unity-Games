using UnityEngine;
using System.Collections;


/// <summary>
/// 파이 왼쪽 피격상태
/// </summary>
public class SIcecreamLeftDamage : HState
{
    public SIcecreamStateMng IcecreamMng;
    public override void Enter()
    {
        IcecreamMng.ChangeCharDir(E_ICE_KEY_STATE.E_IC_KEY_LEFT);
        IcecreamMng.ChangeCharMotion("Icecream_Damage");
    }

    public override void Execute(float fDt)
    {
        IcecreamMng.IcecreamCharVec3 = HeroStateMng.I.CharVector3 - IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition;
        IcecreamMng.IcecreamCharVec3.Normalize();

        IcecreamMng.Icecream2dAniSprite.gameObject.rigidbody.velocity = new Vector3(IcecreamMng.IcecreamCharVec3.x / IcecreamMng.fIcecreamSpeed, IcecreamMng.IcecreamCharVec3.y / IcecreamMng.fIcecreamSpeed, IcecreamMng.Icecream2dAniSprite.gameObject.rigidbody.velocity.z);

        if (IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
        {
            IcecreamMng.RightMove();
            IcecreamMng.LeftStop();
        }

        if (!IcecreamMng.Icecream2dAniSprite.IsPlaying("Icecream_Damage"))
        {
            IcecreamMng.DamageOut();
        }

        if (HeroStateMng.I.bisMonster == false)
        {
            IcecreamMng.Death();
        }
    }

    public override void Exit()
    {

    }
}
