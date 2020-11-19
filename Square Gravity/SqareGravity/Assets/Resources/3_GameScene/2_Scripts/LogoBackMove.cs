using UnityEngine;
using System.Collections;

public class LogoBackMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.localPosition += new Vector3(-3, 0, 0);
        if (gameObject.transform.localPosition.x <= -800)
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }


    }
}
