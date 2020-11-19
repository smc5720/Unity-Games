using UnityEngine;
using System.Collections;

public class BloodErase : MonoBehaviour
{

    int time;
    // Use this for initialization
    void Start()
    {
        time = 200;
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }
}
