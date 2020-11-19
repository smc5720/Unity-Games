using UnityEngine;
using System.Collections;

public class EffectScript : MonoBehaviour {
    float fTimer;
    public GameObject[] Effect = new GameObject[1];

	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if(fTimer >= 0.3f)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
	}
}
