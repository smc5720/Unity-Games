using UnityEngine;
using System.Collections;

public class HDestroyPrefab : MonoBehaviour {
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
        HPrefabMng.I.DestroyPrefab(transform.parent.parent.name);
        Time.timeScale = 1;
    }
}
