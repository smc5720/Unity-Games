using UnityEngine;
using System.Collections;

public class CreditBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        if (Application.loadedLevelName == "3_GameScene")
        {
            Application.LoadLevel("5_CreditScene");
        }

        if (Application.loadedLevelName == "5_CreditScene")
        {
            Application.LoadLevel("3_GameScene");
        }
    }
}
