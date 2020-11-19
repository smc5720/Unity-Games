using UnityEngine;
using System.Collections;

public class RestartBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        HEtcMng.I.LoadLevelAsync("3_GameScene");
    }
}
