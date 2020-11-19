using UnityEngine;
using System.Collections;

public class RtBtn : MonoBehaviour
{
    public GameObject BallGame;
    Ball bIndex;

    // Use this for initialization
    void Start()
    {
        bIndex = GameObject.Find("Ball").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClick()
    {
        if (bIndex.nIndex != 2 && bIndex.nIndex != 5 && bIndex.nIndex != 8)
        {
            bIndex.nIndex++;
        }
    }
}