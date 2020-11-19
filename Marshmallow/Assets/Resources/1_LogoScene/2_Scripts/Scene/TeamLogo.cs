using UnityEngine;
using System.Collections;

public class TeamLogo : MonoBehaviour {
    UISprite LogoSprite;
    public UIAtlas LogoAtlas1;
    public UIAtlas LogoAtlas2;
    public UIAtlas LogoAtlas3;
    int nNum;
    float fTimer;
	// Use this for initialization
	void Start () {
        LogoSprite = gameObject.GetComponent<UISprite>();
        nNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.15f)
        {
            fTimer = 0;
            nNum++;
            LogoSprite.spriteName = nNum.ToString();
            if (nNum == 24)
            {
                TweenColor.Begin(gameObject, 0.5f, Color.black);
            }

            if (nNum == 28)
            {
                Destroy(gameObject);
            }
        }

        if(nNum <= 7)
        {
            LogoSprite.atlas = LogoAtlas1;
        }

        if (nNum > 8 && nNum <= 16)
        {
            LogoSprite.atlas = LogoAtlas2;
        }

        if (nNum >= 17)
        {
            LogoSprite.atlas = LogoAtlas3;
        }
	}
}
