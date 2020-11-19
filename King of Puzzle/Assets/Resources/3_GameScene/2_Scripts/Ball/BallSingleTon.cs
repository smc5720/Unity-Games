using UnityEngine;
using System.Collections;

public class BallSingleTon : MonoBehaviour
{

    private static BallSingleTon m_Instance = null;

    public static BallSingleTon I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(BallSingleTon)) as BallSingleTon;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [BallSingleTon.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// 점수
    /// </summary>
    public int nScore;

    /// <summary>
    /// int형 콤보변수
    /// </summary>
    public int nCombo;

    /// <summary>
    /// 피버에 곱해주는 변수
    /// </summary>
    public int nFeverMulti = 1;

    public int nFeverCombo = 0;

    public int nFevering = 0;

    /// <summary>
    /// 벡터 배열 선언 (9가지)
    /// </summary>
    public Vector3[] VecPos;

    /// <summary>
    /// 아이템 게이지 관련 변수
    /// </summary>
    public int nItemNumber;

    /// <summary>
    /// 몰라
    /// </summary>
    public GameObject[] BlockPos;

    /// <summary>
    /// 빈덱스.닌덱스에 쓸거야
    /// </summary>
    Ball bIndex;

    public int nRandomNumber = 0;

    StarGage ComboGage;

    /// <summary>
    /// 레벨 F~Legend  
    /// Lv.  1: (F ) 
    /// Lv.  2: (E-) 
    /// Lv.  3: (E ) 
    /// Lv.  4: (E+) 
    /// Lv.  5: (D-) 
    /// Lv.  6: (D ) 
    /// Lv.  7: (D+) 
    /// Lv.  8: (C-) 
    /// Lv.  9: (C ) 
    /// Lv. 10: (C+) 
    /// Lv. 11: (B-) 
    /// Lv. 12: (B ) 
    /// Lv. 13: (B+) 
    /// Lv. 14: (A-) 
    /// Lv. 15: (A ) 
    /// Lv. 16: (A+) 
    /// Lv. 17: (S-) 
    /// Lv. 18: (S ) 
    /// Lv. 19: (S+) 
    /// Lv. 20: (Legend)
    /// </summary>
    public int nLevel = 1;

    /// <summary>
    /// 레벨당 경험치 F~S
    /// 0부터 1500씩
    /// </summary>
    public int nLvAmount = 0;

    public int nResetMap = 0;

    public float nBallSpeed;

    void Awake()
    {
        VecPos = new Vector3[9];
        BlockPos = new GameObject[9];

        for (int i = 0; i < 9; i++)
        {
            BlockPos[i] = GameObject.Find((i + 1).ToString());
        }

        for (int i = 0; i < 9; i++)
        {
            VecPos[i] = new Vector3(((i % 3 * 120) - 120), ((i / 3) * (-120) + 220), -1);
        }

        if (PlayerPrefs.GetInt("SpeedItem") == 0)
        {
            nBallSpeed = 1000.0f;
        }

        if (PlayerPrefs.GetInt("SpeedItem") == 1)
        {
            nBallSpeed = 1500.0f;
        }

        if (PlayerPrefs.GetInt("isMute") == 1)
        {
            GameObject.Find("Root_I").GetComponent<AudioSource>().mute = true;
        }
    }

    // Use this for initialization
    void Start()
    {
        ComboGage = GameObject.Find("StarFore").GetComponent<StarGage>();
        bIndex = GameObject.Find("Ball").GetComponent<Ball>();
        nItemNumber = 0;
        nScore = 0;

        if (PlayerPrefs.GetInt("Level") <= nLevel)
        {
            PlayerPrefs.SetInt("Level", nLevel);
        }

        if (PlayerPrefs.GetFloat("FullLvAmount") < 1500)
        {
            PlayerPrefs.SetFloat("FullLvAmount", 1500);
        }

        //ResetAllData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpBtn()
    {
        if (bIndex.nIndex != 0 && bIndex.nIndex != 1 && bIndex.nIndex != 2)
        {
            bIndex.nIndex -= 3;
        }
    }

    public void DownBtn()
    {
        if (bIndex.nIndex != 6 && bIndex.nIndex != 7 && bIndex.nIndex != 8)
        {
            bIndex.nIndex += 3;
        }
    }

    public void LeftBtn()
    {
        if (bIndex.nIndex != 0 && bIndex.nIndex != 3 && bIndex.nIndex != 6)
        {
            bIndex.nIndex--;
        }
    }

    public void RightBtn()
    {
        if (bIndex.nIndex != 2 && bIndex.nIndex != 5 && bIndex.nIndex != 8)
        {
            bIndex.nIndex++;
        }
    }

    public void StarGage()
    {
        nItemNumber++;
    }

    public void ScoreAdd(int Check)
    {
        switch (Check)
        {
            case 1:
                nScore += Random.Range(500, 510);
                break;

            case 2:
                nScore += Random.Range(1000, 1200);
                break;

            case 3:
                nScore += Random.Range(1500, 1600);
                break;

            case 4:
                nScore += Random.Range(2000, 2200);
                break;

            case 5:
                nScore += Random.Range(2500, 2700);
                break;

            case 6:
                nScore += Random.Range(3000, 3300);
                break;

            case 7:
                nScore += Random.Range(3500, 3800);
                break;

            case 8:
                nScore += Random.Range(4000, 4300);
                break;

            case 9:
                nScore += Random.Range(4500, 4700);
                break;

            case 10:
                nScore += Random.Range(5000, 5500);
                break;
        }
    }

    public void ComboCalculate()
    {
        nCombo += 1;
    }

    public void FeverCalculate()
    {
        nFeverCombo += 1;
        if (nFeverCombo == 9)
        {
            ComboGage.FeverModeEffect();
            FeverComboZero();
        }
    }

    public void FeverComboZero()
    {
        nFeverCombo = 0;
    }

    void ResetAllData()
    {
        PlayerPrefs.SetInt("NowScore", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetFloat("LevelAmount", 0);
        PlayerPrefs.SetFloat("FullLvAmount", 1500);
        PlayerPrefs.SetFloat("PlusAmount", 0);
    }
}