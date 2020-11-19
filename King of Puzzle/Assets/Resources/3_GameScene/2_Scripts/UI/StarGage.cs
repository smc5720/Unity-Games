using UnityEngine;
using System.Collections;

public class StarGage : MonoBehaviour
{
    UISprite GageSprite;
    UISprite FeverGageSprite;
    BallSingleTon BallMng;
    TimerGage TimeGage;

    public int nStarNum;
    public float fGagePercent;
    public float fFeverGagePercent;
    public float fTimer;
    public float FeverTimer;
    public bool bComboState = false;

    public GameObject BackGround;
    public GameObject TimerGage;
    public GameObject FeverGage;
    public GameObject ParentGage;
    public GameObject FeverChoke;
    public GameObject FeverEraser;
    public AudioClip ComboAudio;

    // Use this for initialization
    void Start()
    {
        GageSprite = gameObject.GetComponent<UISprite>();
        FeverGageSprite = FeverGage.GetComponent<UISprite>();
        TimeGage = TimerGage.GetComponent<TimerGage>();
        fGagePercent = 0.0f;
        BallMng = BallSingleTon.I;
        fFeverGagePercent = 0.0f;
        fTimer = 0.0f;
        FeverTimer = 0.0f;
        nStarNum = 0;
        FeverGageSprite.fillAmount = 0.0f;
        GageSprite.fillAmount = 0.0f;
        FeverChoke.transform.localPosition = new Vector3(5.0f, 4.0f, -10.0f);
        FeverEraser.transform.localPosition = new Vector3(600.0f, 4.0f, -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bComboState == false)
        {
            FeverChoke.transform.localPosition = new Vector3(438.0f * fGagePercent + 6.0f, 4.0f, -10.0f);
            FeverEraser.transform.localPosition = new Vector3(600.0f, 4.0f, -10.0f);
            NoFeverMode();
        }

        else if (bComboState == true)
        {
            FeverEraser.transform.localPosition = new Vector3(425.0f * fFeverGagePercent + 15.0f, 4.0f, -10.0f);
            FeverChoke.transform.localPosition = new Vector3(600.0f, 4.0f, -10.0f);
            FeverMode();
        }

        fGagePercent = fTimer / 3;
        fFeverGagePercent = FeverTimer / 6;

        GageSprite.fillAmount = fGagePercent;
        FeverGageSprite.fillAmount = fFeverGagePercent;
    }

    public void ComboGageManager()
    {
        fTimer += 0.8f;
        if (fTimer > 3.0f)
        {
            FeverModeEffect();
        }
    }

    void NoFeverMode()
    {
        if (fTimer > 0)
        {
            fTimer -= 0.3f * Time.deltaTime;
        }
    }

    void ComboUpgrade()
    {
        AudioSource.PlayClipAtPoint(ComboAudio, transform.position);
        if (BallMng.nFeverMulti < 10)
        {
            BallMng.nFeverMulti += 1;
        }
    }

    void FeverMode()
    {
        FeverTimer -= 0.6f * Time.deltaTime * BallMng.nFevering;

        if (FeverTimer < 0.0f)
        {
            FeverTimer = 0.0f;
            bComboState = false;
            HPrefabMng.I.DestroyPrefab("FeverRed(Clone)");
            BallMng.nFevering = 0;
            int nNum = Random.Range(0, 9);
            if (nNum == BallMng.nRandomNumber)
            {
                if (nNum == 0)
                {
                    nNum = Random.Range(1, 9);
                }

                else
                {
                    nNum = Random.Range(0, BallMng.nRandomNumber);
                }
            }
            BallMng.nRandomNumber = nNum;

            ItemNumberCheck(PlayerPrefs.GetInt("itemNumber"));
        }
    }

    public void FeverModeEffect()
    {
        bComboState = true;
        BackGround.animation.Play("FeverBACK");
        HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_3_GameScene, "FeverRed", new Vector3(0, 0, -1), new Vector3(480, 800, 1), "", "");
        fTimer = 0.0f;
        FeverTimer = 6.0f;
        BallMng.nFevering += 1;
        ComboUpgrade();
        if (BallMng.nFevering == 1)
        {
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "FeverMode", new Vector3(0, 120, -11), new Vector3(0.01f, 0.01f, 1), "", "");
        }

        else if (BallMng.nFevering > 1)
        {
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "SuperFeverMode", new Vector3(0, 100, -11), new Vector3(0.01f, 0.01f, 1), "", "");
        }

        for (int i = 0; i < 9; i++)
        {
            ItemNumberCheck(PlayerPrefs.GetInt("itemNumber"), i);
        }
    }

    void ItemNumberCheck(int itemNum)
    {
        switch (itemNum)
        {
            case 0:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "item", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 1:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Eitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 2:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Ditem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 3:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Citem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 4:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Bitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 5:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Aitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 6:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Sitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 7:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Litem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;
        }
    }

    void ItemNumberCheck(int itemNum, int i)
    {
        switch (itemNum)
        {
            case 0:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "item " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 1:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Eitem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 2:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Ditem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 3:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Citem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 4:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Bitem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 5:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Aitem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 6:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Sitem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 7:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Litem " + (i + 1).ToString(), new Vector3(BallMng.VecPos[i].x, BallMng.VecPos[i].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;
        }
    }
}