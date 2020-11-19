using UnityEngine;
using System.Collections;


/// <summary>
/// ÆÄÀÌ ¿ÞÂÊ »ç¸Á »óÅÂ
/// </summary>
public class SIcecreamLeftDeath : HState
{
    public SIcecreamStateMng IcecreamMng;
    public AudioClip coinAudio;
    public override void Enter()
    {
        IcecreamMng.ChangeCharDir(E_ICE_KEY_STATE.E_IC_KEY_LEFT);
        IcecreamMng.ChangeCharMotion("Icecream_Death");
        HeroStateMng.I.nHunted++;
        Vector3 labelPos = new Vector3(IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.x, IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition.y, -2);
        Vector3 labelSca = new Vector3(40, 40, 1);
        AudioSource.PlayClipAtPoint(coinAudio, transform.position);
        IcecreamMng.Icecream2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = false;
        HeroStateMng.I.AttackBtnRelease();
        IcecreamMng.Icecream2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
        HeroStateMng.I.nMonsterKilled++;
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, (IcecreamMng.Icecream2dAniSprite.gameObject.name + "Money"), labelPos, labelSca, "", "SIcecreamGold");
    }

    public override void Execute(float fDt)
    {
        if (!IcecreamMng.Icecream2dAniSprite.IsPlaying("Icecream_Death"))
        {
            HeroStateMng.I.nScore += 525;
            HeroStateMng.I.nMoney += 200;
            HeroStateMng.I.nFullMoney += 200;
            IcecreamMng.Icecream2dAniSprite.gameObject.transform.localPosition = new Vector3(-800, 600, -1);
            IcecreamMng.Icecream2dAniSprite.GetComponent<MeshRenderer>().enabled = false;

            IcecreamMng.bIsAlive = false;

            IcecreamMng.Alive();
        }
    }

    public override void Exit()
    {
        IcecreamMng.fIcecreamHP = 0;

        HeroStateMng.I.nIcecreamControl--;

        HeroStateMng.I.nIcecreamNum--;

        if (HeroStateMng.I.nIcecreamNum <= 0)
        {
            HeroStateMng.I.bisIcecream = true;
        }
    }
}
