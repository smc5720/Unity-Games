using UnityEngine;
using System.Collections;

public class RestartBtn : MonoBehaviour {
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
        HEtcMng.I.LoadLevelAsync("3_GameScene");
    }
}
