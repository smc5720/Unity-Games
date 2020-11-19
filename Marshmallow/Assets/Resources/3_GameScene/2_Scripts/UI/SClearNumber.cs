using UnityEngine;
using System.Collections;

public class SClearNumber : MonoBehaviour {
    public UILabel ClearLabel;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClearLabel.GetComponent<UILabel>().text = HeroStateMng.I.nHunted.ToString() + " / " + HeroStateMng.I.nClearNum.ToString();
	}
}