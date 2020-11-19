using UnityEngine;
using System.Collections;

public class StartBtn : MonoBehaviour
{
    public GameObject GameTitle;
    public GameObject TeamLogo;
    public GameObject HighScore;
    public GameObject Camera2D;
    public GameObject BackGround;
    bool bState, bAniState;
    float fTimer = 0.0f;
    float fAniTimer = 0.0f;
    public float fSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {
        GameTitle.animation["Title"].normalizedTime = 1f;
        GameTitle.animation["Title"].speed = -1;
        GameTitle.animation.Play("Title");

        TeamLogo.animation["TeamLogo"].normalizedTime = 1f;
        TeamLogo.animation["TeamLogo"].speed = -1;
        TeamLogo.animation.Play("TeamLogo");

        HighScore.animation["HighScore"].normalizedTime = 1f;
        HighScore.animation["HighScore"].speed = -1;
        HighScore.animation.Play("HighScore");

        gameObject.animation["StartButton"].normalizedTime = 1f;
        gameObject.animation["StartButton"].speed = -1;
        gameObject.animation.Play("StartButton");

        bState = false;
        bAniState = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        fAniTimer += Time.deltaTime;

        if (fAniTimer >= 0.7f && bAniState == false)
        {
            bAniState = true;
            GameTitle.animation["StopTitle"].speed = 1;
            GameTitle.animation.Play("StopTitle");
        }

        if (bState == true)
        {
            fTimer += Time.deltaTime;

            if (fTimer >= 0.7f)
            {
                Application.LoadLevel("3_GameScene");
            }
        }
    }

    void OnClick()
    {
        bState = true;
        fSpeed = 0.0f;
        TweenPosition.Begin(Camera2D, 0.5f, new Vector3(BackGround.transform.localPosition.x, 0, 0));
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameTitle.animation["Title"].speed = 1;
        GameTitle.animation.Play("Title");
        TeamLogo.animation["TeamLogo"].speed = 1;
        TeamLogo.animation.Play("TeamLogo");
        HighScore.animation["HighScore"].speed = 1;
        HighScore.animation.Play("HighScore");
        gameObject.animation["StartButton"].speed = 1;
        gameObject.animation.Play("StartButton");
    }
}