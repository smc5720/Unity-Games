using UnityEngine;
using System.Collections;

public class TouchAndEarn : MonoBehaviour
{
    private static TouchAndEarn m_Instance = null;
    public static TouchAndEarn I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(TouchAndEarn)) as TouchAndEarn;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [TouchAndEarn.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public GameObject g_Earn;

    UISprite s_NowHPGage;

    public GameObject TimeBomb;

    public Camera Camera2D;

    GameObject tempParent;

    public AudioClip HitAudio;

    public GameObject Coin;

    public GameObject Bronze;

    public GameObject Gold;

    public GameObject Sapire;

    public GameObject Silver;

    public GameObject Amethyst;

    public GameObject Ruby;

    public GameObject Topaz;

    public GameObject TouchBomb;

    float fTimer;

    float RandomX, RandomY;

    int[] ChangeValue = { 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170 };

    int[] nJewelry = { 10, 10, 20, 20, 30, 30, 40, 40, 50, 50, 50, 50, 50, 50, 50, 10, 10, 10, 10, 10 };

    long[] WeaponValue = { 0,               10000,              150000,             1000000,            6000000,

                           20000000,        70000000,           150000000,          350000000,          600000000,

                           1000000000,      2000000000,         3500000000,         6000000000,         10000000000,

                           15000000000 };

    int[] nCoinDrop = { 6, 2, 2, 3, 3, 4, 4, 5, 5, 6 };

    int[] nDamage =  { 1,                   10,                 150,                500,                1200,
                            
                       3000,                10000,              20000,              50000,              120000,
                       
                       380000,              700000,             1100000,            4000000,            9700000,
                       
                       999999999 };


    int[] MoneyValue = { 100,               100,                200,                200,                300,

                         300,               400,                400,                500,                500,

                         1500,              2000,               2500,               3000,               3500,

                         4000,              4500,               5000,               5500,               6000,

                         9000,              10000,              11000,              12000,              13000,

                         14000,             15000,              16000,              17000,              18000,

                         20000,             22000,              24000,              26000,              28000,

                         30000,             32000,              34000,              36000,              38000,

                         40000,             45000,              50000,              55000,              60000,

                         65000,             70000,              75000,              80000,              85000,

                         90000,             100000,             110000,             120000,             130000,

                         140000,            150000,             160000,             170000,             180000,

                         200000,            215000,             230000,             245000,             260000,

                         275000,            290000,             305000,             320000,             335000,
                       
                         355000,            375000,             395000,             415000,             435000,

                         455000,            475000,             495000,             515000,             535000 };

    int[] nChallenge = { 10, 100, 1000, 50, 500, 5000, 30, 300, 80, 800 };

    long[] nGroundHP =  { 10,               15,                 20,                 25,                 350,

                          450,              550,                650,                12000,              14250,

                          16500,            18750,              21000,              80000,              90000,

                          100000,           110000,             120000,             180000,             200000,

                          378000,           408000,             438000,             468000,             1260000,

                          1350000,          1440000,            1530000,            1620000,            5750000,

                          6100000,          6450000,            6800000,            7150000,            15100000,   
  
                          15900000,         16700000,           17500000,           18300000,           48000000,   

                          50250000,         52500000,           54750000,           137400000,          143400000, 

                          149400000,        155400000,          161400000,          549100000,          587100000,   

                          625100000,        663100000,          701100000,          1396500000,         1501500000,   

                          1606500000,       1711500000,         2909500000,         3129500000,         3349500000,

                          3569500000,       13980000000,        14980000000,        15980000000,        16980000000, 

                          44086500000,      46996500000,        49906500000,        52816500000,        76983000000,

                          76983000000,      76983000000,        76983000000,        76983000000,        76983000000,     
  
                          76983000000,      76983000000,        76983000000,        76983000000,        76983000000 };

    public float f_FullHP, f_CurrentHP, f_NowDamage;

    int CheckTouch;

    public long nAllMoney;

    public int nMoneyNow;

    public GameObject CoinLabel;

    public UISprite JewelryStone;

    public UISprite ExGauge;

    public GameObject BigJew;

    float EndingTimer;

    float fAttackSpeed;

    bool EndingState;

    UILabel coinUI;

    public UISprite Stone;

    public GameObject StoneObj;

    public GameObject StoneAni;

    public GameObject EndingWhite;

    int nMaxDamage;

    string MoneyString;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Prestige") >= 1)
        {
            DeleteData();
            PlayerPrefs.SetInt("Prestige", 0);
        }

        EndingState = false;

        PlayerPrefs.SetString("sAllMoney", "50000000000");

        PlayerPrefs.SetString("IsShopClicked", "No");

        coinUI = CoinLabel.GetComponent<UILabel>();

        if (PlayerPrefs.GetInt("nLevel") <= 1)
        {
            PlayerPrefs.SetInt("nLevel", 1);
        }

        if (PlayerPrefs.GetInt("nWeaponLevel") <= 1)
        {
            PlayerPrefs.SetInt("nWeaponLevel", 1);
        }

        SetGround(PlayerPrefs.GetInt("nLevel"));

        if (PlayerPrefs.GetString("sCurrentHP") != "0")
        {
            f_CurrentHP = float.Parse(PlayerPrefs.GetString("sCurrentHP"));
        }

        fTimer = 0.1f;

        tempParent = GameObject.Find("4_Center_Center");

        s_NowHPGage = g_Earn.GetComponent<UISprite>();

        nMaxDamage = 0;

        for (int i = 1; i <= 10; i++)
        {
            nMaxDamage += PlayerPrefs.GetInt("Challenge_" + i.ToString()) * nChallenge[i - 1];
        }

        if (PlayerPrefs.GetInt("Skill_1") == 1)
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage) * 2;
        }

        else
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage);
        }

        CheckTouch = 1;

        nAllMoney = long.Parse(PlayerPrefs.GetString("sAllMoney"));

        coinUI.text = nAllMoney.ToString();

        if (PlayerPrefs.GetInt("nLevel") == 1)
        {
            JewelryStone.spriteName = "1_Big Jewelry";
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.SetInt("nLevel", 1);

        PlayerPrefs.SetString("sCurrentHP", "10");

        PlayerPrefs.SetString("sAllMoney", "0");

        PlayerPrefs.SetInt("nWeaponLevel", 1);

        PlayerPrefs.SetString("IsShopClicked", "Yes");

        PlayerPrefs.SetInt("Bronze", 0);

        PlayerPrefs.SetInt("Silver", 0);

        PlayerPrefs.SetInt("Gold", 0);

        PlayerPrefs.SetInt("Amethyst", 0);

        PlayerPrefs.SetInt("Topaz", 0);

        PlayerPrefs.SetInt("Sapire", 0);

        PlayerPrefs.SetInt("Ruby", 0);

        PlayerPrefs.SetInt("Pet_Silver", 0);

        PlayerPrefs.SetInt("Pet_Gold", 0);

        PlayerPrefs.SetInt("Pet_Amethyst", 0);

        PlayerPrefs.SetInt("Pet_Topaz", 0);

        PlayerPrefs.SetInt("Pet_Sapire", 0);

        PlayerPrefs.SetInt("Pet_Ruby", 0);

        PlayerPrefs.SetInt("Q_TouchNum", 0);

        PlayerPrefs.SetInt("Q_JewNum", 0);

        PlayerPrefs.SetInt("Q_Smallest", 0);

        PlayerPrefs.SetInt("Q_Biggest", 0);

        PlayerPrefs.SetInt("Skill_1", 2);

        PlayerPrefs.SetInt("Skill_2", 2);

        PlayerPrefs.SetInt("Skill_3", 2);

        PlayerPrefs.SetInt("Skill_4", 2);

        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.SetInt("Challenge_" + i.ToString(), 0);
        }

        coinUI = CoinLabel.GetComponent<UILabel>();

        if (PlayerPrefs.GetInt("nLevel") <= 1)
        {
            PlayerPrefs.SetInt("nLevel", 1);
        }

        if (PlayerPrefs.GetInt("nWeaponLevel") <= 1)
        {
            PlayerPrefs.SetInt("nWeaponLevel", 1);
        }

        SetGround(PlayerPrefs.GetInt("nLevel"));

        if (PlayerPrefs.GetString("sCurrentHP") != "0")
        {
            f_CurrentHP = float.Parse(PlayerPrefs.GetString("sCurrentHP"));
        }

        fTimer = 0.1f;

        tempParent = GameObject.Find("4_Center_Center");

        s_NowHPGage = g_Earn.GetComponent<UISprite>();

        nMaxDamage = 0;

        for (int i = 1; i <= 10; i++)
        {
            nMaxDamage += PlayerPrefs.GetInt("Challenge_" + i.ToString()) * nChallenge[i - 1];
        }

        if (PlayerPrefs.GetInt("Skill_1") == 1)
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage) * 2;
        }

        else
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage);
        }

        CheckTouch = 1;

        nAllMoney = long.Parse(PlayerPrefs.GetString("sAllMoney"));

        string MoneyString = string.Format("{0:#,###}", nAllMoney);

        coinUI.text = MoneyString;

        if (PlayerPrefs.GetInt("nLevel") == 1)
        {
            JewelryStone.spriteName = "1_Big Jewelry";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Skill_2") == 1)
        {
            fAttackSpeed = 0.05f;
        }

        else
        {
            fAttackSpeed = 0.1f;
        }

        ExGauge.fillAmount = (float)(PlayerPrefs.GetInt("nLevel") - 1) / 80.0f;

        nMaxDamage = 0;

        for (int i = 1; i <= 10; i++)
        {
            nMaxDamage += PlayerPrefs.GetInt("Challenge_" + i.ToString()) * nChallenge[i - 1];
        }

        if (PlayerPrefs.GetInt("Skill_1") == 1)
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage) * 2;
        }

        else
        {
            f_NowDamage = (nDamage[PlayerPrefs.GetInt("nWeaponLevel") - 1] + nMaxDamage);
        }

        if (PlayerPrefs.GetInt("nWeaponLevel") <= 9)
        {
            if (PlayerPrefs.GetInt("Skill_2") != 1)
            {
                if (PlayerPrefs.GetString("IsShopClicked") == "No")
                {
                    ///////////////////////////////////////////////////////////////////////////////
                    if (Input.GetMouseButtonDown(0))
                    {
                        f_CurrentHP -= f_NowDamage;

                        StoneAni.animation.Play("StoneCrash");

                        CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                        JewelryParticle(PlayerPrefs.GetInt("nLevel"));

                        if (PlayerPrefs.GetInt("Skill_4") == 1)
                        {
                            CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                            JewelryParticle(PlayerPrefs.GetInt("nLevel"));
                        }

                        AudioSource.PlayClipAtPoint(HitAudio, transform.position);

                        RandomX = Random.Range(-86.0f, 110.0f);
                        RandomY = Random.Range(-10.0f, 220.0f);

                        CreatePrefab("Etc", "TouchBomb", TouchBomb, new Vector3(100, 100, 1), new Vector3(RandomX, RandomY, -2));

                        if (PlayerPrefs.GetInt("Skill_1") == 1)
                        {
                            HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "SkillDamage", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                        }

                        else
                        {
                            HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "TouchMoney", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                        }

                        if (CheckTouch >= 100)
                        {
                            CheckTouch = 1;
                        }

                        else
                        {
                            CheckTouch++;
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////////

                    int cnt = Input.touchCount;

                    for (int i = 0; i < cnt; ++i)
                    {
                        Touch touch = Input.GetTouch(i);
                        Vector2 pos = touch.position;

                        RandomX = Random.Range(-86.0f, 110.0f);
                        RandomY = Random.Range(-10.0f, 220.0f);

                        if (touch.phase == TouchPhase.Began)
                        {
                            f_CurrentHP -= f_NowDamage;

                            StoneAni.animation.Play("StoneCrash");

                            CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                            JewelryParticle(PlayerPrefs.GetInt("nLevel"));

                            if (PlayerPrefs.GetInt("Skill_4") == 1)
                            {
                                CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                                JewelryParticle(PlayerPrefs.GetInt("nLevel"));
                            }

                            AudioSource.PlayClipAtPoint(HitAudio, transform.position);

                            PlayerPrefs.SetInt("Q_TouchNum", PlayerPrefs.GetInt("Q_TouchNum") + 1);

                            CreatePrefab("Etc", "TouchBomb", TouchBomb, new Vector3(100, 100, 1), new Vector3(RandomX, RandomY, -2));

                            if (PlayerPrefs.GetInt("Skill_1") == 1)
                            {
                                HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "SkillDamage", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                            }

                            else
                            {
                                HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "TouchMoney", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                            }

                            if (CheckTouch >= 100)
                            {
                                CheckTouch = 1;
                            }

                            else
                            {
                                CheckTouch++;
                            }
                        }
                    }
                }
            }

            else if (PlayerPrefs.GetInt("Skill_2") == 1)
            {
                if (Input.GetMouseButton(0) && PlayerPrefs.GetString("IsShopClicked") == "No")
                {
                    fTimer += Time.deltaTime;

                    if (fTimer >= 0.1f && PlayerPrefs.GetInt("nLevel") <= 80)
                    {
                        fTimer = 0.0f;

                        StoneAni.animation.Play("StoneCrash");

                        f_CurrentHP -= f_NowDamage;

                        CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                        JewelryParticle(PlayerPrefs.GetInt("nLevel"));

                        if (PlayerPrefs.GetInt("Skill_4") == 1)
                        {
                            CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                            JewelryParticle(PlayerPrefs.GetInt("nLevel"));
                        }

                        AudioSource.PlayClipAtPoint(HitAudio, transform.position);

                        PlayerPrefs.SetInt("Q_TouchNum", PlayerPrefs.GetInt("Q_TouchNum") + 1);

                        RandomX = Random.Range(-86.0f, 110.0f);
                        RandomY = Random.Range(-10.0f, 220.0f);

                        CreatePrefab("Etc", "TouchBomb", TouchBomb, new Vector3(300, 300, 1), new Vector3(RandomX, RandomY, -2));

                        if (PlayerPrefs.GetInt("Skill_1") == 1)
                        {
                            HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "SkillDamage", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                        }

                        else
                        {
                            HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "TouchMoney", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                        }

                        if (CheckTouch >= 100)
                        {
                            CheckTouch = 1;
                        }

                        else
                        {
                            CheckTouch++;
                        }
                    }
                }

                else if (Input.GetMouseButtonUp(0))
                {
                    fTimer = 0.1f;
                }
            }
        }

        else if (PlayerPrefs.GetInt("nWeaponLevel") > 9 && (PlayerPrefs.GetInt("nLevel") <= 80))
        {
            if (Input.GetMouseButton(0) && PlayerPrefs.GetString("IsShopClicked") == "No")
            {
                fTimer += Time.deltaTime;

                if (fTimer >= fAttackSpeed && PlayerPrefs.GetInt("nLevel") <= 80)
                {
                    fTimer = 0.0f;

                    StoneAni.animation.Play("StoneCrash");

                    f_CurrentHP -= f_NowDamage;

                    CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                    JewelryParticle(PlayerPrefs.GetInt("nLevel"));

                    if (PlayerPrefs.GetInt("Skill_4") == 1)
                    {
                        CoinParticle(Random.Range(1, nCoinDrop[(PlayerPrefs.GetInt("nLevel") % 10)]));

                        JewelryParticle(PlayerPrefs.GetInt("nLevel"));
                    }

                    AudioSource.PlayClipAtPoint(HitAudio, transform.position);

                    PlayerPrefs.SetInt("Q_TouchNum", PlayerPrefs.GetInt("Q_TouchNum") + 1);

                    RandomX = Random.Range(-86.0f, 110.0f);
                    RandomY = Random.Range(-10.0f, 220.0f);

                    CreatePrefab("Etc", "TouchBomb", TouchBomb, new Vector3(300, 300, 1), new Vector3(RandomX, RandomY, -2));

                    if (PlayerPrefs.GetInt("Skill_1") == 1)
                    {
                        HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "SkillDamage", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                    }

                    else
                    {
                        HPrefabMng.I.CreatePrefab2("4_Center_Center", E_H_RESOURCELOAD.E_3_GameScene, "TouchMoney", new Vector3(0, 200, -2), new Vector3(28, 31, 1), CheckTouch.ToString(), "");
                    }

                    if (CheckTouch >= 100)
                    {
                        CheckTouch = 1;
                    }

                    else
                    {
                        CheckTouch++;
                    }
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                fTimer = 0.1f;
            }
        }

        if (PlayerPrefs.GetInt("nLevel") == 81)
        {
            if (EndingState == false)
            {
                EndingState = true;
                HPrefabMng.I.CreatePrefab2("Etc", E_H_RESOURCELOAD.E_3_GameScene, "EndingBig", new Vector3(7, -93, 0), new Vector3(1, 1, 1), "", "");
                TweenAlpha.Begin(EndingWhite, 2.5f, 1.0f);
                JewelryStone.alpha = 0.0f;
            }

            EndingTimer += Time.deltaTime;

            if (EndingTimer >= 3.0f)
            {
                Application.LoadLevel("4_EndingScene");
            }
        }

        if (PlayerPrefs.GetInt("nLevel") <= 80)
        {
            if (s_NowHPGage.fillAmount <= 0.1f)
            {
                Stone.alpha = 0.0f;
            }

            else if (s_NowHPGage.fillAmount > 0.1f && s_NowHPGage.fillAmount <= 0.25f)
            {
                StoneObj.transform.localScale = new Vector3(186, 85, 1);
                Stone.alpha = 1.0f;
                Stone.spriteName = "4";
            }

            else if (s_NowHPGage.fillAmount > 0.25f && s_NowHPGage.fillAmount <= 0.5f)
            {
                StoneObj.transform.localScale = new Vector3(192, 152, 1);
                Stone.alpha = 1.0f;
                Stone.spriteName = "3";
            }

            else if (s_NowHPGage.fillAmount > 0.5f && s_NowHPGage.fillAmount <= 0.75f)
            {
                StoneObj.transform.localScale = new Vector3(201, 255, 1);
                Stone.alpha = 1.0f;
                Stone.spriteName = "2";
            }

            else if (s_NowHPGage.fillAmount > 0.75f)
            {
                StoneObj.transform.localScale = new Vector3(207, 302, 1);
                Stone.alpha = 1.0f;
                Stone.spriteName = "1";
            }
        }

        if (f_CurrentHP / f_FullHP <= 0 && PlayerPrefs.GetInt("nLevel") <= 80)
        {
            if (PlayerPrefs.GetInt("nLevel") < 80)
            {
                HPrefabMng.I.CreatePrefab2("Etc", E_H_RESOURCELOAD.E_3_GameScene, "GetBig", new Vector3(7, -93, 0), new Vector3(141, 260, 1), JewelryStone.spriteName, "");
            }

            PlayerPrefs.SetInt("nLevel", PlayerPrefs.GetInt("nLevel") + 1);

            PlayerPrefs.SetInt("StoneClass", Random.Range(0, 100));

            if (PlayerPrefs.GetInt("nLevel") <= 80)
            {
                SetGround(PlayerPrefs.GetInt("nLevel"));

                f_CurrentHP = f_FullHP;
            }
        }

        s_NowHPGage.fillAmount = (f_CurrentHP / f_FullHP);

        PlayerPrefs.SetString("sAllMoney", nAllMoney.ToString());

        MoneyString = string.Format("{0:#,###}", nAllMoney);

        coinUI.text = MoneyString;

        if (nAllMoney == 0)
        {
            coinUI.text = "0";
        }

        PlayerPrefs.SetString("sCurrentHP", f_CurrentHP.ToString());

        if (PlayerPrefs.GetInt("nLevel") <= 70)
        {
            if (PlayerPrefs.GetInt("StoneClass") >= 0 && PlayerPrefs.GetInt("StoneClass") < 70)
            {
                JewelryStone.spriteName = (((PlayerPrefs.GetInt("nLevel") - 1) / 10) + 1).ToString() + "_Big Jewelry";
            }

            else if (PlayerPrefs.GetInt("StoneClass") >= 70 && PlayerPrefs.GetInt("StoneClass") < 90)
            {
                JewelryStone.spriteName = (((PlayerPrefs.GetInt("nLevel") - 1) / 10) + 1).ToString() + "_Venus";
            }

            else if (PlayerPrefs.GetInt("StoneClass") >= 90 && PlayerPrefs.GetInt("StoneClass") < 95)
            {
                JewelryStone.spriteName = (((PlayerPrefs.GetInt("nLevel") - 1) / 10) + 1).ToString() + "_Burse Lee";
            }

            else if (PlayerPrefs.GetInt("StoneClass") >= 95 && PlayerPrefs.GetInt("StoneClass") < 100)
            {
                JewelryStone.spriteName = (((PlayerPrefs.GetInt("nLevel") - 1) / 10) + 1).ToString() + "_TrapCard";
            }
        }

        else if (70 < PlayerPrefs.GetInt("nLevel") && PlayerPrefs.GetInt("nLevel") <= 80)
        {
            JewelryStone.spriteName = (((PlayerPrefs.GetInt("nLevel") - 1) / 10) + 1).ToString() + "_Big Jewelry";
        }
    }

    public GameObject CreatePrefab(string Parent, string Name, GameObject Prefab, Vector3 Scale, Vector3 Position)
    {
        GameObject CreObj = (GameObject)Instantiate(Prefab);

        CreObj.transform.parent = GameObject.Find(Parent).transform;

        CreObj.name = Name;

        CreObj.transform.localScale = Scale;

        CreObj.transform.localPosition = Position;

        return CreObj;
    }

    public void PetDamage(int nDamage)
    {
        f_CurrentHP -= nDamage;
    }

    public int ChangeFunc()
    {
        int num = Random.Range(0, 14);

        return ChangeValue[num];
    }

    public int DamageText()
    {
        int NowDamage;

        NowDamage = (int)f_NowDamage;

        return NowDamage;
    }

    void SetGround(int nGroundLevel)
    {
        f_FullHP = nGroundHP[nGroundLevel - 1];

        nMoneyNow = MoneyValue[nGroundLevel - 1];
    }

    public long GetWeaponValue(int nWLevel)
    {
        return WeaponValue[nWLevel - 1];
    }

    public void GetCoin(int nMoneyNow)
    {
        nAllMoney += nMoneyNow;
    }

    public void CoinParticle(int nCoinNum)
    {
        for (int i = 0; i < nCoinNum; i++)
        {
            Vector3 TouchPos = Camera2D.ScreenToWorldPoint(Input.mousePosition);

            CreatePrefab("Etc", "Coin", Coin, new Vector3(270, 270, 1), new Vector3(Random.Range(-86.0f, 110.0f), Random.Range(-10.0f, 220.0f), -1));
        }
    }

    public void SorryCash(long Cash)
    {
        nAllMoney -= Cash;
    }

    public void JewelryParticle(int nLevelCount)
    {
        int nRand = Random.Range(0, 100);
        Vector3 TouchPos = Camera2D.ScreenToWorldPoint(Input.mousePosition);

        switch ((nLevelCount - 1) / 10)
        {
            case 0:
                if (nRand <= nJewelry[nLevelCount - 1])
                {
                    CreatePrefab("Etc", "Bronze", Bronze, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 1:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Bronze", Bronze, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 10 - 1])
                {
                    CreatePrefab("Etc", "Silver", Silver, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 2:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Silver", Silver, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 20 - 1])
                {
                    CreatePrefab("Etc", "Gold", Gold, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 3:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Gold", Gold, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 30 - 1])
                {
                    CreatePrefab("Etc", "Amethyst", Amethyst, new Vector3(17, 31, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 4:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Amethyst", Amethyst, new Vector3(17, 31, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 40 - 1])
                {
                    CreatePrefab("Etc", "Topaz", Topaz, new Vector3(32, 32, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 5:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Topaz", Topaz, new Vector3(32, 32, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 50 - 1])
                {
                    CreatePrefab("Etc", "Sapire", Sapire, new Vector3(28, 42, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 6:
                if (nRand <= nJewelry[nLevelCount % 10 + 9])
                {
                    CreatePrefab("Etc", "Sapire", Sapire, new Vector3(28, 42, 1), new Vector3(RandomX, RandomY, -6));
                }

                if (nRand <= nJewelry[nLevelCount - 60 - 1])
                {
                    CreatePrefab("Etc", "Ruby", Ruby, new Vector3(36, 28, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;

            case 7:
                if (nRand < 5)
                {
                    CreatePrefab("Etc", "Bronze", Bronze, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 5 && nRand < 10)
                {
                    CreatePrefab("Etc", "Silver", Silver, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 10 && nRand < 15)
                {
                    CreatePrefab("Etc", "Gold", Gold, new Vector3(42, 22, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 15 && nRand < 20)
                {
                    CreatePrefab("Etc", "Amethyst", Amethyst, new Vector3(17, 31, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 20 && nRand < 30)
                {
                    CreatePrefab("Etc", "Topaz", Topaz, new Vector3(32, 32, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 30 && nRand < 40)
                {
                    CreatePrefab("Etc", "Sapire", Sapire, new Vector3(28, 42, 1), new Vector3(RandomX, RandomY, -6));
                }

                else if (nRand >= 40 && nRand < 50)
                {
                    CreatePrefab("Etc", "Ruby", Ruby, new Vector3(36, 28, 1), new Vector3(RandomX, RandomY, -6));
                }
                break;
        }
    }
}