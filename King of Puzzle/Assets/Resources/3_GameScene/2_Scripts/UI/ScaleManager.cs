using UnityEngine;
using System.Collections;

public class ScaleManager : MonoBehaviour {
    float fScaler;
    public GameObject UIObject;
    public GameObject ScaleCamera1;
    public GameObject ScaleCamera2;
    Camera ScriptCamera1;
    Camera ScriptCamera2;

	// Use this for initialization
	void Start () {
        fScaler = 0.01f;
        ScriptCamera1 = ScaleCamera1.GetComponent<Camera>();
        ScriptCamera2 = ScaleCamera2.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if(UIObject.transform.localScale.x > 0.5)
        {
            UIObject.transform.localScale = new Vector3(UIObject.transform.localScale.x - fScaler, UIObject.transform.localScale.y - fScaler, UIObject.transform.localScale.z);
            ScriptCamera1.orthographicSize -= fScaler;
            ScriptCamera2.orthographicSize -= fScaler;
        }

        else if (UIObject.transform.localScale.x <= 0.5)
        {
            UIObject.transform.localScale = new Vector3(0.5f, 0.5f, UIObject.transform.localScale.z);
            ScriptCamera1.orthographicSize = 0.5f;
            ScriptCamera2.orthographicSize = 0.5f;
        }
    }
}