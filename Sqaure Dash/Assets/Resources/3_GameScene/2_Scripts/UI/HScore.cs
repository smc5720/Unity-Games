using UnityEngine;
using System.Collections;

public class HScore : MonoBehaviour {
    UILabel ScoreLabel;

	// Use this for initialization
	void Start () {
        ScoreLabel = gameObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreLabel.text = PlayerPrefs.GetInt("HighScore").ToString();
	}
}
