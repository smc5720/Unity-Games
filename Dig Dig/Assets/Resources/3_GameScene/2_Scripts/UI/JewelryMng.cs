using UnityEngine;
using System.Collections;

public class JewelryMng : MonoBehaviour
{
    bool bState;
    bool bChecked;
    float fTimer;
    Vector3 VecPos;
    UISprite ForAlpha;

    // Use this for initialization
    void Start()
    {
        bState = false;
        bChecked = false;
        gameObject.rigidbody.AddForce(Random.Range(-100, 100), Random.Range(0, 100), 0);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        ForAlpha = gameObject.GetComponent<UISprite>();
        fTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ForAlpha.alpha < 0.01f)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Q_JewNum", PlayerPrefs.GetInt("Q_JewNum") + 1);
        }

        if (gameObject.transform.localPosition.x <= -230 || gameObject.transform.localPosition.x >= 230)
        {
            gameObject.rigidbody.velocity = new Vector3(-gameObject.rigidbody.velocity.x, gameObject.rigidbody.velocity.y, 0);
        }

        if (gameObject.transform.localPosition.y <= -100 && bState == false)
        {
            gameObject.rigidbody.useGravity = false;
            gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            bState = true;
            VecPos = gameObject.transform.localPosition;
        }

        if (bState == true && bChecked == false)
        {
            fTimer += Time.deltaTime;
            gameObject.transform.localPosition = new Vector3(VecPos.x, -100, -1);

            if (fTimer >= 1.0f)
            {
                bChecked = true;
                Vector3 labelPos = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 100, gameObject.transform.localPosition.z);
                SpringPosition.Begin(gameObject, labelPos, 10.0f);
                TweenAlpha.Begin(gameObject, 0.5f, 0.0f);
                CheckValue(gameObject.tag);
            }
        }
    }

    public void CheckValue(string Jewelry)
    {
        switch (Jewelry)
        {
            case "Bronze":
                PlayerPrefs.SetInt("Bronze", PlayerPrefs.GetInt("Bronze") + 1);
                break;

            case "Silver":
                PlayerPrefs.SetInt("Silver", PlayerPrefs.GetInt("Silver") + 1);
                break;

            case "Gold":
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1);
                break;

            case "Amethyst":
                PlayerPrefs.SetInt("Amethyst", PlayerPrefs.GetInt("Amethyst") + 1);
                break;

            case "Topaz":
                PlayerPrefs.SetInt("Topaz", PlayerPrefs.GetInt("Topaz") + 1);
                break;

            case "Sapire":
                PlayerPrefs.SetInt("Sapire", PlayerPrefs.GetInt("Sapire") + 1);
                break;

            case "Ruby":
                PlayerPrefs.SetInt("Ruby", PlayerPrefs.GetInt("Ruby") + 1);
                break;
        }
    }
}
