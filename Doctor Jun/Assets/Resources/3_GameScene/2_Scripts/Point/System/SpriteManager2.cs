using UnityEngine;
using System.Collections;

public class SpriteManager2 : MonoBehaviour {
    public GameObject Fail;

	// Use this for initialization
	void Start () {
        TweenScale.Begin(Fail, 0.25f, new Vector3(512.0f, 168.0f, 1.0f)).from = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
