using UnityEngine;
using System.Collections;

public class AniChange : MonoBehaviour
{
    bool bState;
    float fTimer;
    // Use this for initialization
    void Start()
    {
        gameObject.animation.Play("Title");
        bState = false;
        fTimer = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.8f)
        {
            bState = true;
        }

        if (bState == true)
        {
            gameObject.animation.Play("Title2");
            bState = false;
        }
	}
}
