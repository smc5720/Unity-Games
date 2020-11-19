using UnityEngine;
using System.Collections;

public class DestoryPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyPrefab()
    {
        HPrefabMng.I.DestroyPrefab(transform.name);
    }
}
