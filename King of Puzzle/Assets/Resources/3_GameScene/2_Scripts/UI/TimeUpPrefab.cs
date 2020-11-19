using UnityEngine;
using System.Collections;

public class TimeUpPrefab : MonoBehaviour {
    float fTimer;
	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 3.0f)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
	}
}
