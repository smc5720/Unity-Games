using UnityEngine;
using System.Collections;

public class ResumeBtn : MonoBehaviour {
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
        Time.timeScale = 1;
        HPrefabMng.I.DestroyPrefab("Black(Clone)");
        HPrefabMng.I.DestroyPrefab("PausePopup(Clone)");
    }
}