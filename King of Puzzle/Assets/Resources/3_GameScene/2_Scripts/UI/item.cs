using UnityEngine;
using System.Collections;

public class item : MonoBehaviour
{
    float fTimer;
    BoxCollider BoxGame;
    BallSingleTon BallSingle;
    BlockShuffle ShuffleMng;
    StarGage ComboGage;
    ComboGage itforCombo;
    int nNum;
    int nNumberItemPercent;
    public AudioClip EffectAudio;

    // Use this for initialization
    void Start()
    {
        fTimer = 0.0f;
        BoxGame = gameObject.GetComponent<BoxCollider>();
        BoxGame.enabled = false;
        nNum = 0;
        nNumberItemPercent = 100;
        itforCombo = GameObject.Find("ComboGage").GetComponent<ComboGage>();
        ComboGage = GameObject.Find("StarFore").GetComponent<StarGage>();
        ShuffleMng = GameObject.Find("ResetButton").GetComponent<BlockShuffle>();
        BallSingle = BallSingleTon.I;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.25f)
        {
            BoxGame.enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(EffectAudio, transform.position);

            nNum = Random.Range(0, 9);

            if (nNum == BallSingle.nRandomNumber)
            {
                if (nNum == 0)
                {
                    nNum = Random.Range(1, 9);
                }

                else
                {
                    nNum = Random.Range(0, BallSingle.nRandomNumber);
                }
            }

            if (PlayerPrefs.GetInt("NumberItem") == 1)
            {
                nNumberItemPercent = Random.Range(0, 100);
                if (nNumberItemPercent <= 20)
                {
                    int nRandNum = Random.Range(0, 10);
                    HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "NumberItem", new Vector3(BallSingle.VecPos[nRandNum].x, BallSingle.VecPos[nRandNum].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                }
            }

            if (PlayerPrefs.GetInt("ChangeItem") == 1)
            {
                nNumberItemPercent = Random.Range(0, 100);
                if (nNumberItemPercent <= 20)
                {
                    int nRandNum = Random.Range(0, 10);
                    HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "ChangeItem", new Vector3(BallSingle.VecPos[nRandNum].x, BallSingle.VecPos[nRandNum].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                }
            }

            BallSingle.nRandomNumber = nNum;
            ShuffleMng.nCheckNum++;
            BallSingle.ScoreAdd(BallSingle.nFeverMulti);
            BallSingle.StarGage();
            itforCombo.TimerCharge();

            BallSingle.ComboCalculate();

            if (ComboGage.bComboState == false)
            {
                ComboGage.ComboGageManager();
            }

            HPrefabMng.I.DestroyPrefab(gameObject);

            if (ComboGage.bComboState == false)
            {
                ItemNumberCheck(PlayerPrefs.GetInt("itemNumber"));
            }
        }
    }

    void ItemNumberCheck(int itemNum)
    {
        switch (itemNum)
        {
            case 0:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "item", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 1:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Eitem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 2:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Ditem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 3:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Citem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 4:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Bitem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 5:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Aitem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 6:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Sitem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;

            case 7:
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Litem", new Vector3(BallSingle.VecPos[BallSingle.nRandomNumber].x, BallSingle.VecPos[BallSingle.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
                break;
        }
    }
}