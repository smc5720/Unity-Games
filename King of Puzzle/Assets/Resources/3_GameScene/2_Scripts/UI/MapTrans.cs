using UnityEngine;
using System.Collections;

public class MapTrans : MonoBehaviour
{
    public int nCheckSame;
    public GameObject[] MapsList = new GameObject[5];
    public int nMapNum;
    int nCheck = 0;

    // Use this for initialization
    void Start()
    {
        nCheckSame = 100;
        for (int i = 0; i < 5; i++)
        {
            MapsList[i].transform.localPosition = new Vector3(-500, 0, -1);
        }

        ShuffleMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShuffleMap()
    {
        nMapNum = Random.Range(0, 5);

        if (nCheck != 0)
        {
            HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_3_GameScene, "ChangePic", new Vector3(0, -110.0f, -1), new Vector3(358, 122, 1), "", "");
        }

        nCheck++;

        if (nMapNum == nCheckSame)
        {
            switch (nMapNum)
            {
                case 0:
                    nMapNum = Random.Range(1, 5);
                    break;

                case 1:
                    nMapNum = Random.Range(2, 5);
                    break;

                case 2:
                    nMapNum = Random.Range(3, 5);
                    break;

                case 3:
                    nMapNum = Random.Range(0, 3);
                    break;

                case 4:
                    nMapNum = Random.Range(0, 4);
                    break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (i == nMapNum)
            {
                MapsList[i].transform.localPosition = new Vector3(0, 0, -1);
                ChangeAlpha(i);
            }

            else
            {
                MapsList[i].transform.localPosition = new Vector3(-500, 0, -1);
            }
        }

        nCheckSame = nMapNum;
    }

    void ChangeAlpha(int nMap)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == nMap)
            {
                TweenAlpha.Begin(MapsList[i], 0.5f, 1.0f);
            }

            else
            {
                TweenAlpha.Begin(MapsList[i], 0.5f, 0.0f);
            }
        }
    }
}
