using UnityEngine;
using System.Collections;

public class ComboGage : MonoBehaviour {
    public GameObject Com1Gage;
    public GameObject Com2Gage;
    public GameObject Com3Gage;
    public GameObject Com4Gage;
    public GameObject Com5Gage;
    public GameObject Com6Gage;
    public GameObject Com7Gage;
    public GameObject Com8Gage;
    public GameObject Com9Gage;
    public GameObject Com10Gage;

    UISprite Com1Sprite;
    UISprite Com2Sprite;
    UISprite Com3Sprite;
    UISprite Com4Sprite;
    UISprite Com5Sprite;
    UISprite Com6Sprite;
    UISprite Com7Sprite;
    UISprite Com8Sprite;
    UISprite Com9Sprite;
    UISprite Com10Sprite;
    BallSingleTon BallSingle;

    public float ComboPercent;
    public float fTimer;

	// Use this for initialization
	void Start () {
        Com1Sprite = Com1Gage.GetComponent<UISprite>();
        Com2Sprite = Com2Gage.GetComponent<UISprite>();
        Com3Sprite = Com3Gage.GetComponent<UISprite>();
        Com4Sprite = Com4Gage.GetComponent<UISprite>();
        Com5Sprite = Com5Gage.GetComponent<UISprite>();
        Com6Sprite = Com6Gage.GetComponent<UISprite>();
        Com7Sprite = Com7Gage.GetComponent<UISprite>();
        Com8Sprite = Com8Gage.GetComponent<UISprite>();
        Com9Sprite = Com9Gage.GetComponent<UISprite>();
        Com10Sprite = Com10Gage.GetComponent<UISprite>();

        Com1Sprite.fillAmount = 0.0f;
        Com2Sprite.fillAmount = 0.0f;
        Com3Sprite.fillAmount = 0.0f;
        Com4Sprite.fillAmount = 0.0f;
        Com5Sprite.fillAmount = 0.0f;
        Com6Sprite.fillAmount = 0.0f;
        Com7Sprite.fillAmount = 0.0f;
        Com8Sprite.fillAmount = 0.0f;
        Com9Sprite.fillAmount = 0.0f;
        Com10Sprite.fillAmount = 0.0f;
        
        BallSingle = BallSingleTon.I;

        ComboPercent = 0.0f;
        fTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (fTimer > 0)
        {
            fTimer -= Time.deltaTime;
        }

        else
        {
            if (BallSingle.nFeverMulti > 1)
            {
                BallSingle.nFeverMulti = 1;
                BallSingle.nCombo = 0;
            }
        }

        ComboPercent = fTimer / 5;

        ComboFunc(BallSingle.nFeverMulti);
	}

    public void ComboFunc(int nFeverMulti)
    {
        if (nFeverMulti == 1)
        {
            Com1Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 2)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 3)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 4)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 5)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 6)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = 0.0f;
            Com6Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 7)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = 0.0f;
            Com6Sprite.fillAmount = 0.0f;
            Com7Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 8)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = 0.0f;
            Com6Sprite.fillAmount = 0.0f;
            Com7Sprite.fillAmount = 0.0f;
            Com8Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 9)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = 0.0f;
            Com6Sprite.fillAmount = 0.0f;
            Com7Sprite.fillAmount = 0.0f;
            Com8Sprite.fillAmount = 0.0f;
            Com9Sprite.fillAmount = ComboPercent;
        }

        else if (nFeverMulti == 10)
        {
            Com1Sprite.fillAmount = 0.0f;
            Com2Sprite.fillAmount = 0.0f;
            Com3Sprite.fillAmount = 0.0f;
            Com4Sprite.fillAmount = 0.0f;
            Com5Sprite.fillAmount = 0.0f;
            Com6Sprite.fillAmount = 0.0f;
            Com7Sprite.fillAmount = 0.0f;
            Com8Sprite.fillAmount = 0.0f;
            Com9Sprite.fillAmount = 0.0f;
            Com10Sprite.fillAmount = ComboPercent;
        }
    }

    public void TimerCharge()
    {
        fTimer = 5.0f;
    }
}
