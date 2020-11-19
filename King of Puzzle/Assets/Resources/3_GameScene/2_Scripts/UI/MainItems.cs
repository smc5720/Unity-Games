using UnityEngine;
using System.Collections;

public class MainItems : MonoBehaviour
{

    public GameObject[] Items = new GameObject[5];
    public GameObject[] ItemsMng = new GameObject[5];
    public UICheckbox[] ItemCheck = new UICheckbox[5];
    bool[] CheckMoney = new bool[5];

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("FeverItem", 0);
        PlayerPrefs.SetInt("SpeedItem", 0);
        PlayerPrefs.SetInt("TimerItem", 0);
        PlayerPrefs.SetInt("NumberItem", 0);
        PlayerPrefs.SetInt("ChangeItem", 0);
        PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("Money"));
        for (int i = 0; i < 5; i++)
        {
            ItemCheck[i] = ItemsMng[i].GetComponent<UICheckbox>();
            CheckMoney[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemCheck[0].mChecked == true)
        {
            PlayerPrefs.SetInt("FeverItem", 1);
        }

        else if (ItemCheck[0].mChecked == false)
        {
            PlayerPrefs.SetInt("FeverItem", 0);
        }

        if (ItemCheck[1].mChecked == true)
        {
            PlayerPrefs.SetInt("SpeedItem", 1);
        }

        else if (ItemCheck[1].mChecked == false)
        {
            PlayerPrefs.SetInt("SpeedItem", 0);
        }

        if (ItemCheck[2].mChecked == true)
        {
            PlayerPrefs.SetInt("TimerItem", 1);
        }

        else if (ItemCheck[2].mChecked == false)
        {
            PlayerPrefs.SetInt("TimerItem", 0);
        }

        if (ItemCheck[3].mChecked == true)
        {
            PlayerPrefs.SetInt("NumberItem", 1);
        }

        else if (ItemCheck[3].mChecked == false)
        {
            PlayerPrefs.SetInt("NumberItem", 0);
        }

        if (ItemCheck[4].mChecked == true)
        {
            PlayerPrefs.SetInt("ChangeItem", 1);
        }

        else if (ItemCheck[4].mChecked == false)
        {
            PlayerPrefs.SetInt("ChangeItem", 0);
        }
    }

    void FeverClick()
    {
        if (CheckMoney[2] == false)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") - 2500);
            CheckMoney[2] = true;
        }

        else if (CheckMoney[2] == true)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") + 2500);
            CheckMoney[2] = false;
        }

        Items[0].transform.localPosition = new Vector3(0, 0, 0);
        Items[1].transform.localPosition = new Vector3(-500, 0, 0);
        Items[2].transform.localPosition = new Vector3(-500, 0, 0);
        Items[3].transform.localPosition = new Vector3(-500, 0, 0);
        Items[4].transform.localPosition = new Vector3(-500, 0, 0);
    }

    void SpeedClick()
    {
        if (CheckMoney[1] == false)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") - 2000);
            CheckMoney[1] = true;
        }

        else if (CheckMoney[1] == true)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") + 2000);
            CheckMoney[1] = false;
        }

        Items[0].transform.localPosition = new Vector3(-500, 0, 0);
        Items[1].transform.localPosition = new Vector3(0, 0, 0);
        Items[2].transform.localPosition = new Vector3(-500, 0, 0);
        Items[3].transform.localPosition = new Vector3(-500, 0, 0);
        Items[4].transform.localPosition = new Vector3(-500, 0, 0);
    }

    void TimerClick()
    {
        if (CheckMoney[0] == false)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") - 1500);
            CheckMoney[0] = true;
        }

        else if (CheckMoney[0] == true)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") + 1500);
            CheckMoney[0] = false;
        }

        Items[0].transform.localPosition = new Vector3(-500, 0, 0);
        Items[1].transform.localPosition = new Vector3(-500, 0, 0);
        Items[2].transform.localPosition = new Vector3(0, 0, 0);
        Items[3].transform.localPosition = new Vector3(-500, 0, 0);
        Items[4].transform.localPosition = new Vector3(-500, 0, 0);
    }

    void NumberClick()
    {
        if (CheckMoney[3] == false)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") - 1900);
            CheckMoney[3] = true;
        }

        else if (CheckMoney[3] == true)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") + 1900);
            CheckMoney[3] = false;
        }

        Items[0].transform.localPosition = new Vector3(-500, 0, 0);
        Items[1].transform.localPosition = new Vector3(-500, 0, 0);
        Items[2].transform.localPosition = new Vector3(-500, 0, 0);
        Items[3].transform.localPosition = new Vector3(0, 0, 0);
        Items[4].transform.localPosition = new Vector3(-500, 0, 0);
    }

    void ChangeClick()
    {
        if (CheckMoney[4] == false)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") - 1700);
            CheckMoney[4] = true;
        }

        else if (CheckMoney[4] == true)
        {
            PlayerPrefs.SetInt("FakeMoney", PlayerPrefs.GetInt("FakeMoney") + 1700);
            CheckMoney[4] = false;
        }

        Items[0].transform.localPosition = new Vector3(-500, 0, 0);
        Items[1].transform.localPosition = new Vector3(-500, 0, 0);
        Items[2].transform.localPosition = new Vector3(-500, 0, 0);
        Items[3].transform.localPosition = new Vector3(-500, 0, 0);
        Items[4].transform.localPosition = new Vector3(0, 0, 0);
    }
}