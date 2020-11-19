using UnityEngine;
using System.Collections;

public class Pie_Bullet : MonoBehaviour {
    Vector3 vPos;
    public AudioClip BombAudio;
	// Use this for initialization
	void Start () {
        vPos = HeroStateMng.I.CharVector3 - gameObject.transform.localPosition;
        vPos.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.rigidbody.velocity = new Vector3(vPos.x * 3, vPos.y * 3, gameObject.transform.localPosition.z);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            HeroStateMng.I.fHeartGage -= 0.3f;
            HeroStateMng.I.bPowerControl = true;
            AudioSource.PlayClipAtPoint(BombAudio, transform.position);
            HPrefabMng.I.DestroyPrefab(gameObject);
        }

        else if (col.gameObject.tag == "Wall")
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
    }
}