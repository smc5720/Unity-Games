using UnityEngine;
using System.Collections;

public class LogoScene : MonoBehaviour {
    public GameObject BlackBack;
    float fTimer = 0;
    bool bState;

	// Use this for initialization
	void Start () {
        bState = true;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 3.0f && bState == true)
        {
            bState = false;
            TweenAlpha.Begin(BlackBack, 1.0f, 1.0f);
        }

        if (fTimer >= 4.0f)
        {
            Application.LoadLevel("2_MenuScene");
        }
	}
}
