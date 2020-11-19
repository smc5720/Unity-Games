using UnityEngine;
using System.Collections;

public class HNextSceneBtn : MonoBehaviour {
    public AudioClip GameAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        switch(Application.loadedLevelName)
        {
            case "1_LogoScene":
                HEtcMng.I.LoadLevelAsync("2_MenuScene");
                break;

            case "2_MenuScene":
                AudioSource.PlayClipAtPoint(GameAudio, transform.position);
                HEtcMng.I.LoadLevelAsync("3_GameScene");
                break;

            case "3_GameScene":
                HEtcMng.I.LoadLevelAsync("1_LogoScene");
                break;
        }
    }
}
