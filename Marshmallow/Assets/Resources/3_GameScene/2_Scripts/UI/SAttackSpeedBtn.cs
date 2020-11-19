using UnityEngine;
using System.Collections;

public class SAttackSpeedBtn : MonoBehaviour
{
    public AudioClip ButtonAudio;
    public UILabel BulletSpeedLabel;
    public UILabel SpeedPrizeLabel;
    public UILabel IncreaseLabel;

    // Use this for initialization
    void Start()
    {
        if (HeroStateMng.I.nSpeedLevel <= 5)
        {
            if (HeroStateMng.I.nSpeedPrize <= HeroStateMng.I.nMoney)
            {
                BulletSpeedLabel.GetComponent<UILabel>().text = HeroStateMng.I.nSpeedLevel.ToString();
                SpeedPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nAOriPrize * HeroStateMng.I.nSpeedLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + " -> " + ((HeroStateMng.I.fBulletSpeed) - 0.015f).ToString() + ")";
            }
        }

        else if (HeroStateMng.I.nSpeedLevel == 6)
        {
            BulletSpeedLabel.GetComponent<UILabel>().text = "Max";
            SpeedPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + ")";
        }

        else if (HeroStateMng.I.nSpeedLevel > 6)
        {
            BulletSpeedLabel.GetComponent<UILabel>().text = "Max";
            SpeedPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        HeroStateMng.I.nSpeedPrize = HeroStateMng.I.nAOriPrize * HeroStateMng.I.nSpeedLevel;
        if (HeroStateMng.I.nSpeedPrize <= HeroStateMng.I.nMoney)
        {
            gameObject.GetComponent<UIButton>().isEnabled = true;
        }

        if (HeroStateMng.I.nSpeedPrize > HeroStateMng.I.nMoney || HeroStateMng.I.nSpeedLevel > 5)
        {
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }
    }

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(ButtonAudio, transform.position);
        HeroStateMng.I.nSpeedLevel++;
        if (HeroStateMng.I.nSpeedLevel <= 5)
        {
            if (HeroStateMng.I.nSpeedPrize <= HeroStateMng.I.nMoney)
            {
                HeroStateMng.I.nMoney -= HeroStateMng.I.nSpeedPrize;
                HeroStateMng.I.fBulletSpeed -= 0.015f;
                BulletSpeedLabel.GetComponent<UILabel>().text = HeroStateMng.I.nSpeedLevel.ToString();
                SpeedPrizeLabel.GetComponent<UILabel>().text = "$ " + (HeroStateMng.I.nAOriPrize * HeroStateMng.I.nSpeedLevel).ToString();
                IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + " -> " + ((HeroStateMng.I.fBulletSpeed) - 0.015f).ToString() + ")";
            }
        }

        else if (HeroStateMng.I.nSpeedLevel == 6)
        {
            HeroStateMng.I.nMoney -= HeroStateMng.I.nSpeedPrize;
            HeroStateMng.I.fBulletSpeed -= 0.015f;
            BulletSpeedLabel.GetComponent<UILabel>().text = "Max";
            SpeedPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + ")";
        }

        else if (HeroStateMng.I.nSpeedLevel > 6)
        {
            BulletSpeedLabel.GetComponent<UILabel>().text = "Max";
            SpeedPrizeLabel.GetComponent<UILabel>().text = "Max";
            IncreaseLabel.GetComponent<UILabel>().text = "(" + (HeroStateMng.I.fBulletSpeed).ToString() + ")";
        }
    }
}
