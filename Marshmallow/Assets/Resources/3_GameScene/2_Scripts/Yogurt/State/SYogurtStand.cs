using UnityEngine;
using System.Collections;

public class SYogurtStand : HState
{
    public SYogurtStateMng YogurtMng;
    public override void Enter()
    {
        YogurtMng.Yogurt2dAniSprite.rigidbody.velocity = new Vector3(0, 0, 0);
    }

    public override void Execute(float fDt)
    {
        if (YogurtMng.bIsAlive == true && HeroStateMng.I.bisMonster == true && HeroStateMng.I.nWaveNum >= 6)
        {
            YogurtMng.YogurtCharVec3 = HeroStateMng.I.CharVector3 - YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition;
            YogurtMng.YogurtCharVec3.Normalize();
            YogurtMng.fYogurtHP = 17.0f;
            YogurtMng.Yogurt2dAniSprite.GetComponent<MeshRenderer>().enabled = true;
            YogurtMng.Yogurt2dAniSprite.GetComponent<BoxCollider>().enabled = true;
            if (YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition.x > HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                YogurtMng.LeftMove();
            }
            else if (YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                YogurtMng.RightMove();
            }
        }
    }

    public override void Exit()
    {

    }
}