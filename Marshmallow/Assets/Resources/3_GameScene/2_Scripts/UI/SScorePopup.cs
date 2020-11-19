using UnityEngine;
using System.Collections;

public class SScorePopup : MonoBehaviour {
    public UILabel ScoreLabel;
    public UILabel MonsterLabel;
    public UILabel GoldLabel;

	// Use this for initialization
	void Start () {
        ScoreLabel.GetComponent<UILabel>().text = HeroStateMng.I.nScore.ToString() + "Á¡";
        GoldLabel.GetComponent<UILabel>().text = HeroStateMng.I.nFullMoney.ToString() + " $";
        MonsterLabel.GetComponent<UILabel>().text = HeroStateMng.I.nMonsterKilled.ToString() + "¸¶¸®";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
