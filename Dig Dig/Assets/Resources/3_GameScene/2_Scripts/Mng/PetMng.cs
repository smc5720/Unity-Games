using UnityEngine;
using System.Collections;

public class PetMng : MonoBehaviour
{
    float[] fTimer = new float[6];

    int[] RandomNum = new int[6];

    float[] HitDelay = new float[6];

    int[] nPetPercent = { 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };

    public GameObject StoneVib;

    public UILabel[] LevelLabel = new UILabel[6];

    public UILabel[] PrizeLabel = new UILabel[6];

    public UILabel[] Pre_Damage = new UILabel[6];

    public UILabel[] Cur_Damage = new UILabel[6];

    public GameObject[] Max = new GameObject[6];

    public UIButton[] LevelButton = new UIButton[6];

    public UISprite[] ButtonSprite = new UISprite[6];

    public UISprite[] PanelSprite = new UISprite[6];

    public GameObject[] Pets = new GameObject[6];

    public UISprite[] LevelSprite = new UISprite[6];

    long[] SilverPetValue = { 0, 16000000, 17000000, 18000000, 19000000, 20000000, 21000000, 22000000, 23000000, 24000000 };

    long[] GoldPetValue = { 0, 50000000, 65000000, 80000000, 95000000, 110000000, 125000000, 140000000, 155000000, 170000000 };

    long[] AmethystPetValue = { 0, 200000000, 250000000, 300000000, 350000000, 400000000, 450000000, 500000000, 550000000, 600000000 };

    long[] TopazPetValue = { 0, 1000000000, 1200000000, 1400000000, 1600000000, 1800000000, 2000000000, 2200000000, 2400000000, 2600000000 };

    long[] SapirePetValue = { 0, 7000000000, 7200000000, 7400000000, 7600000000, 7800000000, 8000000000, 8200000000, 8400000000, 8600000000 };

    long[] RubyPetValue = { 0, 10000000000, 11000000000, 12000000000, 13000000000, 14000000000, 15000000000, 16000000000, 17000000000, 18000000000 };


    string[] s_SilverValue = { "0", "16M", "17M", "18M", "19M", "20M", "21M", "22M", "23M", "24M" };

    string[] s_GoldValue = { "0", "50M", "65M", "80M", "95M", "110M", "125M", "140M", "155M", "170M" };

    string[] s_AmethystValue = { "0", "200M", "250M", "300M", "350M", "400M", "450M", "500M", "550M", "600M" };

    string[] s_TopazValue = { "0", "1B", "1.2B", "1.4B", "1.6B", "1.8B", "2B", "2.2B", "2.4B", "2.6B" };

    string[] s_SapireValue = { "0", "7B", "7.2B", "7.4B", "7.6B", "7.8B", "8B", "8.2B", "8.4B", "8.6B" };

    string[] s_RubyValue = { "0", "10B", "11B", "12B", "13B", "14B", "15B", "16B", "17B", "18B" };


    int[] SliverPetDamage = { 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 6000 };

    int[] GoldPetDamage = { 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000, 50000, 55000 };

    int[] AmethystPetDamage = { 70000, 100000, 130000, 160000, 190000, 220000, 250000, 280000, 310000, 340000 };

    int[] TopazPetDamage = { 1000000, 1300000, 1600000, 1900000, 2200000, 2500000, 2800000, 3100000, 3400000, 3700000 };

    int[] SapirePetDamage = { 4100000, 4600000, 5100000, 5600000, 6100000, 6600000, 7100000, 7600000, 8100000, 8600000 };

    int[] RubyPetDamage = { 21000000, 23000000, 25000000, 27000000, 29000000, 31000000, 33000000, 35000000, 37000000, 39000000 };


    string[] s_SilverDamage = { "1.5K", "2K", "2.5K", "3K", "3.5K", "4K", "4.5K", "5K", "5.5K", "6K" };

    string[] s_GoldDamage = { "10K", "15K", "20K", "25K", "30K", "35K", "40K", "45K", "50K", "55K" };

    string[] s_AmethystDamage = { "70K", "100K", "130K", "160K", "190K", "220K", "250K", "280K", "310K", "340K" };

