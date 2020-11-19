using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour
{
    UILabel HighLabel;
    int nHighScore;
    // Use this for initialization
    void Start()
    {
        HighLabel = gameObject.GetComponent<UILabel>();
        //ResetData();
        GetData();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") < BallSingleTon.I.nScore)
        {
            SaveData();
            GetData();
        }
        HighLabel.text = nHighScore.ToString();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", BallSingleTon.I.nScore);
    }

    public void GetData()
    {
        nHighScore = PlayerPrefs.GetInt("HighScore");
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}