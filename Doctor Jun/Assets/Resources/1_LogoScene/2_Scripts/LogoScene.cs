using UnityEngine;
using System.Collections;

public class LogoScene : MonoBehaviour {
    float fTimer;
    bool bisOkay;

	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
        bisOkay = false;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 3.0f)
        {
            TweenAlpha.Begin(gameObject, 1.0f, 0.0f);
            if (fTimer >= 4.0f)
            {                
                if (bisOkay == false)
                {
                    HEtcMng.I.LoadLevelAsync("2_MenuScene");
                    bisOkay = true;
                }
            }
        }
	}
}
