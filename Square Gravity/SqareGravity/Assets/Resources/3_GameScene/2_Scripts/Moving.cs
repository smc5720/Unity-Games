using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    float speed;

    public Mng Manager;

    void Start()
    {
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
        speed = -50;
    }

    void Update()
    {
            if (speed >= 0)
                gameObject.rigidbody.velocity = new Vector3(-speed*Manager.SlowDisSpeed, 0, 0);
            else
                gameObject.rigidbody.velocity = new Vector3(-1 * Manager.SlowDisSpeed, 0, 0);
            speed += 1.8f * Manager.SlowDisSpeed;

        if (gameObject.transform.localPosition.x <= -450)
        {
            Destroy(gameObject);
        }
    }
}
