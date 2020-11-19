using UnityEngine;
using System.Collections;

public class TimerGage : MonoBehaviour
{
    UISprite GageSprite;
    UISprite RedSprite;
    UISprite BWallSprite;
    BoxCollider BWallBox;
    BoxCollider PauseBox;
    TouchScript TouchMng;
    StarGage FeverMng;
    public GameObject ParentGage;
    public GameObject ClockImage;
    public GameObject PauseBtn;
    public GameObject RedLight;
    public GameObject StarGage;
    public GameObject BlackWall;
    public float fGagePercent;
    public float fTimer;
    float fTimerMng;
    public float StartTimer;
    public GameObject[] StartObj = new GameObject[4];
    public bool bStopState;
    public bool bFeverState;
    public bool bAlphaState;
    public GameObject TouchObject;
    float fFinishTimer;
    public AudioClip EffectSound;
    public AudioClip EffectSound2;
    public AudioClip EffectSound3;
    public GameObject Root1;
    AudioSource VolumeSetting;
    int nSoundCheck;

    // Use this for initialization
    void Start()
    {
        BWallBox = BlackWall.GetComponent<BoxCollider>();
        BWallSprite = BlackWall.GetComponent<UISprite>();
        GageSprite = gameObject.GetComponent<UISprite>();
        RedSprite = RedLight.GetComponent<UISprite>();
        TouchMng = TouchObject.GetComponent<TouchScript>();
        FeverMng = StarGage.GetComponent<StarGage>();
        PauseBox = PauseBtn.GetComponent<BoxCollider>();
        fGagePercent = 0.0f;
        bFeverState = false;

        if (PlayerPrefs.GetInt("TimerItem") == 1)
        {
            fTimerMng = 65.0f;
        }

        else if (PlayerPrefs.GetInt("TimerItem") == 0)
        {
            fTimerMng = 60.0f;
        }

        fTimer = fTimerMng;
        GageSprite.fillAmount = 1.0f;
        fFinishTimer = 0.0f;
        bAlphaState = true;
        bStopState = false;
        BWallBox.enabled = false;
        TouchMng.enabled = false;
        PauseBox.enabled = false;
        StartTimer = 0.0f;
        BWallSprite.alpha = 0.0f;
        VolumeSetting = Root1.GetComponent<AudioSource>();
        VolumeSetting.enabled = false;
        nSoundCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer += Time.deltaTime;
        if (StartTimer >= 0.5f && StartTimer < 0.6f)
        {
            if (nSoundCheck == 0)
            {
                AudioSource.PlayClipAtPoint(EffectSound2, transform.position);
                nSoundCheck++;
            }
            StartObj[0].transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
            StartObj[0].animation.Play("CreatePopupAni");
        }

        else if (StartTimer >= 1.5f && StartTimer < 1.6f)
        {
            StartObj[1].transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
            StartObj[1].animation.Play("CreatePopupAni");
        }

        else if (StartTimer >= 2.5f && StartTimer < 2.6f)
        {
            StartObj[2].transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
            StartObj[2].animation.Play("CreatePopupAni");
        }

        else if (StartTimer >= 3.5f && StartTimer < 3.6f)
        {
            if (nSoundCheck == 1)
            {
                AudioSource.PlayClipAtPoint(EffectSound3, transform.position);
                nSoundCheck++;
            }
            StartObj[3].transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
            StartObj[3].animation.Play("StartAni");
        }

        else if (StartTimer >= 4.0f)
        {
            PauseBox.enabled = true;
            if (PlayerPrefs.GetInt("FeverItem") == 1 && bFeverState == false)
            {
                FeverMng.FeverModeEffect();
                bFeverState = true;
            }
            TouchMng.enabled = true;
            VolumeSetting.enabled = true;
            TimerGageManager();
            RedAlpha();
            CheckStop();
        }
    }

    void TimerGageManager()
    {
        if (fTimer > fTimerMng)
        {
            fTimer = fTimerMng;
        }

        fGagePercent = fTimer / fTimerMng;

        if (fTimer <= 0.0f)
        {
            fTimer = 0.0f;
            if (VolumeSetting.volume > 0.0f)
            {
                VolumeSetting.volume -= Time.deltaTime;
            }

            if (bStopState == false)
            {
                TouchMng.enabled = false;
                bStopState = true;
                PlayerPrefs.SetInt("NowScore", BallSingleTon.I.nScore);
                if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("NowScore"))
                {
                    PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("NowScore"));
                }
                AudioSource.PlayClipAtPoint(EffectSound, transform.position);
                
                HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "TimeUp", new Vector3(0, 0, -4), new Vector3(1, 1, 1), "", "");
            }
        }

        else
        {
            fTimer -= Time.deltaTime;
        }

        GageSprite.fillAmount = fGagePercent;

        ClockImage.transform.localPosition = new Vector3(420 * GageSprite.fillAmount - 20, ClockImage.transform.localPosition.y, ClockImage.transform.localPosition.z);
    }

    void CheckStop()
    {
        if (bStopState == true)
        {
            if (BWallBox.enabled == false)
            {
                BWallBox.enabled = true;
            }

            if (BWallSprite.alpha < 0.6f)
            {
                BWallSprite.alpha += Time.deltaTime;
            }

            fFinishTimer += Time.deltaTime;

            if (fFinishTimer >= 3.0f)
            {
                if (BWallSprite.alpha < 1.0f)
                {
                    BWallSprite.alpha += Time.deltaTime;
                }
            }

            if (fFinishTimer >= 4.0f)
            {
                Application.LoadLevel("4_ResultScene");
            }
        }
    }

    void RedAlpha()
    {
        if (fTimer <= 10.0f)
        {
            if (RedSprite.alpha >= 0.5f)
            {
                bAlphaState = false;
            }

            if (RedSprite.alpha <= 0)
            {
                bAlphaState = true;
            }

            if (bAlphaState == true)
            {
                RedSprite.alpha += Time.deltaTime;
            }

            if (bAlphaState == false)
            {
                RedSprite.alpha -= Time.deltaTime;
            }
        }

        else
        {
            if (RedSprite.alpha > 0)
            {
                RedSprite.alpha -= Time.deltaTime;
            }

            else
            {
                RedSprite.alpha = 0.0f;
            }
        }
    }
}