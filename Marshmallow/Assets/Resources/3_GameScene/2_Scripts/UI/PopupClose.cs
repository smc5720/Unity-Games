using UnityEngine;
using System.Collections;

public class PopupClose : MonoBehaviour {
    public AudioClip ButtonAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        HeroStateMng.I.fTimer = 0.0f;
    }
}