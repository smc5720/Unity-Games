using UnityEngine;
using System.Collections;

public class SPieGold : MonoBehaviour
{
    float fTimer;
    // Use this for initialization
    void Start()
    {
        TweenAlpha.Begin(gameObject, 0.5f, 0.0f);
        Vector3 labelPos = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 15, gameObject.transform.localPosition.z);
        SpringPosition.Begin(gameObject, labelPos, 10.0f);
        fTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        fTimer -= Time.deltaTime;

        if (fTimer <= 0)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
    }
}
