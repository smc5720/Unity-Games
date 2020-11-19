using UnityEngine;
using System.Collections;


/// <summary>
/// 파이 오른쪽 사망 상태
/// </summary>
public class SPieRightDeath : HState
{
    public SPieStateMng PieMng;
    public AudioClip coinAudio;
    public override void Enter()
    {
        PieMng.ChangeCharDir(E_PIE_KEY_STATE.E_PI_KEY_RIGHT);
        PieMng.ChangeCharMotion("Pie_Death");
        HeroStateMng.I.nHunted++;
        Vector3 labelPos = new Vector3(PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x, PieMng.Pie2dAniSprite.gameObject.transform.localPosition.y, -2);
        Vector3 labelSca = new Vector3(40, 40, 1);
        AudioSource.PlayClipAtPoint(coinAudio, transform.position);
        PieMng.Pie2dAniSprite.gameObject.GetComponent<BoxCollider>().enabled = false;
        HeroStateMng.I.AttackBtnRelease();
        PieMng.Pie2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
        HeroStateMng.I.nMonsterKilled++;
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, (PieMng.Pie2dAniSprite.gameObject.name + "Money"), labelPos, labelSca, "", "SPieGold");
    }

    public override void Execute(float fDt)
    {
        if (!PieMng.Pie2dAniSprite.IsPlaying("Pie_Death"))
        {
            HeroStateMng.I.nScore += 355;
            HeroStateMng.I.nMoney += 80;
            HeroStateMng.I.nFullMoney += 80;
            PieMng.Pie2dAniSprite.gameObject.transform.localPosition = new Vector3(-800, 600, -1);
            PieMng.Pie2dAniSprite.GetComponent<MeshRenderer>().enabled = false;

            PieMng.bIsAlive = false;

            PieMng.Alive();
        }
    }

    public override void Exit()
    {
        PieMng.fPieHP = 0;
        
        HeroStateMng.I.nPieControl--;

        HeroStateMng.I.nPieNum--;

        if (HeroStateMng.I.nPieNum <= 0)
        {
            HeroStateMng.I.bisPie = true;
        }
    }
}
