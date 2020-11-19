using UnityEngine;
using System.Collections;

public class PetJewelry : MonoBehaviour
{
    float fTimer;
    public GameObject Obj;

    // Use this for initialization
    void Start()
    {
        TweenAlpha.Begin(Obj, 1.0f, 0.0f);

        Vector3 labelPos = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 15, gameObject.transform.localPosition.z);

        SpringPosition.Begin(gameObject, labelPos, 10.0f);

        fTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;

        if (fTimer <= 0)
        {
            PlayerPrefs.SetInt("Q_JewNum", PlayerPrefs.GetInt("Q_JewNum") + 1);
            Destroy(gameObject);
        }
    }
}