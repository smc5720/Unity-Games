using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {
    int nStart;
	// Use this for initialization
	void Start () {
        nStart = HeroStateMng.I.nTimer;
        TweenAlpha.Begin(gameObject, 0.9f, 0.0f);
        Vector3 sVec3 = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 20, gameObject.transform.localPosition.z);
        SpringPosition.Begin(gameObject, sVec3, 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (nStart != HeroStateMng.I.nTimer)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
	}
}
