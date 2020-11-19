using UnityEngine;
using System.Collections;

public class GameRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        HPrefabMng.I.DestroyPrefab(transform.parent.parent.name);
        Time.timeScale = 1;
        HeroStateMng.I.NewStart();
    }
}
