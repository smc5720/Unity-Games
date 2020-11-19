using UnityEngine;
using System.Collections;

public class SAttackPowerBtn : MonoBehaviour
{
    public AudioClip ButtonAudio;
    public UILabel BulletPowerLabel;
    public UILabel PowerPrizeLabel;
    public UILabel IncreaseLabel;

    // Use this for initialization
    void Start()
    {
        if (HeroStateMng.I.nPowerLevel <= 5)
        {
            if (HeroStateMng.I.nPowerPrize <= HeroStateMng.I.nMoney)
            {
                BulletPowerLabel.GetComponent<UILabel>().text = HeroStateMng.I.nPowerLevel.ToString();
                PowerPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nAOriPrize * HeroStateMng.I.nPowerLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + " -> " + ((HeroStateMng.I.fBulletDamage) + 1.0f).ToString() + ")";
            }
        }

        if (HeroStateMng.I.nPowerLevel == 6)
        {
            BulletPowerLabel.GetComponent<UILabel>().text = "Max";
            PowerPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + ")";
        }

        else if (HeroStateMng.I.nPowerLevel >= 6)
        {
            BulletPowerLabel.GetComponent<UILabel>().text = "Max";
            PowerPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeroStateMng.I.nPowerPrize = HeroStateMng.I.nAOriPrize * HeroStateMng.I.nPowerLevel;
        if (HeroStateMng.I.nPowerPrize <= HeroStateMng.I.nMoney)
        {
            gameObject.GetComponent<UIButton>().isEnabled = true;
        }

        if (HeroStateMng.I.nPowerPrize > HeroStateMng.I.nMoney || HeroStateMng.I.nPowerLevel > 5)
        {
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }
    }

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        HeroStateMng.I.nPowerLevel++;
        if (HeroStateMng.I.nPowerLevel <= 5)
        {
            if (HeroStateMng.I.nPowerPrize <= HeroStateMng.I.nMoney)
            {
                HeroStateMng.I.nMoney -= HeroStateMng.I.nPowerPrize;
                HeroStateMng.I.fBulletDamage += 1.0f;
                BulletPowerLabel.GetComponent<UILabel>().text = HeroStateMng.I.nPowerLevel.ToString();
                PowerPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nAOriPrize * HeroStateMng.I.nPowerLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + " -> " + ((HeroStateMng.I.fBulletDamage) + 1.0f).ToString() + ")";
            }
        }

        if (HeroStateMng.I.nPowerLevel == 6)
        {
            HeroStateMng.I.nMoney -= HeroStateMng.I.nPowerPrize;
            HeroStateMng.I.fBulletDamage += 1.0f;
            BulletPowerLabel.GetComponent<UILabel>().text = "Max";
            PowerPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + ")";
        }

        else if (HeroStateMng.I.nPowerLevel >= 6)
        {
            BulletPowerLabel.GetComponent<UILabel>().text = "Max";
            PowerPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletDamage).ToString() + ")";
        }
    }
}
