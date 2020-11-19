using UnityEngine;
using System.Collections;

public class CriticalBtn : MonoBehaviour
{
    public AudioClip ButtonAudio;
    public UILabel CriticalLabel;
    public UILabel CriticalPrizeLabel;
    public UILabel IncreaseLabel;

    // Use this for initialization
    void Start()
    {
        if (HeroStateMng.I.nCriticalLevel <= 5)
        {
            if (HeroStateMng.I.nCriticalPrize <= HeroStateMng.I.nMoney)
            {
                CriticalLabel.GetComponent<UILabel>().text = HeroStateMng.I.nCriticalLevel.ToString();
                CriticalPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nBOriPrize * HeroStateMng.I.nCriticalLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "% -> " + ((HeroStateMng.I.nCritical) + 10).ToString() + "%)";
            }
        }

        if (HeroStateMng.I.nCriticalLevel == 6)
        {
            CriticalLabel.GetComponent<UILabel>().text = "Max";
            CriticalPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "%)";
        }

        else if (HeroStateMng.I.nCriticalLevel >= 6)
        {
            CriticalLabel.GetComponent<UILabel>().text = "Max";
            CriticalPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "%)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeroStateMng.I.nCriticalPrize = HeroStateMng.I.nBOriPrize * HeroStateMng.I.nCriticalLevel;
        if (HeroStateMng.I.nCriticalPrize <= HeroStateMng.I.nMoney)
        {
            gameObject.GetComponent<UIButton>().isEnabled = true;
        }

        if (HeroStateMng.I.nCriticalPrize > HeroStateMng.I.nMoney || HeroStateMng.I.nCriticalLevel > 5)
        {
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }
    }

    void OnClick()
    {
        HeroStateMng.I.nCriticalLevel++;
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        if (HeroStateMng.I.nCriticalLevel <= 5)
        {
            if (HeroStateMng.I.nCriticalPrize <= HeroStateMng.I.nMoney)
            {
                HeroStateMng.I.nMoney -= HeroStateMng.I.nCriticalPrize;
                HeroStateMng.I.fCriticalDmg += 0.1f;
                HeroStateMng.I.nCritical += 10;
                CriticalLabel.GetComponent<UILabel>().text = HeroStateMng.I.nCriticalLevel.ToString();
                CriticalPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nBOriPrize * HeroStateMng.I.nCriticalLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "% -> " + ((HeroStateMng.I.nCritical) + 10).ToString() + "%)";
            }
        }

        if (HeroStateMng.I.nCriticalLevel == 6)
        {
            HeroStateMng.I.nMoney -= HeroStateMng.I.nCriticalPrize;
            HeroStateMng.I.fCriticalDmg += 1.0f;
            HeroStateMng.I.nCritical += 10;
            CriticalLabel.GetComponent<UILabel>().text = "Max";
            CriticalPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "%)";
        }

        else if (HeroStateMng.I.nCriticalLevel >= 6)
        {
            CriticalLabel.GetComponent<UILabel>().text = "Max";
            CriticalPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.nCritical).ToString() + "%)";
        }
    }
}
