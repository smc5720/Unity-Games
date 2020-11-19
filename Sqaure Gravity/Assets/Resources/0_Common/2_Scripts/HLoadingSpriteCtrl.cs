using UnityEngine;
using System.Collections;


/// <summary>
/// À§Ä¡ : LoadingPrefab/LoadingSprite/
/// </summary>
public class HLoadingSpriteCtrl : MonoBehaviour {

    UISprite AniSprite = null;
    public int nCurrentFrame = 0;
    public bool bStartAni = false;

    float idleModeCounter = 0.0f;

    public float fAnimationTime = 0.3f;

	// Use this for initialization
	void Start () {

        AniSprite = transform.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (bStartAni)
        {
            if (idleModeCounter < fAnimationTime)
                idleModeCounter += Time.deltaTime;
            else
            {
                nCurrentFrame++;

                if (nCurrentFrame == 10)
                    nCurrentFrame = 0;

                idleModeCounter = 0.0f;

                string sName = "Loading_" + nCurrentFrame.ToString();
                AniSprite.spriteName = sName;
            }
        }
	}

    public void UpdateFrame()
    {        
        bStartAni = true;
    }
}
