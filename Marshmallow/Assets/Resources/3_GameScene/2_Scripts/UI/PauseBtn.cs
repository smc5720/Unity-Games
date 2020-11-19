using UnityEngine;
using System.Collections;

public class PauseBtn : MonoBehaviour {
    public AudioClip ButtonAudio;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnClick()
    {
        HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "PausePopupPrefab", new Vector3(0, 0, 0), new Vector3(1, 1, 1), "", "");
        Time.timeScale = 0;
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
    }
}
