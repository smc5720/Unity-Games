using UnityEngine;
using System.Collections;

public class EndingMng : MonoBehaviour
{
    float fTimer;
    public GameObject BlackPanel;
    bool bState;

    // Use this for initialization
    void Start()
    {
        fTimer = 0;
        bState = false;

        PlayerPrefs.SetInt("Prestige", PlayerPrefs.GetInt("Prestige") + 1);
    }

    // Update is called once per frame
    void Update()
    {

        fTimer += Time.deltaTime;

        if (fTimer >= 6.0f && bState == false)
        {
            TweenAlpha.Begin(BlackPanel, 1.0f, 1.0f);
            bState = true;
        }

        if (fTimer >= 7.0f)
        {
            Application.LoadLevel("1_TitleScene");
        }
    }
}