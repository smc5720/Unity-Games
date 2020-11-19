using UnityEngine;
using System.Collections;

public class AdventureMode : MonoBehaviour
{
    public GameObject Ball;
    public Mng Manager;
    float speed ;
    int count;
    public AudioClip Effect;
    // Use this for initialization
    void Start()
    {
        count = 0;
        Ball = GameObject.Find("Ball");
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
        speed = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.x <= 250)
        {
            speed = 3f;
        }
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - speed * Manager.SlowDisSpeed, 0, 0);

        if (gameObject.transform.localPosition.x < -500)
        {
            Destroy(gameObject);
        }
        if (Ball.transform.localPosition.x >= gameObject.transform.localPosition.x)
        {
            if (count == 0)
            {
                Manager.Score++;
                count++;
                AudioSource.PlayClipAtPoint(Effect, transform.position);
            }
        }
    }
}
