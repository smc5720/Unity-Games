using UnityEngine;
using System.Collections;

public class Destroy2Btn : MonoBehaviour
{
    public GameObject Popup;
    public GameObject[] Star = new GameObject[7];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            PlayerPrefs.SetInt("itemNumber", 1);
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 5)
        {
            PlayerPrefs.SetInt("itemNumber", 2);
            for (int i = 0; i < 7; i++)
            {
                if (i == 1)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 8)
        {
            PlayerPrefs.SetInt("itemNumber", 3);
            for (int i = 0; i < 7; i++)
            {
                if (i == 2)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 11)
        {
            PlayerPrefs.SetInt("itemNumber", 4);
            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 14)
        {
            PlayerPrefs.SetInt("itemNumber", 5);
            for (int i = 0; i < 7; i++)
            {
                if (i == 4)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 17)
        {
            PlayerPrefs.SetInt("itemNumber", 6);
            for (int i = 0; i < 7; i++)
            {
                if (i == 5)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }

        else if (PlayerPrefs.GetInt("Level") == 20)
        {
            PlayerPrefs.SetInt("itemNumber", 7);
            for (int i = 0; i < 7; i++)
            {
                if (i == 6)
                {
                    Star[i].transform.localPosition = new Vector3(0, 0, 0);
                }

                else
                {
                    Star[i].transform.localPosition = new Vector3(-500, 0, 0);
                }
            }
        }
    }

    void OnClick()
    {
        PlayerPrefs.SetFloat("AddNumber", 0.01f);
        Popup.transform.localPosition = new Vector3(-500.0f, 0.0f, 0.0f);
        Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
    }
}