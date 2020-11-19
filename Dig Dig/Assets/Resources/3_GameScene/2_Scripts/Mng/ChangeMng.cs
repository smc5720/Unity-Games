using UnityEngine;
using System.Collections;

public class ChangeMng : MonoBehaviour
{
    public UILabel[] JewelryLabel = new UILabel[7];
    public UIButton[] JewelryButton = new UIButton[7];
    int[] JewelryValue = { 1500, 18000, 70000, 150000, 350000, 900000, 1500000 };
    float fTimer;
    int labelTimer;

    public UILabel TimerLabel;

    long[] ChangePer = new long[7];

    public UILabel[] JewelryValueLabel = new UILabel[7];

    public UISprite[] Graph = new UISprite[7];

    public AudioClip GraphSound;

    // Use this for initialization
    void Start()
    {
        fTimer = 10.0f;

        for (int i = 0; i < 7; i++)
        {
            ChangePer[i] = TouchAndEarn.I.ChangeFunc();

            if (i == 6)
            {
                PlayerPrefs.SetInt("NewsPaper", 1);
            }
        }

        JewelryValueLabel[0].text = "1.5K";

        JewelryValueLabel[1].text = "18K";

        JewelryValueLabel[2].text = "70K";

        JewelryValueLabel[3].text = "150K";

        JewelryValueLabel[4].text = "350K";

        JewelryValueLabel[5].text = "900K";

        JewelryValueLabel[6].text = "1.5M";
    }

    // Update is called once per frame
    void Update()
    {
        labelTimer = (int)fTimer;
        TimerLabel.text = "0" + labelTimer / 60 + " : " + labelTimer % 60;

        fTimer -= Time.deltaTime;

        if (fTimer <= 0.0f)
        {
            fTimer = 10;

            AudioSource.PlayClipAtPoint(GraphSound, transform.position);

            for (int i = 0; i < 7; i++)
            {
                ChangePer[i] = TouchAndEarn.I.ChangeFunc();

                if (i == 6)
                {
                    PlayerPrefs.SetInt("NewsPaper", 1);
                }
            }
        }

        for (int i = 0; i < 7; i++)
        {
            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                Graph[i].fillAmount = (float)(ChangePer[i] - 30) / 140;

                if (ChangePer[i] <= 100)
                {
                    Graph[i].spriteName = "Rad Graph";
                }

                else
                {
                    Graph[i].spriteName = "Blue Graph";
                }
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                Graph[i].fillAmount = (float)(140 / 140);
                Graph[i].spriteName = "Blue Graph";
            }
        }

        JewelryLabel[0].text = PlayerPrefs.GetInt("Bronze").ToString();

        JewelryLabel[1].text = PlayerPrefs.GetInt("Silver").ToString();

        JewelryLabel[2].text = PlayerPrefs.GetInt("Gold").ToString();

        JewelryLabel[3].text = PlayerPrefs.GetInt("Amethyst").ToString();

        JewelryLabel[4].text = PlayerPrefs.GetInt("Topaz").ToString();

        JewelryLabel[5].text = PlayerPrefs.GetInt("Sapire").ToString();

        JewelryLabel[6].text = PlayerPrefs.GetInt("Ruby").ToString();

        if (PlayerPrefs.GetInt("Bronze") == 0)
        {
            JewelryButton[0].isEnabled = false;
        }

        else
        {
            JewelryButton[0].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Silver") == 0)
        {
            JewelryButton[1].isEnabled = false;
        }

        else
        {
            JewelryButton[1].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Gold") == 0)
        {
            JewelryButton[2].isEnabled = false;
        }

        else
        {
            JewelryButton[2].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Amethyst") == 0)
        {
            JewelryButton[3].isEnabled = false;
        }

        else
        {
            JewelryButton[3].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Topaz") == 0)
        {
            JewelryButton[4].isEnabled = false;
        }

        else
        {
            JewelryButton[4].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Sapire") == 0)
        {
            JewelryButton[5].isEnabled = false;
        }

        else
        {
            JewelryButton[5].isEnabled = true;
        }

        if (PlayerPrefs.GetInt("Ruby") == 0)
        {
            JewelryButton[6].isEnabled = false;
        }

        else
        {
            JewelryButton[6].isEnabled = true;
        }
    }

    void ChangeButton(GameObject Obj)
    {
        if (Obj.gameObject.tag == "Bronze")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Bronze");
            num2 = JewelryValue[0];

            if (ChangePer[0] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[0] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[0] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Bronze", 0);
        }

        else if (Obj.gameObject.tag == "Silver")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Silver");
            num2 = JewelryValue[1];

            if (ChangePer[1] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[1] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[1] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Silver", 0);
        }

        else if (Obj.gameObject.tag == "Gold")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Gold");
            num2 = JewelryValue[2];

            if (ChangePer[2] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[2] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[2] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Gold", 0);
        }

        else if (Obj.gameObject.tag == "Amethyst")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Amethyst");
            num2 = JewelryValue[3];

            if (ChangePer[3] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[3] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[3] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Amethyst", 0);
        }

        else if (Obj.gameObject.tag == "Topaz")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Topaz");
            num2 = JewelryValue[4];

            if (ChangePer[4] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[4] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[4] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Topaz", 0);
        }

        else if (Obj.gameObject.tag == "Sapire")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Sapire");
            num2 = JewelryValue[5];

            if (ChangePer[5] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[5] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[5] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Sapire", 0);
        }

        else if (Obj.gameObject.tag == "Ruby")
        {
            long num1, num2;
            num1 = PlayerPrefs.GetInt("Ruby");
            num2 = JewelryValue[6];

            if (ChangePer[6] == 40)
            {
                PlayerPrefs.SetInt("Q_Smallest", PlayerPrefs.GetInt("Q_Smallest") + (int)num1);
            }

            else if (ChangePer[6] == 170)
            {
                PlayerPrefs.SetInt("Q_Biggest", PlayerPrefs.GetInt("Q_Biggest") + (int)num1);
            }

            if (PlayerPrefs.GetInt("Skill_3") != 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(ChangePer[6] / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            else if (PlayerPrefs.GetInt("Skill_3") == 1)
            {
                long Jewelry = (long)(num1 * num2 * (float)(170 / (float)100));
                TouchAndEarn.I.nAllMoney += Jewelry;
            }

            PlayerPrefs.SetInt("Ruby", 0);
        }
    }
}