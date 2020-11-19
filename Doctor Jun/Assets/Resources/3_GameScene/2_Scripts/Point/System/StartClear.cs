using UnityEngine;
using System.Collections;

public class StartClear : MonoBehaviour {
    tk2dAnimatedSprite Popup;

    // Use this for initialization
    void Start()
    {
        Popup = gameObject.GetComponent<tk2dAnimatedSprite>();
        Popup.Play("Clear");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
