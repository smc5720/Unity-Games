using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public GameObject[] ButtonObject = new GameObject[2];

	// Use this for initialization
	void Start () {
        ButtonObject[0].GetComponent<UILabel>().text = PlayerPrefs.GetInt("CurrentScore").ToString();
        ButtonObject[1].GetComponent<UILabel>().text = PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MenuClick()
    {
        Application.LoadLevel("2_MenuScene");
    }

    void ReBtnClick()
    {
        Application.LoadLevel("3_GameScene");
    }
}
