using UnityEngine;
using System.Collections;

public class ItemDisable : MonoBehaviour
{
    public GameObject[] Buttons = new GameObject[5];
    UIButton[] DisableBtn = new UIButton[5];
    UICheckbox[] mCheck = new UICheckbox[5];

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("FakeMoney") <= 0)
        {
            PlayerPrefs.SetInt("FakeMoney", 0);
        }
        
        for (int i = 0; i < 5; i++)
        {
            DisableBtn[i] = Buttons[i].GetComponent<UIButton>();
            mCheck[i] = Buttons[i].GetComponent<UICheckbox>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (2000 <= PlayerPrefs.GetInt("FakeMoney") && PlayerPrefs.GetInt("FakeMoney") < 2500)
        {
            CheckMoney(1);
        }

        if (1900 <= PlayerPrefs.GetInt("FakeMoney") && PlayerPrefs.GetInt("FakeMoney") < 2000)
        {
            CheckMoney(2);
        }

        if (1700 <= PlayerPrefs.GetInt("FakeMoney") && PlayerPrefs.GetInt("FakeMoney") < 1900)
        {
            CheckMoney(3);
        }

        if (1500 <= PlayerPrefs.GetInt("FakeMoney") && PlayerPrefs.GetInt("FakeMoney") < 1700)
        {
            CheckMoney(4);
        }

        if (PlayerPrefs.GetInt("FakeMoney") < 1500)
        {
            CheckMoney(5);
        }

        if (PlayerPrefs.GetInt("FakeMoney") >= 2500)
        {
            CheckMoney(0);
        }
    }

    void CheckMoney(int nMoney)
    {
        switch (nMoney)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    DisableBtn[i].isEnabled = true;
                }
                break;

            case 1:
                for (int i = 0; i < nMoney; i++)
                {
                    if (mCheck[i].mChecked == false)
                    {
                        DisableBtn[i].isEnabled = false;
                    }
                }
                break;

            case 2:
                for (int i = 0; i < nMoney; i++)
                {
                    if (mCheck[i].mChecked == false)
                    {
                        DisableBtn[i].isEnabled = false;
                    }
                }
                break;

            case 3:
                for (int i = 0; i < nMoney; i++)
                {
                    if (mCheck[i].mChecked == false)
                    {
                        DisableBtn[i].isEnabled = false;
                    }
                }
                break;

            case 4:
                for (int i = 0; i < nMoney; i++)
                {
                    if (mCheck[i].mChecked == false)
                    {
                        DisableBtn[i].isEnabled = false;
                    }
                }
                break;

            case 5:
                for (int i = 0; i < nMoney; i++)
                {
                    if (mCheck[i].mChecked == false)
                    {
                        DisableBtn[i].isEnabled = false;
                    }
                }
                break;
        }
    }
}