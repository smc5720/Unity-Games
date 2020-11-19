using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터가 총알에 맞았는지 확인
/// </summary>
public class SYogurtDamage : MonoBehaviour {
    public SYogurtStateMng YogurtMng;
    public AudioClip hitAudio;
    public AudioClip beatAudio;
    public float fFullYogurtHP;
    public GameObject BackGroundGame;
    public GameObject HPBarGame;
    float timer;
    UISprite HPBarSprite;
	// Use this for initialization
	void Start () {
        fFullYogurtHP = 17.0f;
        HPBarSprite = HPBarGame.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
        HPBarSprite.fillAmount = YogurtMng.fYogurtHP / fFullYogurtHP;
        if (YogurtMng.fYogurtHP <= 0)
        {
            HPBarSprite.fillAmount = 0.0f;
        }

        if (!BackGroundGame.animation.IsPlaying("BackGround2"))
        {
            BackGroundGame.animation.Rewind("BackGround2");
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            int nCriPer = Random.Range(0, 100);

            if (nCriPer > 20)
            {
                YogurtMng.fYogurtHP -= HeroStateMng.I.fBulletDamage;
            }

            else if (nCriPer <= 20)
            {
                YogurtMng.fYogurtHP -= HeroStateMng.I.fBulletDamage * HeroStateMng.I.fCriticalDmg;
            }

            YogurtMng.DamageHit();

            HeroStateMng.I.nScore += 13 * HeroStateMng.I.nPowerLevel;

            if (YogurtMng.fYogurtHP <= 0)
            {
                YogurtMng.Death();
            }
            AudioSource.PlayClipAtPoint(hitAudio, transform.position);
            col.gameObject.transform.localPosition = new Vector3(-700, 0, -0.5f);
            col.gameObject.GetComponent<SBulletPrefab>().enabled = false;
        }

        if (col.gameObject.tag == "Player")
        {
            if (!BackGroundGame.animation.IsPlaying("BackGround1"))
            {
                BackGroundGame.animation.Play("BackGround2");
            }
            HeroStateMng.I.bPowerControl = true;
            AudioSource.PlayClipAtPoint(beatAudio, transform.position);
            HeroStateMng.I.fHeartGage -= HeroStateMng.I.fYogurtDamage;
            YogurtMng.fYogurtHP = 0;
            YogurtMng.Death();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "AttackCol")
        {
            if (gameObject.transform.localPosition.x >= -430 && gameObject.transform.localPosition.x <= 440)
            {
                if (gameObject.transform.localPosition.y >= -260 && gameObject.transform.localPosition.y <= 270)
                {
                    if (YogurtMng.fYogurtHP >= 0)
                    {
                        HeroStateMng.I.AttackBtnPress();
                        HeroStateMng.I.AutoFireVec3 = YogurtMng.Yogurt2dAniSprite.gameObject.transform.localPosition - HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;
                        HeroStateMng.I.AutoFireVec3.Normalize();
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "AttackCol")
        {
            HeroStateMng.I.AttackBtnRelease();
        }
    }
}
