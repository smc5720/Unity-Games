using UnityEngine;
using System.Collections;

public class Mng : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Struct;
    public GameObject AdventureBoxOrg;
    public GameObject BlockOrg;
    public float BlockSpeed;
    public int GameHard;

    
    public int Score;
    public UILabel ScoreLable;
    public bool DieState;

    public GameObject[] Fly = new GameObject[100];
    public float delay;
    public int count;
    public int BlockNum;

    public float SlowDelay;
    public bool SlowState;

    public float SlowDisSpeed;
    void Start()
    {
        DieState = true;
        Score = 0;
        GameHard = 1;
        SlowDelay = 70;
        SlowState = false;

        for (int i = 0; i < 100; i++)
        {
            Fly[i] = null;
        }

        SlowDisSpeed = 1;

        count = 0;
        delay = 60;
    }

    void Update()
    {
        ScoreLable.text = Score.ToString();
        if(DieState ==  false)
        AdventureMode();
    }

    public void SlowV()
    {
        if (SlowState == true)
        {
            SlowDelay--;
            if (SlowDelay < 0)
            {
                SlowDelay = 70;
                SlowState = false;
                SlowDisSpeed = 1;
            }
        }
    }

    void SlowMotionMode()
    {
        if (delay < 0)
        {
            int Height;
            Height = Random.Range(-180, 180);
            for (int i = 0; i < 100; i++)
            {
                if (Fly[i] == null)
                {
                    Fly[i] = CreatePrefab("Structure", count.ToString(), Struct, new Vector3(1, 1, 0), new Vector3(400, Height, 0));

                    break;
                }
            }
            count++;
            delay = Random.Range(5, 25);
        }
        delay -= SlowDisSpeed;
        SlowV();
    }

    void AdventureMode()
    {
        if (delay < 0)
        {
            GameObject AdventureBox;
            AdventureBox = CreatePrefab("Structure", count.ToString() + "Structure", AdventureBoxOrg, new Vector3(1, 1, 0), new Vector3(500, 0, 0));


            BlockNum = Random.Range(2, 5);

            CreateStruct(2);
            count++;
            if (GameHard == 1)
                delay = 70;
            if (GameHard == 2)
                delay = 50;
            if (GameHard == 3)
                delay = 50;
        }
        delay -= SlowDisSpeed;
        SlowV();
    }

    public void CreateStruct(int BlockNumber)
    {
        float Close=0;
        float BlockSize_T = 0;
        float ThisSize = 0;
        int LastBlock = BlockNumber;
        GameObject[] Block = new GameObject[10];
        for (int i = 0; i < BlockNumber; i++)
        {
            if (i != 0)
            {
                if (GameHard == 1)
                    Close = Random.Range(150, 190);
                if (GameHard == 2)
                    Close = Random.Range(120, 180);
                if (GameHard == 3)
                    Close = Random.Range(90, 130);
            }
            else
            {
                Close = 0; //Random.Range(((480 - ThisSize) / LastBlock) - 10, ((480 - ThisSize) / LastBlock) - 10);
            }

            ThisSize += Close;

            if (i == 0)
            {
                if (BlockNumber == 2)
                {
                    BlockSize_T = Random.Range(30, 280);
                    ThisSize += BlockSize_T;
                }
                if (BlockNumber == 3)
                {
                    BlockSize_T = Random.Range(30, 130);
                    ThisSize += BlockSize_T;
                }
                if (BlockNumber == 4)
                {
                    BlockSize_T = Random.Range(30, 80);
                    ThisSize += BlockSize_T;
                }

                Block[i] = CreatePrefab(count.ToString() + "Structure", count.ToString() + "Block", BlockOrg, new Vector3(40, BlockSize_T, 0), new Vector3(0, -240, 0));

            }
            if (i == 1)
            {
                BlockSize_T = ((480 - ThisSize) / LastBlock);
                Block[i] = CreatePrefab(count.ToString() + "Structure", count.ToString() + "Block", BlockOrg, new Vector3(40, BlockSize_T, 0), new Vector3(0, Block[0].transform.localPosition.y + Block[0].transform.localScale.y + Close, 0));
                ThisSize += BlockSize_T;
            }
            if (i == 2)
            {
                BlockSize_T = ((480 - ThisSize) / LastBlock);
                Block[i] = CreatePrefab(count.ToString() + "Structure", count.ToString() + "Block", BlockOrg, new Vector3(40, BlockSize_T, 0), new Vector3(0, Block[1].transform.localPosition.y + Block[1].transform.localScale.y + Close, 0));
                ThisSize += BlockSize_T;
            }
            if (i == 3)
            {
                BlockSize_T = ((480 - ThisSize) / LastBlock);
                Block[i] = CreatePrefab(count.ToString() + "Structure", count.ToString() + "Block", BlockOrg, new Vector3(40, BlockSize_T, 0), new Vector3(0, Block[2].transform.localPosition.y + Block[2].transform.localScale.y + Close, 0));
                ThisSize += BlockSize_T;
            }

            LastBlock--;
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
}
