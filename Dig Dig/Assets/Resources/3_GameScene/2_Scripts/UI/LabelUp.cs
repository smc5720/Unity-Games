using UnityEngine;
using System.Collections;

public class LabelUp : MonoBehaviour
{
    float fTimer;

    // Use this for initialization
    void Start()
    {
        string DamageString = string.Format("{0:#,###}", TouchAndEarn.I.DamageText());

        gameObject.GetComponent<UILabel>().text = DamageString;

        TweenAlpha.Begin(gameObject, 0.5f, 0.0f);

        Vector3 labelPos = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 105, gameObject.transform.localPosition.z);

        SpringPosition.Begin(gameObject, labelPos, 10.0f);

        fTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;

        if (fTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}