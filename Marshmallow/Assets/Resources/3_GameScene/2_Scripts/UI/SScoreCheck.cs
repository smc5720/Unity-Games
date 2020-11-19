using UnityEngine;
using System.Collections;
using System.Text;

public class SScoreCheck : MonoBehaviour {
    public UILabel ScoreLabel;
    public UILabel MoneyLabel;
    string sScore;
    string sMoney;
    float fTimer;
    private int[] process = new int[8];
    private int[] now = new int[8];
    private int[] process2 = new int[5];
    private int[] now2 = new int[5];

    enum uTextNum
    {
        Score, Money
    }

	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.03f)
        {
            scoreUpdate(HeroStateMng.I.nScore, now, process);
        }

        ScoreLabel.GetComponent<UILabel>().text = Translater(uTextNum.Score, "Á¡¼ö: ");

        if (fTimer >= 0.03f)
        {
            scoreUpdate(HeroStateMng.I.nMoney, now2, process2);
            fTimer = 0;
        }

        MoneyLabel.GetComponent<UILabel>().text = Translater(uTextNum.Money, "$ ");
    }

    void scoreUpdate(int score, int[]now, int[]process)
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

        for (int i = 0; i < (fText == uTextNum.Score ? 8 : 5); i++)
        {
            if (fText == uTextNum.Score)
            {
                Score.Append(process[i]);
            }

            else
            {
                Score.Append(process2[i]);
            }
        }
        return Score.ToString();
    }
}
