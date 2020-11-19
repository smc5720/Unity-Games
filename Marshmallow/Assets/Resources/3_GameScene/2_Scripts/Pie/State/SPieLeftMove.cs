using UnityEngine;
using System.Collections;


/// <summary>
/// 파이 왼쪽 이동상태
/// </summary>
public class SPieLeftMove : HState
{
    public SPieStateMng PieMng;
    public override void Enter()
    {
        PieMng.ChangeCharDir(E_PIE_KEY_STATE.E_PI_KEY_LEFT);
        PieMng.ChangeCharMotion("Pie_Move");
    }

    public override void Execute(float fDt)
    {
        if (PieMng.fBullet < PieMng.fBulletTimer)
        {
            PieMng.PieCharVec3 = HeroStateMng.I.CharVector3 - PieMng.Pie2dAniSprite.gameObject.transform.localPosition;
            PieMng.PieCharVec3.Normalize();
            PieMng.Pie2dAniSprite.gameObject.rigidbody.velocity = new Vector3(PieMng.PieCharVec3.x / PieMng.fPieSpeed, PieMng.PieCharVec3.y / PieMng.fPieSpeed, PieMng.Pie2dAniSprite.gameObject.rigidbody.velocity.z);

            if (PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x < HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition.x)
            {
                PieMng.RightMove();
                PieMng.LeftStop();
            }

            if (HeroStateMng.I.bisMonster == false)
            {
                PieMng.Death();
            }
        }

        PieMng.fBullet += Time.deltaTime;
        if (PieMng.fBullet >= PieMng.fBulletTimer)
        {
            PieMng.ChangeCharMotion("Pie_Attack");

            if (!PieMng.Pie2dAniSprite.IsPlaying("Pie_Attack"))
            {
                Vector3 vPos = new Vector3(PieMng.Pie2dAniSprite.gameObject.transform.localPosition.x, PieMng.Pie2dAniSprite.gameObject.transform.localPosition.y, -0.5f);
                Vector3 vSca = new Vector3(50, 50, 1);
                HPrefabMng.I.CreatePrefab("Bullets", E_H_RESOURCELOAD.E_3_GameScene, (PieMng.Pie2dAniSprite.gameObject.name + "Bullet"), vPos, vSca, "", "");
                PieMng.fBullet = 0;
            }
        }
    }

    public override void Exit()
    {

    }
}