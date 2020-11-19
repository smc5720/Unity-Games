using UnityEngine;
using System.Collections;


/// <summary>
/// 슬라임 왼쪽 이동상태
/// </summary>
public class SSlimeLeftMove : HState
{
    public SSlimeStateMng SlimeMng;
    public override void Enter()
    {
        SlimeMng.ChangeCharDir(E_SLIME_KEY_STATE.E_SL_KEY_LEFT);
        SlimeMng.ChangeCharMotion("Slime_Move");
    }

    public override void Execute(float fDt)
    {
        SlimeMng.SlimeCharVec3 = HeroStateMng.I.CharVector3 - SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition;
        SlimeMng.SlimeCharVec3.Normalize();
        SlimeMng.Slime2dAniSprite.gameObject.rigidbody.velocity = new Vector3(SlimeMng.SlimeCharVec3.x / SlimeMng.fSlimeSpeed, SlimeMng.SlimeCharVec3.y / SlimeMng.fSlimeSpeed, SlimeMng.Slime2dAniSprite.gameObject.rigidbody.velocity.z);
        
        if (SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
        {
            SlimeMng.RightMove();
            SlimeMng.LeftStop();
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
