using UnityEngine;
using System.Collections;

public class SoundMuteBtn : MonoBehaviour {
    bool bisSwitch;
    public UIPanel MutePanel;
    AudioSource GameAudio;
	// Use this for initialization
	void Start () {
        bisSwitch = true;
        GameAudio = MutePanel.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (bisSwitch == true)
        {
            GameAudio.mute = false;
        }

        else if (bisSwitch == false)
        {
            GameAudio.mute = true;
        }
	}

    void OnClick()
    {
        if (bisSwitch == true)
        {
            bisSwitch = false;
        }

        else if (bisSwitch == false)
        {
            bisSwitch = true;
        }
    }
}
