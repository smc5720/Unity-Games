using UnityEngine;
using System.Collections;

public class InvokePercentBtn : MonoBehaviour {
    public AudioClip ButtonAudio;
    public UILabel DPercentLabel;
    public UILabel DPercentPrizeLabel;
    public UILabel IncreaseLabel;

    // Use this for initialization
    void Start()
    {
        if (HeroStateMng.I.nDPercentLevel <= 5)
        {
            if (HeroStateMng.I.nDPercentPrize <= HeroStateMng.I.nMoney)
            {
                DPercentLabel.GetComponent<UILabel>().text = HeroStateMng.I.nDPercentLevel.ToString();
                DPercentPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDPercentLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "% -> " + ((HeroStateMng.I.nDPercent) + 15).ToString() + "%)";
            }
        }

        if (HeroStateMng.I.nDPercentLevel == 6)
        {
            DPercentLabel.GetComponent<UILabel>().text = "Max";
            DPercentPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "%)";
        }

        else if (HeroStateMng.I.nDPercentLevel >= 6)
        {
            DPercentLabel.GetComponent<UILabel>().text = "Max";
            DPercentPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "%)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeroStateMng.I.nDPercentPrize = HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDPercentLevel;
        if (HeroStateMng.I.nDPercentPrize <= HeroStateMng.I.nMoney)
        {
            gameObject.GetComponent<UIButton>().isEnabled = true;
        }

        if (HeroStateMng.I.nDPercentPrize > HeroStateMng.I.nMoney || HeroStateMng.I.nDPercentLevel > 5)
        {
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }
    }

    void OnClick()
    {
        HeroStateMng.I.nDPercentLevel++;
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        if (HeroStateMng.I.nDPercentLevel <= 5)
        {
            if (HeroStateMng.I.nDPercentPrize <= HeroStateMng.I.nMoney)
            {
                HeroStateMng.I.nMoney -= HeroStateMng.I.nDPercentPrize;
                HeroStateMng.I.nDPercent += 15;
                DPercentLabel.GetComponent<UILabel>().text = HeroStateMng.I.nDPercentLevel.ToString();
                DPercentPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDPercentLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "% -> " + ((HeroStateMng.I.nDPercent) + 15).ToString() + "%)";
            }
        }

        if (HeroStateMng.I.nDPercentLevel == 6)
        {
            HeroStateMng.I.nMoney -= HeroStateMng.I.nDPercentPrize;
            HeroStateMng.I.nDPercent += 15;
            DPercentLabel.GetComponent<UILabel>().text = "Max";
            DPercentPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "%)";
        }

        else if (HeroStateMng.I.nDPercentLevel >= 6)
        {
            DPercentLabel.GetComponent<UILabel>().text = "Max";
            DPercentPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nDPercent).ToString() + "%)";
        }
    }
}
