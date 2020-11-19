using UnityEngine;
using System.Collections;

public class MenuBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Application.LoadLevel("2_MenuScene");
    }
}
