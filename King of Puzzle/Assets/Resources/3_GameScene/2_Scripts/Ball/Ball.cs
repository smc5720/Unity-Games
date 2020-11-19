using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Vector3 BallVec;
    BallSingleTon BallMng;
    public int nIndex;
    int nNum;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("FakeMoney"));
        BallMng = BallSingleTon.I;
        nIndex = 0;
        BallMng.nRandomNumber = Random.Range(1, 9);
        if (PlayerPrefs.GetInt("FeverItem") == 0)
        {
            if (PlayerPrefs.GetInt("itemNumber") == 0)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "item", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 1)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Eitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 2)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Ditem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 3)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Citem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 4)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Bitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 5)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Aitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 6)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Sitem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }

            else if (PlayerPrefs.GetInt("itemNumber") == 7)
            {
                HPrefabMng.I.CreatePrefab("itemGroup", E_H_RESOURCELOAD.E_3_GameScene, "Litem", new Vector3(BallMng.VecPos[BallMng.nRandomNumber].x, BallMng.VecPos[BallMng.nRandomNumber].y + 1000, -2.0f), new Vector3(60, 60, 1), "", "");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        BallVec = BallMng.VecPos[nIndex];
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(BallVec.x, BallVec.y + 1000.0f, gameObject.transform.localPosition.z), BallMng.nBallSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (nIndex != 0 && nIndex != 1 && nIndex != 2)
            {
                nIndex -= 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (nIndex != 6 && nIndex != 7 && nIndex != 8)
            {
                nIndex += 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (nIndex != 0 && nIndex != 3 && nIndex != 6)
            {
                nIndex--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (nIndex != 2 && nIndex != 5 && nIndex != 8)
            {
                nIndex++;
            }
        }
    }
}