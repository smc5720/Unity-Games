using UnityEngine;
using System.Collections;

public class PageLabel : MonoBehaviour {
    PointSingleTon SingleTon;
    UILabel Page;
	// Use this for initialization
	void Start () {
        SingleTon = PointSingleTon.I;
        Page = gameObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        Page.text = SingleTon.nPages.ToString();
	}
}
