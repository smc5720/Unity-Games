using UnityEngine;
using System.Collections;

public class EscPopup : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.transform.localPosition.x <= -200.0f)
        {
            gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
            gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, -3.0f);
            gameObject.animation.Play("CreatePopupAni");
        }
	}

    void ProjectDown()
    {
        Application.Quit();
    }

    void ByePopup()
    {
        gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
        gameObject.transform.localPosition = new Vector3(-1500.0f, 0.0f, -3.0f);
    }
}
