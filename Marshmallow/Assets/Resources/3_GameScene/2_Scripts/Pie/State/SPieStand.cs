using UnityEngine;
using System.Collections;

public class SPieStand : HState
{
    public SPieStateMng PieMng;
    public override void Enter()
    {
        PieMng.Pie2dAniSprite.rigidbody.velocity = new Vector3(0, 0, 0);
    }

    public override void Execute(float fDt)
    {
        if (PieMng.bIsAlive == true && HeroStateMng.I.bisMonster == true && HeroStateMng.I.nWaveNum >= 3)
        {
            PieMng.PieCharVec3 = HeroStateMng.I.CharVector3 - PieMng.Pie2dAniSprite.gameObject.transform.localPosition;
            PieMng.PieCharVec3.Normalize();
            PieMng.fPieHP = 6.0f;
            PieMng.Pie2dAniSprite.GetComponent<MeshRenderer>().enabled = true;
            PieMng.Pie2dAniSprite.GetComponent<BoxCollider>().enabled = true;
            if (PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                PieMng.LeftMove();
            }
            else if (PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                PieMng.RightMove();
            }
        }
    }

    public override void Exit()
    {

    }
}
