using UnityEngine;
using System.Collections;

public class PuzzleBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        HEtcMng.I.LoadLevelAsync("4_PuzzleScene");
    }
}
