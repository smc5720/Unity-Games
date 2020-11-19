using UnityEngine;
using System.Collections;

public class LfBtn : MonoBehaviour
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
        if (bIndex.nIndex != 0 && bIndex.nIndex != 3 && bIndex.nIndex != 6)
        {
            bIndex.nIndex--;
        }
    }
}