using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour
{
    public GameObject Text1, Text2;
    UILabel Label1, Label2;
    float fTimer;
    int nNumber;
    public GameObject ResultPopup;
    public GameObject OkBtn;
    bool bState;

    // Use this for initialization
    void Start()
    {
        Label1 = Text1.GetComponent<UILabel>();
        Label2 = Text2.GetComponent<UILabel>();
        fTimer = 0.0f;
        Label1.text = "0";
        nNumber = 0;
        bState = false;
        OkBtn.GetComponent<UIButton>().isEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ResultPopup.transform.localPosition.y >= -5)
        {
            fTimer += Time.deltaTime;

            if (bState == false && PlayerPrefs.GetInt("CurrentScore") == nNumber)
            {
                bState = true;
                OkBtn.GetComponent<UIButton>().isEnabled = true;
            }

            if (PlayerPrefs.GetInt("CurrentScore") > nNumber)
            {
                if (fTimer >= 0.1f)
                {
                    fTimer = 0;
                    nNumber++;
                }
            }
        }

        if (nNumber >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", nNumber);
        }

        Label1.text = nNumber.ToString();
        Label2.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void OnClick()
    {
        if (PlayerPrefs.GetInt("CurrentScore") > nNumber)
        {
            nNumber = PlayerPrefs.GetInt("CurrentScore") - 1;
        }
    }

    void OkBtnClick()
    {
        Application.LoadLevel("2_StartScene");
    }
}