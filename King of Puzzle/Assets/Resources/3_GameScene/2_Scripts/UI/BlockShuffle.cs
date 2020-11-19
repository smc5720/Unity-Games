using UnityEngine;
using System.Collections;

public class BlockShuffle : MonoBehaviour
{
    public GameObject[] Block;
    public AudioClip Effect;
    public GameObject[] Case = new GameObject[5];
    public GameObject[] Full = new GameObject[5];
    BallSingleTon BallMng;
    BlockMove[] BlockMng;
    public Vector3[] Array;
    public int nCheckNum;
    public GameObject MapTrans;
    MapTrans MapChange;

    // Use this for initialization
    void Start()
    {
        Array = new Vector3[9];
        BlockMng = new BlockMove[9];
        BallMng = BallSingleTon.I;
        nCheckNum = 0;
        MapChange = MapTrans.GetComponent<MapTrans>();

        for (int i = 0; i < 9; i++)
        {
            BlockMng[i] = Block[i].GetComponent<BlockMove>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nCheckNum == 5 && BallMng.nResetMap != 5)
        {
            ShufflePos();
            BallMng.nResetMap++;
            nCheckNum = 0;
        }

        else if (nCheckNum == 5 && BallMng.nResetMap == 5)
        {
            AudioSource.PlayClipAtPoint(Effect, transform.position);
            ResetPos();
            BallMng.nResetMap = 0;
            nCheckNum = 0;
            MapChange.ShuffleMap();
        }
    }

    public void ResetPos()
    {
        for (int i = 0; i < 5; i++)
        {
            Case[i].animation.Play("AllSmall");
            TweenAlpha.Begin(Full[i], 0.2f, 0.0f);
        }

        for (int i = 0; i < 9; i++)
        {
            Array[i] = BallMng.VecPos[i];
        }

        for (int i = 0; i < 9; i++)
        {
            BlockMng[i].MoveVec = Array[i];
        }
    }

    public void ResetPos2()
    {
        for (int i = 0; i < 9; i++)
        {
            Array[i] = BallMng.VecPos[i];
        }

        for (int i = 0; i < 9; i++)
        {
            BlockMng[i].MoveVec = Array[i];
        }
    }

    void ShufflePos()
    {
        int nPreNum, nNextNum;
        Vector3 nTemp;
        Case[BallMng.nResetMap].transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        Case[BallMng.nResetMap].animation.Play("ChangePic");
        TweenAlpha.Begin(Full[BallMng.nResetMap], 0.2f, 1.0f);
        for (int i = 0; i < 9; i++)
        {
            Array[i] = BallMng.VecPos[i];
        }

        for (int i = 0; i < 9; i++)
        {
            nPreNum = Random.Range(0, 9);
            nNextNum = Random.Range(0, 9);
            nTemp = Array[nPreNum];
            Array[nPreNum] = Array[nNextNum];
            Array[nNextNum] = nTemp;
        }

        for (int i = 0; i < 9; i++)
        {
            BlockMng[i].MoveVec = Array[i];
        }
    }
}