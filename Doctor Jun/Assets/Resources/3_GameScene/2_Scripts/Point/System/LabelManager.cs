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
        GameLabel.text = (nTimer/60).ToString() + "�� " + (nTimer%60).ToString() + "��";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
