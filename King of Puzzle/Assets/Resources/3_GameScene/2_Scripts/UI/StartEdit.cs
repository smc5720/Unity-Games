using UnityEngine;
using System.Collections;

public class StartEdit : MonoBehaviour
{
    float fTimer;
    string nGName;

    // Use this for initialization
    void Start()
    {
        fTimer = 0.0f;
        nGName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.x >= -200.0f)
        {
            fTimer += Time.deltaTime;
            if (nGName == "BackCol")
            {
                if (fTimer >= 4.0f)
                {
                    Destroy(gameObject);
                }
            }

            else
            {
                if (fTimer >= 0.5f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
