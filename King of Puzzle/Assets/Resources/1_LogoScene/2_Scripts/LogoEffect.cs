using UnityEngine;
using System.Collections;

public class LogoEffect : MonoBehaviour
{
    public GameObject TeamLogo;
    UISprite TeamAlpha;
    UISprite ThisAlpha;
    AniChange TitleAni;
    TouchAlpha BlackTouch;
    BoxCollider BlackCollider;
   public bool bstate = false;
   public bool bstate2 = false;

    // Use this for initialization
    void Start()
    {
        TeamAlpha = TeamLogo.GetComponent<UISprite>();
        TeamAlpha.alpha = 0.0f;
        ThisAlpha = gameObject.GetComponent<UISprite>();
        BlackTouch = GameObject.Find("Press").GetComponent<TouchAlpha>();
        TitleAni = GameObject.Find("Title").GetComponent<AniChange>();
        BlackCollider = GameObject.Find("Press").GetComponent<BoxCollider>();
        BlackTouch.enabled = false;
        BlackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TeamAlpha.alpha < 1.0f && bstate == false)
        {
            TeamAlpha.alpha += 0.03f;
        }

        if (TeamAlpha.alpha >= 1.0f)
        {
            bstate = true;
        }

        if (bstate == true)
        {
            if (TeamAlpha.alpha > 0.0f)
            {
                TeamAlpha.alpha -= 0.03f;
            }

            if (TeamAlpha.alpha <= 0.0f)
            {
                bstate2 = true;
            }
        }

        if (bstate2 == true)
        {
            ThisAlpha.alpha -= 0.03f;
        }

        if (ThisAlpha.alpha <= 0.0f)
        {
            TitleAni.enabled = true;
            BlackTouch.enabled = true;
            BlackCollider.enabled = true;
        }
    }
}
