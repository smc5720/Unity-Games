using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour
{
    public GameObject[] BackSwap = new GameObject[2];
    public GameObject Camera2D;
    public string[] cSpriteName = new string[5];
    int nChangeNum = 0;
    CharacterMove CharMng;
    bool bState = false;
    bool bState2 = false;
    UISprite BackSprite;

    void Awake()
    {
        CharMng = CharacterMove.I;
        BackSprite = BackSwap[1].GetComponent<UISprite>();

        for (int i = 1; i < 6; i++)
        {
            if (i == 1)
            {
                cSpriteName[i - 1] = "png";
            }

            else
            {
                cSpriteName[i - 1] = "png" + i.ToString();
            }
        }

        for (int i = 0; i < 2; i++)
        {
            BackSwap[i].GetComponent<UISprite>().spriteName = cSpriteName[PlayerPrefs.GetInt("BackGround")];
        }
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharMng.nCheckNum != 0 && CharMng.nCheckNum % 20 == 0 && bState == false)
        {
            bState2 = true;

            ChangeMap();
        }

        if (CharMng.nCheckNum % 20 != 0)
        {
            bState = false;
        }

        for (int i = 0; i < 2; i++)
        {
            if (BackSwap[i].transform.localPosition.x + 800 <= Camera2D.transform.localPosition.x)
            {
                BackSwap[i].transform.localPosition = new Vector3(BackSwap[i].transform.localPosition.x + 1600, 0, 0);
            }
        }
    }

    public void ChangeMap()
    {
        if (bState2 == true)
        {
            for (int i = 0; i < 2; i++)
            {
                TweenAlpha.Begin(BackSwap[i], 0.1f, 0.0f);
            }

            bState2 = false;
        }

        if (BackSprite.alpha <= 0.05f)
        {
            PlayerPrefs.SetInt("BackGround", PlayerPrefs.GetInt("BackGround") + 1);

            if (PlayerPrefs.GetInt("BackGround") >= 5)
            {
                PlayerPrefs.SetInt("BackGround", 0);
            }

            for (int i = 0; i < 2; i++)
            {
                BackSwap[i].GetComponent<UISprite>().spriteName = cSpriteName[PlayerPrefs.GetInt("BackGround")];
                TweenAlpha.Begin(BackSwap[i], 0.1f, 1.0f);
            }

            bState = true;
        }
    }
}
