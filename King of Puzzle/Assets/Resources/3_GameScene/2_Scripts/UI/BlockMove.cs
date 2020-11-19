using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour
{
    public Vector3 MoveVec;
    public bool bState;

    // Use this for initialization
    void Start()
    {
        MoveVec = gameObject.transform.localPosition;
        bState = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, MoveVec, 800.0f * Time.deltaTime);

        if (gameObject.transform.localPosition == MoveVec)
        {
            bState = false;
        }

        else
        {
            bState = true;
        }
    }
}