using UnityEngine;
using System.Collections;

public class LabelManager : MonoBehaviour {
    UILabel GameLabel;
    PointSingleTon SingleTon;
    int nTimer;

	// Use this for initialization
	void Start () {
        SingleTon = PointSingleTon.I;
        GameLabel = gameObject.GetComponent<UILabel>();
        nTimer = (int)SingleTon.fFullTimer;
        GameLabel.text = (nTimer/60).ToString() + "Ка " + (nTimer%60).ToString() + "УЪ";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
