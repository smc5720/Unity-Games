using UnityEngine;
using System.Collections;

public class ClearPopup : MonoBehaviour
{
    public GameObject ScoreLabel;
    public GameObject MoneyText;
    public GameObject HighScoreLabel;
    public GameObject[] LevelSprite = new GameObject[20];
    public GameObject BlackCol;
    public GameObject LevelObject;
    public GameObject Popup;
    public AudioClip ScoreSound;
    public GameObject Okbtn;
    public AudioClip LvSound;
    UIButton OkCheck;
    UILabel Score;
    UILabel HighScore;
    UILabel MoneyLabel;
    UISprite BlackAlpha;
    UISprite LevelGage;
    int nMoney = 0;
    int nScore = 0;
    int nHScore = 0;
    float fRtimer;
    public float fLevelNumber;

    // Use this for initialization
    void Start()
    {
        OkCheck = Okbtn.GetComponent<UIButton>();
        Score = ScoreLabel.GetComponent<UILabel>();
        HighScore = HighScoreLabel.GetComponent<UILabel>();
        MoneyLabel = MoneyText.GetComponent<UILabel>();
        Score.text = "0";
        OkCheck.isEnabled = false;
        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.GetInt("Level") == i + 1)
            {
                LevelSprite[i] = GameObject.Find("Level" + (i + 1).ToString());
                LevelSprite[i].transform.localPosition = new Vector3(0, 0, 0);
            }

