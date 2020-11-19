using UnityEngine;
using System.Collections;

public class NewsPaper : MonoBehaviour {
    public GameObject NewsGame;
    public GameObject Blacksheet;
    public GameObject News;

    public UIButton ForSee;

    public BoxCollider ForTouch;

    public AudioClip NewsSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("IsShopClicked") == "No")
        {
            ForTouch.enabled = true;
        }

        else
        {
            ForTouch.enabled = false;
        }

        if (PlayerPrefs.GetInt("NewsPaper") == 0)
        {
            News.transform.localPosition = new Vector3(500, 280, -1);
        }

        else if (PlayerPrefs.GetInt("NewsPaper") == 1)
        {
            News.transform.localPosition = new Vector3(200, 280, -1);
        }
	}

    void OnClick()
    {
        AudioSource.PlayClipAtPoint(NewsSound, transform.position);

        PlayerPrefs.SetInt("NewsPaper", 0);

        NewsGame.transform.localPosition = new Vector3(0, 0, -10);
        Blacksheet.transform.localPosition = new Vector3(0, 0, -11);
        ForSee.isEnabled = false;

        NewsGame.animation["PaperAni"].speed = 1;
        NewsGame.animation.Play("PaperAni");
    }

    void DownClick()
    {
        AudioSource.PlayClipAtPoint(NewsSound, transform.position);

        Blacksheet.transform.localPosition = new Vector3(1000, 0, -11);
        ForSee.isEnabled = true;
        NewsGame.animation["PaperAni"].normalizedTime = 1f;
        NewsGame.animation["PaperAni"].speed = -1;
        NewsGame.animation.Play("PaperAni");
    }
}
