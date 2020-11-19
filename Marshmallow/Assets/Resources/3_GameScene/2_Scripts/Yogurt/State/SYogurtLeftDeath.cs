using UnityEngine;
using System.Collections;


/// <summary>
/// ¿ä±¸¸£Æ® ¿ÞÂÊ »ç¸Á »óÅÂ
/// </summary>
public class SYogurtLeftDeath : HState
{
    public SYogurtStateMng YogurtMng;
    public AudioClip coinAudio;
    public override void Enter()
    {
        YogurtMng.ChangeCharDir(E_YOGURT_KEY_STATE.E_YO_KEY_LEFT);
        YogurtMng.ChangeCharMotion("Yogurt_Explosion");
        HeroStateMng.I.nHunted++;
        Vector3 labelPos = new Vector3(YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition.x, YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition.y, -2);
        Vector3 labelSca = new Vector3(40, 40, 1);
        AudioSource.PlayClipAtPoint(coinAudio, transform.position);
        YogurtMng.Yogurt2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = false;
        HeroStateMng.I.AttackBtnRelease();
        YogurtMng.Yogurt2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
        HeroStateMng.I.nMonsterKilled++;
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, (YogurtMng.Yogurt2dAniSprite.gameObject.name + "Money"), labelPos, labelSca, "", "SYogurtGold");
    }

    public override void Execute(float fDt)
    {
        if (!YogurtMng.Yogurt2dAniSprite.IsPlaying("Yogurt_Explosion"))
        {
            HeroStateMng.I.nScore += 415;
            HeroStateMng.I.nMoney += 250;
            HeroStateMng.I.nFullMoney += 250;
            YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition = new Vector3(-800, 600, -1);
            YogurtMng.Yogurt2dAniSprite.GetComponent<MeshRenderer>().enabled = false;

            YogurtMng.bIsAlive = false;

            YogurtMng.Alive();
        }
    }

    public override void Exit()
    {
        YogurtMng.fYogurtHP = 0;

        HeroStateMng.I.nYogurtControl--;

        HeroStateMng.I.nYogurtNum--;

        if (HeroStateMng.I.nYogurtNum <= 0)
        {
            HeroStateMng.I.bisYogurt = true;
        }
    }
}
