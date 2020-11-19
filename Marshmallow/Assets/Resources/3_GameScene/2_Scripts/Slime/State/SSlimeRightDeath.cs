using UnityEngine;
using System.Collections;


/// <summary>
/// 슬라임 오른쪽 사망 상태
/// </summary>
public class SSlimeRightDeath : HState
{
    public SSlimeStateMng SlimeMng;
    public AudioClip coinAudio;
    public override void Enter()
    {
        SlimeMng.ChangeCharDir(E_SLIME_KEY_STATE.E_SL_KEY_RIGHT);
        SlimeMng.ChangeCharMotion("Slime_Death");
        HeroStateMng.I.nHunted++;
        Vector3 labelPos = new Vector3(SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.x, SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition.y, -2);
        Vector3 labelSca = new Vector3(40, 40, 1);
        AudioSource.PlayClipAtPoint(coinAudio, transform.position);
        SlimeMng.Slime2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = false;
        HeroStateMng.I.AttackBtnRelease();
        SlimeMng.Slime2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
        HeroStateMng.I.nMonsterKilled++;
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, (SlimeMng.Slime2dAniSprite.gameObject.name + "Money"), labelPos, labelSca, "", "SSlimeGold");
    }

    public override void Execute(float fDt)
    {
        if (!SlimeMng.Slime2dAniSprite.IsPlaying("Slime_Death"))
        {
            HeroStateMng.I.nScore += 215;
            HeroStateMng.I.nMoney += 50;
            HeroStateMng.I.nFullMoney += 50;
            SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition = new Vector3(-800, 600, -1);
            SlimeMng.Slime2dAniSprite.GetComponent<MeshRenderer>().enabled = false;

            SlimeMng.bIsAlive = false;

            SlimeMng.Alive();
        }
    }

    public override void Exit()
    {
        SlimeMng.fSlimeHP = 0;

        HeroStateMng.I.nSlimeControl--;

        HeroStateMng.I.nSlimeNum--;

        if (HeroStateMng.I.nSlimeNum <= 0)
        {
            HeroStateMng.I.bisSlime = true;
        }
    }
}