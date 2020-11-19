using UnityEngine;
using System.Collections;

public class PopupStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ScaleTrans()
    {
        TweenScale.Begin(gameObject, 0.5f, new Vector3(100.0f, 100.0f, 1.0f));
    }

    public void ColorTrans()
    {
        TweenColor.Begin(gameObject, 0.9f, Color.yellow);
    }
}