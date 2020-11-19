using UnityEngine;
using System.Collections;

public class GlassNum : MonoBehaviour {

   public float fTimer;

	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
        gameObject.transform.localPosition = new Vector3(500, 0, -7);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localPosition.x <= 200)
        {
            fTimer += Time.deltaTime;

            if (fTimer >= 5.0f)
            {
                TweenAlpha.Begin(gameObject, 0.2f, 0.0f);
            }

            if (fTimer >= 5.2f)
            {
                gameObject.transform.localPosition = new Vector3(500, 0, -7);
                fTimer = 0.0f;
            }
        }
	}
}
