using UnityEngine;
using System.Collections;

public class HCommon_Exit3Btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        HPrefabMng.I.DestroyPrefab(transform.parent.parent.parent.name);
    }
}
