using UnityEngine;
using System.Collections;

public class BackMove : MonoBehaviour
{

    public Mng Manager;
    // Use this for initialization
    void Start()
    {
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
    }

    // Update is called once per frame
    void Update() {
        if (Manager.DieState == false)
        {
            gameObject.transform.localPosition += new Vector3(-3 * Manager.SlowDisSpeed, 0, 0);
            if (gameObject.transform.localPosition.x <= -800)
            {
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
	}
}
