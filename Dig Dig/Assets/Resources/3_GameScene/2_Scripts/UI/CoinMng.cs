using UnityEngine;
using System.Collections;

public class CoinMng : MonoBehaviour
{
    bool bState;
    bool bChecked;
    float fTimer;
    Vector3 VecPos;
    public AudioClip CoinSound;

    // Use this for initialization
    void Start()
    {
        bState = false;
        bChecked = false;
        gameObject.rigidbody.AddForce(Random.Range(-100, 100), Random.Range(0, 100), 0);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        fTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y <= -100 && bState == false)
        {
            gameObject.rigidbody.useGravity = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            bState = true;
            VecPos = gameObject.transform.localPosition;
        }

        if (gameObject.transform.localPosition.x <= -230 || gameObject.transform.localPosition.x >= 230)
        {
            gameObject.rigidbody.velocity = new Vector3(-gameObject.rigidbody.velocity.x, gameObject.rigidbody.velocity.y, 0);
        }

        if (bState == true && bChecked == false)
        {
            fTimer += Time.deltaTime;
            gameObject.transform.localPosition = new Vector3(VecPos.x, -100, -1);

            if (fTimer >= 1.0f)
            {
                bChecked = true;
                TweenPosition.Begin(gameObject, 0.3f, new Vector3(-210, 330, -1));
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
            TouchAndEarn.I.GetCoin(TouchAndEarn.I.nMoneyNow);
            Destroy(gameObject);
        }
    }
}
