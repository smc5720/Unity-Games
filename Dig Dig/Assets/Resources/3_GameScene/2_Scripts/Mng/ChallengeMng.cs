using UnityEngine;
using System.Collections;

public class ChallengeMng : MonoBehaviour {

    public UIButton[] CButton = new UIButton[10];
    public GameObject[] Success = new GameObject[10];

    public AudioClip ButtonSound;

    public GameObject Popup;
    public GameObject BlackSheet;

    public UIButton ForTouch;

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


        if (PlayerPrefs.GetInt("Q_TouchNum") >= 100 && PlayerPrefs.GetInt("Challenge_1") != 1)
        {
            CButton[0].isEnabled = true;
            Success[0].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_TouchNum") >= 100 && PlayerPrefs.GetInt("Challenge_1") == 1)
        {
            CButton[0].isEnabled = false;
            Success[0].transform.localPosition = new Vector3(0, 0, -6);
        }

        else 
        {
            CButton[0].isEnabled = false;
            Success[0].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_TouchNum") >= 1000 && PlayerPrefs.GetInt("Challenge_2") != 1)
        {
            CButton[1].isEnabled = true;
            Success[1].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_TouchNum") >= 1000 && PlayerPrefs.GetInt("Challenge_2") == 1)
        {
            CButton[1].isEnabled = false;
            Success[1].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[1].isEnabled = false;
            Success[1].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_TouchNum") >= 10000 && PlayerPrefs.GetInt("Challenge_3") != 1)
        {
            CButton[2].isEnabled = true;
            Success[2].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_TouchNum") >= 10000 && PlayerPrefs.GetInt("Challenge_3") == 1)
        {
            CButton[2].isEnabled = false;
            Success[2].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[2].isEnabled = false;
            Success[2].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_JewNum") >= 100 && PlayerPrefs.GetInt("Challenge_4") != 1)
        {
            CButton[3].isEnabled = true;
            Success[3].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_JewNum") >= 100 && PlayerPrefs.GetInt("Challenge_4") == 1)
        {
            CButton[3].isEnabled = false;
            Success[3].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[3].isEnabled = false;
            Success[3].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_JewNum") >= 1000 && PlayerPrefs.GetInt("Challenge_5") != 1)
        {
            CButton[4].isEnabled = true;
            Success[4].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_JewNum") >= 1000 && PlayerPrefs.GetInt("Challenge_5") == 1)
        {
            CButton[4].isEnabled = false;
            Success[4].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[4].isEnabled = false;
            Success[4].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_JewNum") >= 10000 && PlayerPrefs.GetInt("Challenge_6") != 1)
        {
            CButton[5].isEnabled = true;
            Success[5].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_JewNum") >= 10000 && PlayerPrefs.GetInt("Challenge_6") == 1)
        {
            CButton[5].isEnabled = false;
            Success[5].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[5].isEnabled = false;
            Success[5].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_Biggest") >= 10 && PlayerPrefs.GetInt("Challenge_7") != 1)
        {
            CButton[6].isEnabled = true;
            Success[6].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_Biggest") >= 10 && PlayerPrefs.GetInt("Challenge_7") == 1)
        {
            CButton[6].isEnabled = false;
            Success[6].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[6].isEnabled = false;
            Success[6].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_Biggest") >= 100 && PlayerPrefs.GetInt("Challenge_8") != 1)
        {
            CButton[7].isEnabled = true;
            Success[7].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_Biggest") >= 100 && PlayerPrefs.GetInt("Challenge_8") == 1)
        {
            CButton[7].isEnabled = false;
            Success[7].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[7].isEnabled = false;
            Success[7].transform.localPosition = new Vector3(1000, 0, -6);
        }




        if (PlayerPrefs.GetInt("Q_Smallest") >= 10 && PlayerPrefs.GetInt("Challenge_9") != 1)
        {
            CButton[8].isEnabled = true;
            Success[8].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_Smallest") >= 10 && PlayerPrefs.GetInt("Challenge_9") == 1)
        {
            CButton[8].isEnabled = false;
            Success[8].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[8].isEnabled = false;
            Success[8].transform.localPosition = new Vector3(1000, 0, -6);
        }



        if (PlayerPrefs.GetInt("Q_Smallest") >= 100 && PlayerPrefs.GetInt("Challenge_10") != 1)
        {
            CButton[9].isEnabled = true;
            Success[9].transform.localPosition = new Vector3(1000, 0, -6);
        }

        else if (PlayerPrefs.GetInt("Q_Smallest") >= 100 && PlayerPrefs.GetInt("Challenge_10") == 1)
        {
            CButton[9].isEnabled = false;
            Success[9].transform.localPosition = new Vector3(0, 0, -6);
        }

        else
        {
            CButton[9].isEnabled = false;
            Success[9].transform.localPosition = new Vector3(1000, 0, -6);
        }
	}

    void ChallengeCheck(GameObject Obj)
    {
        PlayerPrefs.SetInt("Challenge_" + Obj.tag, 1);
    }

    void ButtonClick()
    {
        AudioSource.PlayClipAtPoint(ButtonSound, transform.position);

        BlackSheet.transform.localPosition = new Vector3(0, 0, -5);
        Popup.animation["Challenge"].speed = 1;
        Popup.animation.Play("Challenge");

        PlayerPrefs.SetString("IsShopClicked", "Yes");
    }

    void BackClick()
    {
        BlackSheet.transform.localPosition = new Vector3(1000, 0, -5);
        Popup.animation["Challenge"].normalizedTime = 1f;
        Popup.animation["Challenge"].speed = -1;
        Popup.animation.Play("Challenge");

        PlayerPrefs.SetString("IsShopClicked", "No");
    }
}