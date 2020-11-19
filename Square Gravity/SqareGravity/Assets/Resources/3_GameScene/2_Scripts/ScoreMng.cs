using UnityEngine;
using System.Collections;

public class ScoreMng : MonoBehaviour
{

    public UILabel HighScore;
    public UILabel Score;
    public Mng Manager;
    // Use this for initialization
    void Start()
    {
        Manager = GameObject.Find("Mng").GetComponent<Mng>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Manager.Score);
        }
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();

        Score.text = Manager.Score.ToString();

    }
}
