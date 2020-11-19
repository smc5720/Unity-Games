using UnityEngine;
using System.Collections;

public class PauseBtn : MonoBehaviour {
    public AudioClip GameAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(GameAudio, transform.position);
        Time.timeScale = 0;
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "Black", new Vector3(0.0f, 0.0f, -10.0f), new Vector3(480.0f, 832.0f, 1.0f), "", "");
        HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "PausePopup", new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.01f, 0.01f, 1.0f), "", "");
    }
}