    string[] s_TopazDamage = { "1M", "1.3M", "1.6M", "1.9M", "2.2M", "2.5M", "2.8M", "3.1M", "3.4M", "3.7M" };

    string[] s_SapireDamage = { "4.1M", "4.6M", "5.1M", "5.6M", "6.1M", "6.6M", "7.1M", "7.6M", "8.1M", "8.6M" };

    string[] s_RubyDamage = { "21M", "23M", "25M", "27M", "29M", "31M", "33M", "35M", "37M", "39M" };

    bool bState;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            fTimer[i] = 0.0f;
        }

        bState = false;

        HitDelay[0] = 1.2f;
        HitDelay[1] = 1.5f;
        HitDelay[2] = 1.0f;
        HitDelay[3] = 0.8f;
        HitDelay[4] = 1.0f;
        HitDelay[5] = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pets[2].transform.localPosition.x >= -1000 && bState == false)
        {
            Pets[2].animation.Play("Amethyst");
            bState = true;
        }

        if (PlayerPrefs.GetInt("Pet_Silver") >= 1 && PlayerPrefs.GetInt("Pet_Silver") < 10)
        {
            PrizeLabel[0].text = s_SilverValue[PlayerPrefs.GetInt("Pet_Silver")].ToString();
            Pre_Damage[0].text = s_SilverDamage[PlayerPrefs.GetInt("Pet_Silver") - 1].ToString();
            Cur_Damage[0].text = s_SilverDamage[PlayerPrefs.GetInt("Pet_Silver")].ToString();
            LevelSprite[0].spriteName = PlayerPrefs.GetInt("Pet_Silver").ToString();
            LevelSprite[0].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[0].transform.localPosition = new Vector3(1600, 0, -15);
        }

        else if (PlayerPrefs.GetInt("Pet_Silver") >= 10)
        {
            PrizeLabel[0].text = "A";
            Pre_Damage[0].text = s_SilverDamage[PlayerPrefs.GetInt("Pet_Silver") - 1].ToString();
            Cur_Damage[0].text = s_SilverDamage[PlayerPrefs.GetInt("Pet_Silver") - 1].ToString();
            LevelSprite[0].spriteName = "10";
            LevelSprite[0].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[0].transform.localPosition = new Vector3(0, 0, -15);
        }

        if (PlayerPrefs.GetInt("Pet_Gold") >= 1 && PlayerPrefs.GetInt("Pet_Gold") < 10)
        {
            PrizeLabel[1].text = s_GoldValue[PlayerPrefs.GetInt("Pet_Gold")].ToString();
            Pre_Damage[1].text = s_GoldDamage[PlayerPrefs.GetInt("Pet_Gold") - 1].ToString();
            Cur_Damage[1].text = s_GoldDamage[PlayerPrefs.GetInt("Pet_Gold")].ToString();
            LevelSprite[1].spriteName = PlayerPrefs.GetInt("Pet_Gold").ToString();
            LevelSprite[1].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[1].transform.localPosition = new Vector3(1600, 0, -15);
        }

        else if (PlayerPrefs.GetInt("Pet_Gold") >= 10)
        {
            PrizeLabel[1].text = "A";
            Pre_Damage[1].text = s_GoldDamage[PlayerPrefs.GetInt("Pet_Gold") - 1].ToString();
            Cur_Damage[1].text = s_GoldDamage[PlayerPrefs.GetInt("Pet_Gold") - 1].ToString();
            LevelSprite[1].spriteName = "10";
            LevelSprite[1].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[1].transform.localPosition = new Vector3(0, 0, -15);
        }

        if (PlayerPrefs.GetInt("Pet_Amethyst") >= 1 && PlayerPrefs.GetInt("Pet_Amethyst") < 10)
        {
            PrizeLabel[2].text = s_AmethystValue[PlayerPrefs.GetInt("Pet_Amethyst")].ToString();
            Pre_Damage[2].text = s_AmethystDamage[PlayerPrefs.GetInt("Pet_Amethyst") - 1].ToString();
            Cur_Damage[2].text = s_AmethystDamage[PlayerPrefs.GetInt("Pet_Amethyst")].ToString();
            LevelSprite[2].spriteName = PlayerPrefs.GetInt("Pet_Amethyst").ToString();
            LevelSprite[2].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[2].transform.localPosition = new Vector3(1600, 0, -15);
        }

        else if (PlayerPrefs.GetInt("Pet_Amethyst") >= 10)
        {
            PrizeLabel[2].text = "A";
            Pre_Damage[2].text = s_AmethystDamage[PlayerPrefs.GetInt("Pet_Amethyst") - 1].ToString();
            Cur_Damage[2].text = s_AmethystDamage[PlayerPrefs.GetInt("Pet_Amethyst") - 1].ToString();
            LevelSprite[2].spriteName = "10";
            LevelSprite[2].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[2].transform.localPosition = new Vector3(0, 0, -15);
        }

        if (PlayerPrefs.GetInt("Pet_Topaz") >= 1 && PlayerPrefs.GetInt("Pet_Topaz") < 10)
        {
            PrizeLabel[3].text = s_TopazValue[PlayerPrefs.GetInt("Pet_Topaz")].ToString();
            Pre_Damage[3].text = s_TopazDamage[PlayerPrefs.GetInt("Pet_Topaz") - 1].ToString();
            Cur_Damage[3].text = s_TopazDamage[PlayerPrefs.GetInt("Pet_Topaz")].ToString();
            LevelSprite[3].spriteName = PlayerPrefs.GetInt("Pet_Topaz").ToString();
            LevelSprite[3].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[3].transform.localPosition = new Vector3(1600, 0, -15);
        }

        else if (PlayerPrefs.GetInt("Pet_Topaz") >= 10)
        {
            PrizeLabel[3].text = "A";
            Pre_Damage[3].text = s_TopazDamage[PlayerPrefs.GetInt("Pet_Topaz") - 1].ToString();
            Cur_Damage[3].text = s_TopazDamage[PlayerPrefs.GetInt("Pet_Topaz") - 1].ToString();
            LevelSprite[3].spriteName = "10";
            LevelSprite[3].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[3].transform.localPosition = new Vector3(0, 0, -15);
        }

        if (PlayerPrefs.GetInt("Pet_Sapire") >= 1 && PlayerPrefs.GetInt("Pet_Sapire") < 10)
        {
            PrizeLabel[4].text = s_SapireValue[PlayerPrefs.GetInt("Pet_Sapire")].ToString();
            Pre_Damage[4].text = s_SapireDamage[PlayerPrefs.GetInt("Pet_Sapire") - 1].ToString();
            Cur_Damage[4].text = s_SapireDamage[PlayerPrefs.GetInt("Pet_Sapire")].ToString();
            LevelSprite[4].spriteName = PlayerPrefs.GetInt("Pet_Sapire").ToString();
            LevelSprite[4].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[4].transform.localPosition = new Vector3(1600, 0, -15);
        }
        else if (PlayerPrefs.GetInt("Pet_Sapire") >= 10)
        {
            PrizeLabel[4].text = "A";
            Pre_Damage[4].text = s_SapireDamage[PlayerPrefs.GetInt("Pet_Sapire") - 1].ToString();
            Cur_Damage[4].text = s_SapireDamage[PlayerPrefs.GetInt("Pet_Sapire") - 1].ToString();
            LevelSprite[4].spriteName = "10";
            LevelSprite[4].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[4].transform.localPosition = new Vector3(0, 0, -15);
        }

        if (PlayerPrefs.GetInt("Pet_Ruby") >= 1 && PlayerPrefs.GetInt("Pet_Ruby") < 10)
        {
            PrizeLabel[5].text = s_RubyValue[PlayerPrefs.GetInt("Pet_Ruby")].ToString();
            Pre_Damage[5].text = s_RubyDamage[PlayerPrefs.GetInt("Pet_Ruby") - 1].ToString();
            Cur_Damage[5].text = s_RubyDamage[PlayerPrefs.GetInt("Pet_Ruby")].ToString();
            LevelSprite[5].spriteName = PlayerPrefs.GetInt("Pet_Ruby").ToString();
            LevelSprite[5].gameObject.transform.localScale = new Vector3(38, 11, 1);
            Max[5].transform.localPosition = new Vector3(1600, 0, -15);
        }

        else if (PlayerPrefs.GetInt("Pet_Ruby") >= 10)
        {
            PrizeLabel[5].text = "A";
            Pre_Damage[5].text = s_RubyDamage[PlayerPrefs.GetInt("Pet_Ruby") - 1].ToString();
            Cur_Damage[5].text = s_RubyDamage[PlayerPrefs.GetInt("Pet_Ruby") - 1].ToString();
            LevelSprite[5].spriteName = "10";
            LevelSprite[5].gameObject.transform.localScale = new Vector3(47, 11, 1);
            Max[5].transform.localPosition = new Vector3(0, 0, -15);
        }


        if (PlayerPrefs.GetInt("Pet_Silver") >= 1 && PlayerPrefs.GetInt("Pet_Silver") <= 10)
        {
            Pets[0].transform.localPosition = new Vector3(-130, 335, 0);

            ButtonSprite[0].spriteName = "Button";

            LevelLabel[0].text = PlayerPrefs.GetInt("Pet_Silver").ToString();

            PanelSprite[0].spriteName = "Silver2";
            if (PlayerPrefs.GetInt("Pet_Silver") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= SilverPetValue[PlayerPrefs.GetInt("Pet_Silver")])
                {
                    LevelButton[0].isEnabled = true;
                }

                else
                {
                    LevelButton[0].isEnabled = false;
                }
            }

            else
            {
                LevelButton[0].isEnabled = false;
            }

            fTimer[0] -= Time.deltaTime;

            if (fTimer[0] <= 0.0f)
            {
                RandomNum[0] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[0] <= nPetPercent[PlayerPrefs.GetInt("Pet_Silver") - 1])
                {
                    PlayerPrefs.SetInt("Silver", PlayerPrefs.GetInt("Silver") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Silver", new Vector3(-134, 267, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[0] = HitDelay[0];
                CreateMinionParticle("Effect_Silver");
                TouchAndEarn.I.PetDamage(SliverPetDamage[PlayerPrefs.GetInt("Pet_Silver") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Silver") < 1)
        {
            Pets[0].transform.localPosition = new Vector3(-1500, 0, 0);
            ButtonSprite[0].spriteName = "Btn_Silver";
            Pre_Damage[0].text = "A";
            Cur_Damage[0].text = "A";
            LevelLabel[0].text = "A";
            PanelSprite[0].spriteName = "Silver";

            if (PlayerPrefs.GetInt("nLevel") - 11 <= 0)
            {
                PrizeLabel[0].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[0].text = (PlayerPrefs.GetInt("nLevel") - 11).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 11 >= 10)
            {
                PrizeLabel[0].text = "10/10";
                LevelButton[0].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 11 < 10)
            {
                LevelButton[0].isEnabled = false;
            }
        }

        else
        {
            LevelButton[0].isEnabled = false;
        }

        if (PlayerPrefs.GetInt("Pet_Gold") >= 1 && PlayerPrefs.GetInt("Pet_Gold") <= 10)
        {
            Pets[1].transform.localPosition = new Vector3(150, 170, 0);

            ButtonSprite[1].spriteName = "Button";

            LevelLabel[1].text = PlayerPrefs.GetInt("Pet_Gold").ToString();

            PanelSprite[1].spriteName = "Gold2";
            if (PlayerPrefs.GetInt("Pet_Gold") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= GoldPetValue[PlayerPrefs.GetInt("Pet_Gold")])
                {
                    LevelButton[1].isEnabled = true;
                }

                else
                {
                    LevelButton[1].isEnabled = false;
                }
            }

            else
            {
                LevelButton[1].isEnabled = false;
            }

            fTimer[1] -= Time.deltaTime;

            if (fTimer[1] <= 0.0f)
            {
                RandomNum[1] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[1] <= nPetPercent[PlayerPrefs.GetInt("Pet_Gold") - 1])
                {
                    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Gold", new Vector3(166, 80, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[1] = HitDelay[1];
                CreateMinionParticle("Effect_Gold");
                TouchAndEarn.I.PetDamage(GoldPetDamage[PlayerPrefs.GetInt("Pet_Gold") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Gold") < 1)
        {
            Pets[1].transform.localPosition = new Vector3(-1500, 0, 0);
            ButtonSprite[1].spriteName = "Btn_Gold";
            Pre_Damage[1].text = "A";
            Cur_Damage[1].text = "A";
            LevelLabel[1].text = "A";
            PanelSprite[1].spriteName = "Gold";

            if (PlayerPrefs.GetInt("nLevel") - 21 <= 0)
            {
                PrizeLabel[1].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[1].text = (PlayerPrefs.GetInt("nLevel") - 21).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 21 >= 10)
            {
                PrizeLabel[1].text = "10/10";
                LevelButton[1].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 21 < 10)
            {
                LevelButton[1].isEnabled = false;
            }
        }

        else
        {
            LevelButton[1].isEnabled = false;
        }

        if (PlayerPrefs.GetInt("Pet_Amethyst") >= 1 && PlayerPrefs.GetInt("Pet_Amethyst") <= 10)
        {
            Pets[2].transform.localPosition = new Vector3(60, 510, 0);

            ButtonSprite[2].spriteName = "Button";

            LevelLabel[2].text = PlayerPrefs.GetInt("Pet_Amethyst").ToString();

            PanelSprite[2].spriteName = "Amethyst2";
            if (PlayerPrefs.GetInt("Pet_Amethyst") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= AmethystPetValue[PlayerPrefs.GetInt("Pet_Amethyst")])
                {
                    LevelButton[2].isEnabled = true;
                }

                else
                {
                    LevelButton[2].isEnabled = false;
                }
            }

            else
            {
                LevelButton[2].isEnabled = false;
            }

            fTimer[2] -= Time.deltaTime;

            if (fTimer[2] <= 0.0f)
            {
                RandomNum[2] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[2] <= nPetPercent[PlayerPrefs.GetInt("Pet_Amethyst") - 1])
                {
                    PlayerPrefs.SetInt("Amethyst", PlayerPrefs.GetInt("Amethyst") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Amethyst", new Vector3(118, 315, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[2] = HitDelay[2];
                CreateMinionParticle("Effect_Amethyst");
                TouchAndEarn.I.PetDamage(AmethystPetDamage[PlayerPrefs.GetInt("Pet_Amethyst") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Amethyst") < 1)
        {
            Pets[2].transform.localPosition = new Vector3(-1500, 0, 1);
            ButtonSprite[2].spriteName = "Btn_Amethyst";
            Pre_Damage[2].text = "A";
            Cur_Damage[2].text = "A";
            LevelLabel[2].text = "A";
            PanelSprite[2].spriteName = "Amethyst";

            if (PlayerPrefs.GetInt("nLevel") - 31 <= 0)
            {
                PrizeLabel[2].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[2].text = (PlayerPrefs.GetInt("nLevel") - 31).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 31 >= 10)
            {
                PrizeLabel[2].text = "10/10";
                LevelButton[2].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 31 < 10)
            {
                LevelButton[2].isEnabled = false;
            }
        }

        else
        {
            LevelButton[2].isEnabled = false;
        }

        if (PlayerPrefs.GetInt("Pet_Topaz") >= 1 && PlayerPrefs.GetInt("Pet_Topaz") <= 10)
        {
            Pets[3].transform.localPosition = new Vector3(90, 40, 0);

            ButtonSprite[3].spriteName = "Button";

            LevelLabel[3].text = PlayerPrefs.GetInt("Pet_Topaz").ToString();

            PanelSprite[3].spriteName = "Topaz2";
            if (PlayerPrefs.GetInt("Pet_Topaz") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= TopazPetValue[PlayerPrefs.GetInt("Pet_Topaz")])
                {
                    LevelButton[3].isEnabled = true;
                }

                else
                {
                    LevelButton[3].isEnabled = false;
                }
            }

            else
            {
                LevelButton[3].isEnabled = false;
            }

            fTimer[3] -= Time.deltaTime;

            if (!StoneVib.animation.IsPlaying("Vibration"))
            {
                StoneVib.animation.Play("Vibration");
            }

            if (fTimer[3] <= 0.0f)
            {
                RandomNum[3] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[3] <= nPetPercent[PlayerPrefs.GetInt("Pet_Topaz") - 1])
                {
                    PlayerPrefs.SetInt("Topaz", PlayerPrefs.GetInt("Topaz") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Topaz", new Vector3(110, -18, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[3] = HitDelay[3];
                CreateMinionParticle("Effect_Topaz");
                TouchAndEarn.I.PetDamage(TopazPetDamage[PlayerPrefs.GetInt("Pet_Topaz") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Topaz") < 1)
        {
            Pets[3].transform.localPosition = new Vector3(-1500, 0, 0);
            ButtonSprite[3].spriteName = "Btn_Topaz";
            Pre_Damage[3].text = "A";
            Cur_Damage[3].text = "A";
            LevelLabel[3].text = "A";
            PanelSprite[3].spriteName = "Topaz";

            if (PlayerPrefs.GetInt("nLevel") - 41 <= 0)
            {
                PrizeLabel[3].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[3].text = (PlayerPrefs.GetInt("nLevel") - 41).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 41 >= 10)
            {
                PrizeLabel[3].text = "10/10";
                LevelButton[3].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 41 < 10)
            {
                LevelButton[3].isEnabled = false;
            }
        }

        else
        {
            LevelButton[3].isEnabled = false;
        }

        if (PlayerPrefs.GetInt("Pet_Sapire") >= 1 && PlayerPrefs.GetInt("Pet_Sapire") <= 10)
        {
            Pets[4].transform.localPosition = new Vector3(-150, 46.5f, 0);

            ButtonSprite[4].spriteName = "Button";

            LevelLabel[4].text = PlayerPrefs.GetInt("Pet_Sapire").ToString();

            PanelSprite[4].spriteName = "Sapphire2";
            if (PlayerPrefs.GetInt("Pet_Sapire") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= SapirePetValue[PlayerPrefs.GetInt("Pet_Sapire")])
                {
                    LevelButton[4].isEnabled = true;
                }

                else
                {
                    LevelButton[4].isEnabled = false;
                }
            }

            else
            {
                LevelButton[4].isEnabled = false;
            }

            fTimer[4] -= Time.deltaTime;

            if (fTimer[4] <= 0.0f)
            {
                RandomNum[4] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[4] <= nPetPercent[PlayerPrefs.GetInt("Pet_Sapire") - 1])
                {
                    PlayerPrefs.SetInt("Sapire", PlayerPrefs.GetInt("Sapire") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Sapire", new Vector3(-186, -18, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[4] = HitDelay[4];
                CreateMinionParticle("Effect_Sapphire");
                TouchAndEarn.I.PetDamage(SapirePetDamage[PlayerPrefs.GetInt("Pet_Sapire") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Sapire") < 1)
        {
            Pets[4].transform.localPosition = new Vector3(-1500, 0, 0);
            ButtonSprite[4].spriteName = "Btn_Sapphire";
            Pre_Damage[4].text = "A";
            Cur_Damage[4].text = "A";
            LevelLabel[4].text = "A";
            PanelSprite[4].spriteName = "Sapphire";

            if (PlayerPrefs.GetInt("nLevel") - 51 <= 0)
            {
                PrizeLabel[4].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[4].text = (PlayerPrefs.GetInt("nLevel") - 51).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 51 >= 10)
            {
                PrizeLabel[4].text = "10/10";
                LevelButton[4].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 51 < 10)
            {
                LevelButton[4].isEnabled = false;
            }
        }

        else
        {
            LevelButton[4].isEnabled = false;
        }

        if (PlayerPrefs.GetInt("Pet_Ruby") >= 1 && PlayerPrefs.GetInt("Pet_Ruby") <= 10)
        {
            Pets[5].transform.localPosition = new Vector3(-150, 190, 0);

            ButtonSprite[5].spriteName = "Button";

            LevelLabel[5].text = PlayerPrefs.GetInt("Pet_Ruby").ToString();

            PanelSprite[5].spriteName = "Ruby2";
            if (PlayerPrefs.GetInt("Pet_Ruby") < 10)
            {
                if (TouchAndEarn.I.nAllMoney >= RubyPetValue[PlayerPrefs.GetInt("Pet_Ruby")])
                {
                    LevelButton[5].isEnabled = true;
                }

                else
                {
                    LevelButton[5].isEnabled = false;
                }
            }

            else
            {
                LevelButton[5].isEnabled = false;
            }

            fTimer[5] -= Time.deltaTime;

            if (fTimer[5] <= 0.0f)
            {
                RandomNum[5] = Random.Range(0, 100);

                if (!StoneVib.animation.IsPlaying("Vibration"))
                {
                    StoneVib.animation.Play("Vibration");
                }

                if (RandomNum[5] <= nPetPercent[PlayerPrefs.GetInt("Pet_Ruby") - 1])
                {
                    PlayerPrefs.SetInt("Ruby", PlayerPrefs.GetInt("Ruby") + 1);
                    HPrefabMng.I.CreatePrefab2("Jewelrys", E_H_RESOURCELOAD.E_3_GameScene, "Pet_Ruby", new Vector3(-160, 120, 0), new Vector3(0.8f, 0.8f, 1), "", "");
                }

                fTimer[5] = HitDelay[5];
                CreateMinionParticle("Effect_Ruby");
                TouchAndEarn.I.PetDamage(RubyPetDamage[PlayerPrefs.GetInt("Pet_Ruby") - 1]);
            }
        }

        else if (PlayerPrefs.GetInt("Pet_Ruby") < 1)
        {
            Pets[5].transform.localPosition = new Vector3(-1500, 0, 0);
            ButtonSprite[5].spriteName = "Btn_Ruby";
            Pre_Damage[5].text = "A";
            Cur_Damage[5].text = "A";
            LevelLabel[5].text = "A";
            PanelSprite[5].spriteName = "Ruby";

            if (PlayerPrefs.GetInt("nLevel") - 61 <= 0)
            {
                PrizeLabel[5].text = "0" + "/" + "10";
            }

            else
            {
                PrizeLabel[5].text = (PlayerPrefs.GetInt("nLevel") - 61).ToString() + "/" + "10";
            }

            if (PlayerPrefs.GetInt("nLevel") - 61 >= 10)
            {
                PrizeLabel[5].text = "10/10";
                LevelButton[5].isEnabled = true;
            }

            else if (PlayerPrefs.GetInt("nLevel") - 61 < 10)
            {
                LevelButton[5].isEnabled = false;
            }
        }

        else
        {
            LevelButton[5].isEnabled = false;
        }
    }

    void CreateMinionParticle(string PartName)
    {
        HPrefabMng.I.CreatePrefab2("MEffect", E_H_RESOURCELOAD.E_3_GameScene, PartName, new Vector3(Random.Range(-60.0f, 77.0f), Random.Range(-65.0f, 165.0f), -1), new Vector3(400, 400, 1), "", "");
    }

    void ByeCash(GameObject Obj)
    {
        switch (Obj.tag)
        {
            case "Silver":
                TouchAndEarn.I.SorryCash(SilverPetValue[PlayerPrefs.GetInt("Pet_Silver")]);
                PlayerPrefs.SetInt("Pet_Silver", PlayerPrefs.GetInt("Pet_Silver") + 1);
                break;

            case "Gold":
                TouchAndEarn.I.SorryCash(GoldPetValue[PlayerPrefs.GetInt("Pet_Gold")]);
                PlayerPrefs.SetInt("Pet_Gold", PlayerPrefs.GetInt("Pet_Gold") + 1);
                break;

            case "Amethyst":
                TouchAndEarn.I.SorryCash(AmethystPetValue[PlayerPrefs.GetInt("Pet_Amethyst")]);
                PlayerPrefs.SetInt("Pet_Amethyst", PlayerPrefs.GetInt("Pet_Amethyst") + 1);
                break;

            case "Topaz":
                TouchAndEarn.I.SorryCash(TopazPetValue[PlayerPrefs.GetInt("Pet_Topaz")]);
                PlayerPrefs.SetInt("Pet_Topaz", PlayerPrefs.GetInt("Pet_Topaz") + 1);
                break;

            case "Sapire":
                TouchAndEarn.I.SorryCash(SapirePetValue[PlayerPrefs.GetInt("Pet_Sapire")]);
                PlayerPrefs.SetInt("Pet_Sapire", PlayerPrefs.GetInt("Pet_Sapire") + 1);
                break;

            case "Ruby":
                TouchAndEarn.I.SorryCash(RubyPetValue[PlayerPrefs.GetInt("Pet_Ruby")]);
                PlayerPrefs.SetInt("Pet_Ruby", PlayerPrefs.GetInt("Pet_Ruby") + 1);
                break;
        }
    }
}