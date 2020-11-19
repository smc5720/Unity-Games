using UnityEngine;
using System.Collections;

public class DestroyBtn : MonoBehaviour
{
    public GameObject[] LevelSprite = new GameObject[20];
    public GameObject Popup;
    public GameObject Popup2;
    public AudioClip LvSound;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.GetInt("Level") == i + 1)
            {
                LevelSprite[i] = GameObject.Find("Levels" + (i + 1).ToString());
                LevelSprite[i].transform.localPosition = new Vector3(-80, 0, 0);
            }

            else if (PlayerPrefs.GetInt("Level") + 1 == i + 1)
            {
                LevelSprite[i] = GameObject.Find("Levels" + (i + 1).ToString());
                LevelSprite[i].transform.localPosition = new Vector3(80, 0, 0);
            }

            else
            {
                LevelSprite[i] = GameObject.Find("Levels" + (i + 1).ToString());
                LevelSprite[i].transform.localPosition = new Vector3(-500, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        LevelSetting();
    }

    void OnClick()
    {
        if (PlayerPrefs.GetInt("Level") == 2 || PlayerPrefs.GetInt("Level") == 5 || PlayerPrefs.GetInt("Level") == 8 || PlayerPrefs.GetInt("Level") == 11 || PlayerPrefs.GetInt("Level") == 14 || PlayerPrefs.GetInt("Level") == 17 || PlayerPrefs.GetInt("Level") == 20)
        {
            Popup.transform.localPosition = new Vector3(-500.0f, 0.0f, 0.0f);
            Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
            AudioSource.PlayClipAtPoint(LvSound, transform.position);
            Popup2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            Popup2.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
            Popup2.animation.Play("CreatePopupAni");
        }

        else
        {
            PlayerPrefs.SetFloat("AddNumber", 0.01f);
            Popup.transform.localPosition = new Vector3(-500.0f, 0.0f, 0.0f);
            Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
        }
    }

    void LevelSetting()
    {
        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.GetInt("Level") - 1 == i + 1)
            {
                LevelSprite[i].transform.localPosition = new Vector3(-80, 0, 0);
            }

            else if (PlayerPrefs.GetInt("Level") == i + 1)
            {
                LevelSprite[i].transform.localPosition = new Vector3(80, 0, 0);
            }

            else
            {
                LevelSprite[i].transform.localPosition = new Vector3(-500, 0, 0);
            }
        }
    }
}
