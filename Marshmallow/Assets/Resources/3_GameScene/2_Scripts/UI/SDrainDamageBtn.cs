using UnityEngine;
using System.Collections;

public class SDrainDamageBtn : MonoBehaviour
{
    public AudioClip ButtonAudio;
    public UILabel DrainLabel;
    public UILabel DrainPrizeLabel;
    public UILabel IncreaseLabel;

    // Use this for initialization
    void Start()
    {
        if (HeroStateMng.I.nDrainLevel <= 5)
        {
            if (HeroStateMng.I.nDrainPrize <= HeroStateMng.I.nMoney)
            {
                DrainLabel.GetComponent<UILabel>().text = HeroStateMng.I.nDrainLevel.ToString();
                DrainPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDrainLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(+0.0" + (HeroStateMng.I.nDrain).ToString() + " -> +0.0" + ((HeroStateMng.I.nDrain) + 2).ToString() + ")";
            }
        }

        if (HeroStateMng.I.nDrainLevel == 6)
        {
            DrainLabel.GetComponent<UILabel>().text = "Max";
            DrainPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(0.0" + (HeroStateMng.I.nDrain).ToString() + ")";
        }

        else if (HeroStateMng.I.nDrainLevel >= 6)
        {
            DrainLabel.GetComponent<UILabel>().text = "Max";
            DrainPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(0.0" + (HeroStateMng.I.nDrain).ToString() + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeroStateMng.I.nDrainPrize = HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDrainLevel;
        if (HeroStateMng.I.nDrainPrize <= HeroStateMng.I.nMoney)
        {
            gameObject.GetComponent<UIButton>().isEnabled = true;
        }

        if (HeroStateMng.I.nDrainPrize > HeroStateMng.I.nMoney || HeroStateMng.I.nDrainLevel > 5)
        {
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }
    }

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        HeroStateMng.I.nDrainLevel++;
        if (HeroStateMng.I.nDrainLevel <= 5)
        {
            if (HeroStateMng.I.nDrainPrize <= HeroStateMng.I.nMoney)
            {
                HeroStateMng.I.nMoney -= HeroStateMng.I.nDrainPrize;
                HeroStateMng.I.fDrain += 0.02f;
                HeroStateMng.I.nDrain += 2;
                DrainLabel.GetComponent<UILabel>().text = HeroStateMng.I.nDrainLevel.ToString();
                DrainPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nCOriPrize * HeroStateMng.I.nDrainLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(+0.0" + (HeroStateMng.I.nDrain).ToString() + " -> +0.0" + ((HeroStateMng.I.nDrain) + 2).ToString() + ")";
            }
        }

        if (HeroStateMng.I.nDrainLevel == 6)
        {
            HeroStateMng.I.nMoney -= HeroStateMng.I.nDrainPrize;
            HeroStateMng.I.fDrain += 0.02f;
            HeroStateMng.I.nDrain += 2;
            DrainLabel.GetComponent<UILabel>().text = "Max";
            DrainPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(+0.0" + (HeroStateMng.I.nDrain).ToString() + ")";
        }

        else if (HeroStateMng.I.nDrainLevel >= 6)
        {
            DrainLabel.GetComponent<UILabel>().text = "Max";
            DrainPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(+0.0" + (HeroStateMng.I.nDrain).ToString() + ")";
        }
    }
}
