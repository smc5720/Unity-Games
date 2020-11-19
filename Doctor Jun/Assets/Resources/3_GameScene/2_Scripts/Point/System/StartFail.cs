using UnityEngine;
using System.Collections;

public class StartFail : MonoBehaviour {
    tk2dAnimatedSprite Popup;

    // Use this for initialization
    void Start()
    {
        Popup = gameObject.GetComponent<tk2dAnimatedSprite>();
        Popup.Play("Fail");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
