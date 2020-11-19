using UnityEngine;
using System.Collections;

public class SpriteTurn : MonoBehaviour
{
    public Mng Manager;
    public Move Movi;
    // Use this for initialization
    void Start()
    {
        Movi = GameObject.Find("Mng").GetComponent<Move>();
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.DieState == false)
        {
            if (Movi.UpState == true)
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, -10 * Manager.SlowDisSpeed);
            }

            else
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, -3 * Manager.SlowDisSpeed);
            }
        }
    }
}
