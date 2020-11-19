using UnityEngine;
using System.Collections;

public class Icecream_Bullet : MonoBehaviour {
    Vector3 vPos;
    public AudioClip IceAudio;
	// Use this for initialization
	void Start () {
        vPos = HeroStateMng.I.CharVector3 - gameObject.transform.localPosition;
        vPos.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.rigidbody.velocity = new Vector3(vPos.x * 4, vPos.y * 4, gameObject.transform.localPosition.z);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(IceAudio, transform.position);
            HeroStateMng.I.fHeroSpeed = 0;
            HPrefabMng.I.DestroyPrefab(gameObject.name);
        }

        else if (col.gameObject.tag == "Wall")
        {
            HPrefabMng.I.DestroyPrefab(gameObject.name);
        }
    }
}