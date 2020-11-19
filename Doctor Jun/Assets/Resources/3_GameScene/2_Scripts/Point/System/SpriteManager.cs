using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {
    public GameObject Clear;
    
	// Use this for initialization
	void Start () {
        TweenScale.Begin(Clear, 0.25f, new Vector3(458.0f, 232.0f, 1.0f)).from = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
