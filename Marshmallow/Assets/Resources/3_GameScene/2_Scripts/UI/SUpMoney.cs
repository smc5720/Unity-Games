using UnityEngine;
using System.Collections;

public class SUpMoney : MonoBehaviour {
    public UILabel MoneyLabel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MoneyLabel.GetComponent<UILabel>().text = HeroStateMng.I.nMoney.ToString() + " $";
	}
}
