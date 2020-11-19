using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Camera MainCamera;
    public Gravity Manager;
    public Mng GameMng;
    public bool UpState;

    void Start()
    {
        GameMng = GameObject.Find("Mng").GetComponent<Mng>();
        Manager = GameObject.Find("Ball").GetComponent<Gravity>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpState = true;
            GameMng.DieState = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            UpState = false;
            GameMng.DieState = false;
        }
        if (UpState == true)
        {
            Manager.speed += 0.07f * GameMng.SlowDisSpeed;
            Manager.gravity = 0.00f;
        }
        if (UpState == false)
        {
            Manager.speed -= 0.06f * GameMng.SlowDisSpeed;
            Manager.gravity = 0.00f;
        }
        if (GameMng.DieState == true)
        {
            Manager.speed = 0;
        }
    }
}

