using UnityEngine;
using System.Collections;

public class ChangePic : MonoBehaviour {
    float fTimer;
   
	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.5f)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
	}
}
