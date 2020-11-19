using UnityEngine;
using System.Collections;

public class SIcecreamStand : HState
{
    public SIcecreamStateMng IcecreamMng;
    public override void Enter()
    {
        IcecreamMng.Icecream2dAniSprite.rigidbody.velocity = new Vector3(0, 0, 0);
    }

    public override void Execute(float fDt)
    {
        if (IcecreamMng.bIsAlive == true && HeroStateMng.I.bisMonster == true && HeroStateMng.I.nWaveNum >= 8)
        {
            IcecreamMng.IcecreamCharVec3 = HeroStateMng.I.CharVector3 - IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition;
            IcecreamMng.IcecreamCharVec3.Normalize();
            IcecreamMng.fIcecreamHP = 22.0f;
            IcecreamMng.Icecream2dAniSprite.GetComponent<MeshRenderer>().enabled = true;
            IcecreamMng.Icecream2dAniSprite.GetComponent<BoxCollider>().enabled = true;
            if (IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                IcecreamMng.LeftMove();
            }
            else if (IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                IcecreamMng.RightMove();
            }
        }
    }

    public override void Exit()
    {

    }
}
