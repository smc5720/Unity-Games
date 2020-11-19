using UnityEngine;
using System.Collections;

public class SSlimeStand : HState
{
    public SSlimeStateMng SlimeMng;
    public override void Enter()
    {
        SlimeMng.Slime2dAniSprite.rigidbody.velocity = new Vector3(0, 0, 0);
    }

    public override void Execute(float fDt)
    {
        if (SlimeMng.bIsAlive == true && HeroStateMng.I.bisMonster == true && HeroStateMng.I.nWaveNum >= 1)
        {
            SlimeMng.SlimeCharVec3 = HeroStateMng.I.CharVector3 - SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition;
            SlimeMng.SlimeCharVec3.Normalize();
            SlimeMng.fSlimeHP = 6.0f;
            SlimeMng.Slime2dAniSprite.GetComponent<MeshRenderer>().enabled = true;
            SlimeMng.Slime2dAniSprite.GetComponent<BoxCollider>().enabled = true;
            if (SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                SlimeMng.LeftMove();
            }
            else if (SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                SlimeMng.RightMove();
            }
        }
    }

    public override void Exit()
    {

    }
}