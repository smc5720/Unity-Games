using UnityEngine;
using System.Collections;
using System.Text;

public class ScoreLabel : MonoBehaviour
{
    BallSingleTon BallSingle;
    UILabel ScoreText;
    string sScore;
    float fTimer;
    private int[] process = new int[7];
    private int[] now = new int[7];

    enum uTextNum
    {
        Score
    }

    // Use this for initialization
    void Start()
    {
        fTimer = 0.0f;
        ScoreText = gameObject.GetComponent<UILabel>();
        BallSingle = BallSingleTon.I;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.03f)
        {
            scoreUpdate(BallSingle.nScore, now, process);
        }

        ScoreText.text = Translater(uTextNum.Score, "");
    }

    void scoreUpdate(int score, int[] now, int[] process)
    {
        for (int i = 0; i < now.Length; i++)
        {
            now[i] = score / ScoreCal(now.Length - i);
            score -= now[i] * ScoreCal(now.Length - i);

            if (process[i] != now[i])
            {
                process[i] += 1;
                if (process[i] >= 10)
                {
                    process[i] = 0;
                }
            }
        }
    }

    int ScoreCal(int amount)
    {
        int r = 1;
        for (int i = 1; i < amount; i++)
        {
            r *= 10;
        }
        return r;
    }

    string Translater(uTextNum fText, string firstText)
    {
        StringBuilder Score = new StringBuilder(firstText);

        for (int i = 0; i < (fText == uTextNum.Score ? 7 : 5); i++)
        {
            if (fText == uTextNum.Score)
            {
                Score.Append(process[i]);
            }
        }
        return Score.ToString();
    }
}
