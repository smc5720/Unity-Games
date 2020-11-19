using UnityEngine;
using System.Collections;

public class PopupAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TweenScale.Begin(gameObject, 0.2f, new Vector3(1, 1, 1)).from = new Vector3(0.01f, 0.01f, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}