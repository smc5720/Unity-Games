using UnityEngine;
using System.Collections;

public class DeleteData : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        PlayerPrefs.SetInt("NowScore", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetFloat("LevelAmount", 0);
        PlayerPrefs.SetFloat("FullLvAmount", 0);
        PlayerPrefs.SetFloat("PlusAmount", 0);
        PlayerPrefs.SetInt("isMute", 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("FakeMoney", 0);
        PlayerPrefs.SetFloat("AddNumber", 0);
        PlayerPrefs.SetInt("itemNumber", 0);
        PlayerPrefs.SetInt("FeverItem", 0);
        PlayerPrefs.SetInt("SpeedItem", 0);
        PlayerPrefs.SetInt("TimerItem", 0);
        PlayerPrefs.SetInt("ChangeItem", 0);
        PlayerPrefs.SetInt("NumberItem", 0);
    }
}
