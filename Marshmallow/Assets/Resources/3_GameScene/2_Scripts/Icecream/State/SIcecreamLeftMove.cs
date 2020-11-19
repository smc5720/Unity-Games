using UnityEngine;
using System.Collections;


/// <summary>
/// 파이 왼쪽 이동상태
/// </summary>
public class SIcecreamLeftMove : HState
{
    public SIcecreamStateMng IcecreamMng;
    public override void Enter()
    {
        IcecreamMng.ChangeCharDir(E_ICE_KEY_STATE.E_IC_KEY_LEFT);
        IcecreamMng.ChangeCharMotion("Icecream_Move");
    }

    public override void Execute(float fDt)
    {
        if (IcecreamMng.fBullet < IcecreamMng.fBulletTimer)
        {
            IcecreamMng.IcecreamCharVec3 = HeroStateMng.I.CharVector3 - IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition;
            IcecreamMng.IcecreamCharVec3.Normalize();
            IcecreamMng.Icecream2dAniSprite.gameObject.rigidbody.velocity = new Vector3(IcecreamMng.IcecreamCharVec3.x / IcecreamMng.fIcecreamSpeed, IcecreamMng.IcecreamCharVec3.y / IcecreamMng.fIcecreamSpeed, IcecreamMng.Icecream2dAniSprite.gameObject.rigidbody.velocity.z);

            if (IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                IcecreamMng.RightMove();
                IcecreamMng.LeftStop();
            }

            if (HeroStateMng.I.bisMonster == false)
            {
                IcecreamMng.Death();
            }
        }

        if (HeroStateMng.I.fHeroSpeed != 0)
        {
            IcecreamMng.fBullet += Time.deltaTime;
            if (IcecreamMng.fBullet >= IcecreamMng.fBulletTimer)
            {
                IcecreamMng.ChangeCharMotion("Icecream_Attack");

                if (!IcecreamMng.Icecream2dAniSprite.IsPlaying("Icecream_Attack"))
                {
                    Vector3 vPos = new Vector3(IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x, IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.y, -0.5f);
                    Vector3 vSca = new Vector3(75, 75, 1);
                    HPrefabMng.I.CreatePrefab("Bullets", E_H_RESOURCELOAD.E_3_GameScene, (IcecreamMng.Icecream2dAniSprite.gameObject.name + "Bullet"), vPos, vSca, "", "");
                    IcecreamMng.fBullet = 0;
                }
            }
        }
    }

    public override void Exit()
    {

    }
}