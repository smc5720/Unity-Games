using UnityEngine;
using System.Collections;

public class SlowCheckBox : MonoBehaviour
{
    public Mng Manager;

    void Start()
    {
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Struct")
        {
            Manager.SlowState = true;
            Manager.SlowDisSpeed = 0.01f;
        }
    }
}
