using UnityEngine;
using System.Collections;

public class PauseBtn : MonoBehaviour {
    public AudioClip Effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Time.timeScale = 0;
        AudioSource.PlayClipAtPoint(Effect, transform.position);
        HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "PausePopup", new Vector3(0, 0, 0), new Vector3(1, 1, 1), "", "");
    }
}