            else
            {
                LevelSprite[i] = GameObject.Find("Level" + (i + 1).ToString());
                LevelSprite[i].transform.localPosition = new Vector3(-500, 0, 0);
            }
        }
        BlackAlpha = BlackCol.GetComponent<UISprite>();
        fRtimer = 0;
        LevelGage = LevelObject.GetComponent<UISprite>();
        BlackAlpha.alpha = 1.0f;
        TweenAlpha.Begin(BlackCol, 0.2f, 0.6f);
        SetAmount(PlayerPrefs.GetInt("NowScore"));
        fLevelNumber = ((PlayerPrefs.GetFloat("LevelAmount") / PlayerPrefs.GetFloat("FullLvAmount")));
        PlayerPrefs.SetFloat("LevelAmount", PlayerPrefs.GetFloat("LevelAmount") + PlayerPrefs.GetFloat("PlusAmount"));
        PlayerPrefs.SetFloat("AddNumber", 0.01f);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("NowScore") / 100);
    }

    // Update is called once per frame
    void Update()
    {
        fRtimer += 0.02f;

        if (fLevelNumber >= 1.0f)
        {
            if (PlayerPrefs.GetInt("Level") < 19)
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                PlayerPrefs.SetFloat("LevelAmount", PlayerPrefs.GetFloat("LevelAmount") - 1500.0f);
                PlayerPrefs.SetFloat("FullLvAmount", PlayerPrefs.GetFloat("FullLvAmount"));
                PlayerPrefs.SetFloat("AddNumber", 0.0f);
                Popup.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
                AudioSource.PlayClipAtPoint(LvSound, transform.position);
                Popup.animation.Play("CreatePopupAni");
                fLevelNumber -= 1.0f;
            }

            else if (PlayerPrefs.GetInt("Level") == 19)
            {
                fLevelNumber = 1.0f;
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                Popup.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
                Popup.animation.Play("CreatePopupAni");
                PlayerPrefs.SetFloat("LevelAmount", 1500.0f);
                PlayerPrefs.SetFloat("FullLvAmount", 1500.0f);
            }

            else
            {
                fLevelNumber = 1.0f;
                PlayerPrefs.SetFloat("LevelAmount", 1500.0f);
                PlayerPrefs.SetFloat("FullLvAmount", 1500.0f);
            }
        }

        LevelGage.fillAmount = fLevelNumber;

        LevelSetting();

        TimerCheck();
    }

    void TimerCheck()
    {
        MoneyLabel.text = nMoney.ToString();

        if (PlayerPrefs.GetInt("NowScore") / 100 > nMoney)
        {
            nMoney += 43;
        }

        else if (PlayerPrefs.GetInt("NowScore") / 100 <= nMoney)
        {
            nMoney = PlayerPrefs.GetInt("NowScore") / 100;
        }

        if (PlayerPrefs.GetInt("NowScore") > nScore)
        {
            if (PlayerPrefs.GetInt("NowScore") < 10000)
            {
                nScore += 43;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 10000 && PlayerPrefs.GetInt("NowScore") < 50000)
            {
                nScore += 1033;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 50000 && PlayerPrefs.GetInt("NowScore") < 1000000)
            {
                nScore += 4034;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 1000000 && PlayerPrefs.GetInt("NowScore") < 5000000)
            {
                nScore += 18343;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 5000000 && PlayerPrefs.GetInt("NowScore") < 10000000)
            {
                nScore += 26343;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 10000000 && PlayerPrefs.GetInt("NowScore") < 50000000)
            {
                nScore += 32343;
            }

            else if (PlayerPrefs.GetInt("NowScore") >= 50000000)
            {
                nScore += 32343;
            }
        }

        else if (PlayerPrefs.GetInt("NowScore") <= nScore)
        {
            nScore = PlayerPrefs.GetInt("NowScore");
        }

        if (PlayerPrefs.GetInt("HighScore") > nHScore)
        {
            if (PlayerPrefs.GetInt("HighScore") < 10000)
            {
                nHScore += 43;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 10000 && PlayerPrefs.GetInt("HighScore") < 50000)
            {
                nHScore += 1033;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 50000 && PlayerPrefs.GetInt("HighScore") < 1000000)
            {
                nHScore += 4034;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 1000000 && PlayerPrefs.GetInt("HighScore") < 5000000)
            {
                nHScore += 18343;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 5000000 && PlayerPrefs.GetInt("HighScore") < 10000000)
            {
                nHScore += 26343;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 10000000 && PlayerPrefs.GetInt("HighScore") < 50000000)
            {
                nHScore += 32343;
            }

            else if (PlayerPrefs.GetInt("HighScore") >= 50000000)
            {
                nHScore += 32343;
            }

            AudioSource.PlayClipAtPoint(ScoreSound, transform.position);
        }

        else if (PlayerPrefs.GetInt("HighScore") <= nHScore)
        {
            nHScore = PlayerPrefs.GetInt("HighScore");
        }

        Score.text = nScore.ToString();
        HighScore.text = nHScore.ToString();

        if (nHScore == PlayerPrefs.GetInt("HighScore"))
        {
            if (fLevelNumber < ((PlayerPrefs.GetFloat("LevelAmount") / PlayerPrefs.GetFloat("FullLvAmount"))))
            {
                fLevelNumber += PlayerPrefs.GetFloat("AddNumber") * 2;
            }

            else if (fLevelNumber >= ((PlayerPrefs.GetFloat("LevelAmount") / PlayerPrefs.GetFloat("FullLvAmount"))))
            {
                OkCheck.isEnabled = true;
            }
        }
    }

    public void SetAmount(int nScore)
    {
        if (nScore <= 20000)
        {
            AddLevel(100 + nScore / 1000);
        }

        if (20000 < nScore && nScore <= 30000)
        {
            AddLevel(200 + nScore / 1000);
        }

        if (30000 < nScore && nScore <= 50000)
        {
            AddLevel(400 + nScore / 1000);
        }

        if (50000 < nScore && nScore <= 80000)
        {
            AddLevel(700 + nScore / 1000);
        }

        if (nScore > 80000)
        {
            AddLevel(1000 + nScore / 10000);
        }
    }

    public void AddLevel(float fAmount)
    {
        PlayerPrefs.SetFloat("PlusAmount", fAmount);
    }

    public void LevelSetting()
    {
        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.GetInt("Level") == i + 1)
            {
                LevelSprite[i].transform.localPosition = new Vector3(0, 0, 0);
            }

            else
            {
                LevelSprite[i].transform.localPosition = new Vector3(-500, 0, 0);
            }
        }
    }
}