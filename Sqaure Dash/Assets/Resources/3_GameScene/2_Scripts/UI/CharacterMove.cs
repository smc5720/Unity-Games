using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{

    private static CharacterMove m_Instance = null;

    public static CharacterMove I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(CharacterMove)) as CharacterMove;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [BallSingleTon.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public int nCheckNum = 0;

    public GameObject Camera2D;

    public GameObject ScoreLabel;

    public GameObject Popup;

    public float fSpeed;

    public float fTimer;

    UILabel Score;

    bool bStopState;

    bool bisStart;

    public GameObject[] BackSwap = new GameObject[2];

    public GameObject[] Wall = new GameObject[4];

    public GameObject Ready;

    public GameObject BoxCol;

    public GameObject BoxCol2;

    public AudioClip EffectAudio;

    float fStopper;

    // Use this for initialization
    void Start()
    {
        Score = ScoreLabel.GetComponent<UILabel>();
        Score.text = nCheckNum.ToString();
        NewStart();
        fStopper = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("CurrentScore", nCheckNum);

        if (nCheckNum >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", nCheckNum);
        }

        if (gameObject.transform.localPosition.x >= -150)
        {
            bisStart = true;
            BoxCol.GetComponent<BoxCollider>().enabled = true;
        }

        if (bisStart == true)
        {
            gameObject.rigidbody.velocity = new Vector3(0.6f, 0, 0) * fSpeed;

            gameObject.transform.eulerAngles -= new Vector3(0, 0, 3) * fSpeed;

            Camera2D.rigidbody.velocity = new Vector3(1.2f, 0, 0) * fSpeed;

            BoxCol.rigidbody.velocity = new Vector3(1.2f, 0, 0) * fSpeed;

            BoxCol2.rigidbody.velocity = new Vector3(1.2f, 0, 0) * fSpeed;

            Score.text = nCheckNum.ToString();

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Ready.transform.localPosition.x >= -200)
                {
                    Ready.transform.localPosition -= new Vector3(500, 0, 0);
                }

                if (fSpeed < 1.0f && bStopState == false)
                {
                    fSpeed = 1.0f;
                }

                gameObject.transform.eulerAngles -= new Vector3(0, 0, 7) * fSpeed;
                gameObject.rigidbody.velocity += new Vector3(1.4f, 0, 0) * fSpeed;
            }

            if (bStopState == true)
            {
                fTimer += Time.deltaTime * fStopper;

                HPrefabMng.I.CreatePrefab("Root_I", E_H_RESOURCELOAD.E_3_GameScene, "Explosion", new Vector3(gameObject.transform.localPosition.x + Camera2D.transform.localPosition.x, gameObject.transform.localPosition.y, -5.0f), new Vector3(200.0f, 200.0f, 1), "", "");

                gameObject.transform.localPosition = new Vector3(-500, 0, -1);

                if (fTimer >= 0.7f)
                {
                    PlayerPrefs.SetInt("CurrentScore", nCheckNum);

                    HPrefabMng.I.DestroyPrefab("Explosion(Clone)");
                }

                if (fTimer >= 1.0f)
                {
                    TweenPosition.Begin(Camera2D, 0.5f, new Vector3(BackSwap[0].transform.localPosition.x, 0, 0));
                    fStopper = 0;
                    fTimer = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        Wall[i].animation.Play("WallAni");
                    }
                    Popup.animation.Play("ResultPopup");
                }
            }

            TouchCheck();
        }
    }

    void NewStart()
    {
        fSpeed = 0.0f;
        fTimer = 0.0f;
        bisStart = false;
        bStopState = false;
        BoxCol.GetComponent<BoxCollider>().enabled = false;
        nCheckNum = 0;
    }

    void TouchCheck()
    {
        int cnt = Input.touchCount;

        for (int i = 0; i < cnt; ++i)
        {
            Touch touch = Input.GetTouch(i);

            if (Ready.transform.localPosition.x >= -200)
            {
                Ready.transform.localPosition -= new Vector3(500, 0, 0);
            }

            if (fSpeed < 1.0f && bStopState == false)
            {
                fSpeed = 1.0f;
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                gameObject.rigidbody.velocity += new Vector3(1.2f, 0, 0) * fSpeed;
                gameObject.transform.eulerAngles -= new Vector3(0, 0, 7) * fSpeed;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                gameObject.rigidbody.velocity += new Vector3(1.2f, 0, 0) * fSpeed;
                gameObject.transform.eulerAngles -= new Vector3(0, 0, 7) * fSpeed;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "CheckWall" || col.gameObject.tag == "FrontWall")
        {
            bStopState = true;
            fSpeed = 0.0f;
            ScoreLabel.animation["ScoreLabel"].normalizedTime = 1f;
            ScoreLabel.animation["ScoreLabel"].speed = -1;
            ScoreLabel.animation.Play("ScoreLabel");
        }

        else if (col.gameObject.tag == "ScoreWall")
        {
            AudioSource.PlayClipAtPoint(EffectAudio, transform.position);
            nCheckNum++;
        }
    }
}