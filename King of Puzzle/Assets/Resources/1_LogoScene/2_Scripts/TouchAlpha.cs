using UnityEngine;
using System.Collections;

public class TouchAlpha : MonoBehaviour {
    UISprite AlphaSprite;
    bool bstate = true;
    public AudioClip Effect;
	// Use this for initialization
	void Start () {
        AlphaSprite = gameObject.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {

        if (bstate == true)
        {
            AlphaSprite.alpha += 0.03f;
            if (AlphaSprite.alpha >= 1.0f)
            {
                bstate = false;
            }
        }

        if (bstate == false)
        {
            AlphaSprite.alpha -= 0.03f;
            if (AlphaSprite.alpha <= 0.0f)
            {
                bstate = true;
            }
        }
	}

    void OnClick()
    {
        Application.LoadLevel("2_MenuScene");
        AudioSource.PlayClipAtPoint(Effect, transform.position);
    }
}
