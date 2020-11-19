using UnityEngine;
using System.Collections;

public class OnOffMng : MonoBehaviour {

    public GameObject[] button = new GameObject[2];
    public GameObject Popup;
    public GameObject SmallPopup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Popup.transform.localPosition = new Vector3(0, 875, 0);
        //    SmallPopup.animation.Play("CreatePopupAni");
        //}
	}

    void CanclePopup()
    {
        Popup.transform.localPosition = new Vector3(1000, 875, 0);
    }

    void YesClick()
    {
        Application.Quit();
    }

    void ClickOn(GameObject Obj)
    {
        switch (Obj.tag)
        {
            case "1":
                button[0].animation.Play("On");
                break;

            case "2":
                button[1].animation.Play("On");
                break;
        }
    }

    void ClickOff(GameObject Obj)
    {
        switch (Obj.tag)
        {
            case "1":
                button[0].animation.Play("Off");
                break;

            case "2":
                button[1].animation.Play("Off");
                break;
        }
    }
}