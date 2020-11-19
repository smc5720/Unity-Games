using UnityEngine;
using System.Collections;

public class PopupAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TweenScale.Begin(gameObject, 0.2f, new Vector3(400.0f, 400.0f, 1.0f)).from = new Vector3(0.01f, 0.01f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
