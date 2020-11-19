using UnityEngine;
using System.Collections;

public class SceneTrans : MonoBehaviour {

    float fTimer = 0.0f;
    UISprite ForAlpha;
    bool bCheck;

	// Use this for initialization
	void Start () {
        ForAlpha = gameObject.GetComponent<UISprite>();
        ForAlpha.alpha =0.0f;
        bCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 1.0f)
        {
            if (bCheck == false)
            {
                ForAlpha.alpha += 0.05f;
            }

            if (ForAlpha.alpha >= 1.0f)
            {
                bCheck = true;
            }

            if (bCheck == true)
            {
                ForAlpha.alpha -= 0.05f;
            }

            if (ForAlpha.alpha <= 0.0f)
            {
                bCheck = false;
            }
        }
	}

    void OnClick()
    {
        Application.LoadLevel("2_LoadingScene");
    }
}
