using UnityEngine;
using System.Collections;

public class HGotoStart : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        GameObject Obj = GameObject.Find("0_Mngs");

        if(Obj == null)
            Application.LoadLevel("1_LogoScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
