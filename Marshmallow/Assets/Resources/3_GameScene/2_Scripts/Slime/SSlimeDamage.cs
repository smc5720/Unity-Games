using UnityEngine;
using System.Collections;

/// <summary>
/// 몬스터가 총알에 맞았는지 확인
/// </summary>
public class SSlimeDamage : MonoBehaviour {
    public SSlimeStateMng SlimeMng;
    public AudioClip hitAudio;
    public AudioClip beatAudio;
    public float fFullSlimeHP;
    public GameObject BackGroundGame;
    public GameObject HPBarGame;
    float timer;
    UISprite HPBarSprite;
	// Use this for initialization
	void Start () {
        fFullSlimeHP = 6.0f;
        HPBarSprite = HPBarGame.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
        HPBarSprite.fillAmount = SlimeMng.fSlimeHP / fFullSlimeHP;
        if (SlimeMng.fSlimeHP <= 0)
        {
            HPBarSprite.fillAmount = 0.0f;
        }

        if (!BackGroundGame.animation.IsPlaying("BackGround"))
        {
            BackGroundGame.animation.Rewind("BackGround");
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            int nCriPer = Random.Range(0, 100);

            if (nCriPer > 20)
            {
                SlimeMng.fSlimeHP -= HeroStateMng.I.fBulletDamage;
                Debug.Log("Normal! : " + SlimeMng.fSlimeHP);
            }

            else if (nCriPer <= 20)
            {
                Debug.Log("Critical! : " + HeroStateMng.I.fBulletDamage * HeroStateMng.I.fCriticalDmg);
                SlimeMng.fSlimeHP -= HeroStateMng.I.fBulletDamage * HeroStateMng.I.fCriticalDmg;
            }

            HeroStateMng.I.nScore += 13 * HeroStateMng.I.nPowerLevel;
            SlimeMng.DamageHit();

            if (SlimeMng.fSlimeHP <= 0)
            {
                SlimeMng.Death();
            }
            AudioSource.PlayClipAtPoint(hitAudio, transform.position);
            col.gameObject.transform.localPosition = new Vector3(-700, 0, -0.5f);
            col.gameObject.GetComponent<SBulletPrefab>().enabled = false;
        }

        if (col.gameObject.tag == "Player")
        {
            if (!BackGroundGame.animation.IsPlaying("BackGround"))
            {
                BackGroundGame.animation.Play("BackGround");
            }

            AudioSource.PlayClipAtPoint(beatAudio, transform.position);
            HeroStateMng.I.bPowerControl = true;
            HeroStateMng.I.fHeartGage -= HeroStateMng.I.fSlimeDamage * (1 + HeroStateMng.I.nWaveNum / 10);
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
                    if (SlimeMng.fSlimeHP >= 0)
                    {
                        HeroStateMng.I.AttackBtnPress();
                        HeroStateMng.I.AutoFireVec3 = SlimeMng.Slime2dAniSprite.gameObject.transform.localPosition - HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;
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
