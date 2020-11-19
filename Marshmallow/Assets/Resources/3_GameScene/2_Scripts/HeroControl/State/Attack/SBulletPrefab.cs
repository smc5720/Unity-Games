using UnityEngine;
using System.Collections;

public class SBulletPrefab : MonoBehaviour {
    float fcopyx;
    float fcopyy;
    bool bisUsing;
    int nRandomNum;

	// Use this for initialization
	void Start () {
        bisUsing = true;
        gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        fcopyx = HeroStateMng.I.AutoFireVec3.x * 5;
        fcopyy = HeroStateMng.I.AutoFireVec3.y * 5;
        gameObject.rigidbody.velocity = new Vector3(fcopyx, fcopyy, HeroStateMng.I.Hero2dAniSprite.gameObject.rigidbody.velocity.z);
        if (bisUsing == true)
        {
            BulletControl();
            bisUsing = false;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            gameObject.transform.localPosition = new Vector3(-700, 0, -0.5f);
            gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<SBulletPrefab>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            bisUsing = true;
        }

        else if (col.gameObject.tag == "Slime" || col.gameObject.tag == "Pie" || col.gameObject.tag == "Yogurt" || col.gameObject.tag == "Icecream")
        {
            gameObject.transform.localPosition = new Vector3(-700, 0, -0.5f);
            gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<SBulletPrefab>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            bisUsing = true;
            nRandomNum = Random.Range(0, 100);
            if (nRandomNum <= HeroStateMng.I.nDPercent && HeroStateMng.I.fHeartGage < 1)
            {
                HeroStateMng.I.fHeartGage += HeroStateMng.I.fDrain;
                if (HeroStateMng.I.fHeartGage >= 1)
                {
                    HeroStateMng.I.fHeartGage = 1;
                }
            }
        }
    }

    void BulletControl()
    {
        gameObject.transform.localPosition = HeroStateMng.I.Hero2dAniSprite.gameObject.transform.localPosition;
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
}