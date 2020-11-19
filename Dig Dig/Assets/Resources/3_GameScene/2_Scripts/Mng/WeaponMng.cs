using UnityEngine;
using System.Collections;

public class WeaponMng : MonoBehaviour
{
    public UIButton[] Buttons = new UIButton[16];
    public GameObject[] Lock = new GameObject[16];
    public GameObject[] Buyed = new GameObject[16];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 16; i++)
        {
            if (i == PlayerPrefs.GetInt("nWeaponLevel"))
            {
                if (TouchAndEarn.I.GetWeaponValue(i + 1) <= TouchAndEarn.I.nAllMoney)
                {
                    Buttons[i].isEnabled = true;
                    Lock[i].transform.localPosition = new Vector3(1000, 0, -12);
                    Buyed[i].transform.localPosition = new Vector3(1000, 0, -12);
                }

                else
                {
                    Buttons[i].isEnabled = false;
                    Lock[i].transform.localPosition = new Vector3(1000, 0, -12);
                    Buyed[i].transform.localPosition = new Vector3(1000, 0, -12);
                }
            }

            else if (i <= PlayerPrefs.GetInt("nWeaponLevel") - 1)
            {
                Buttons[i].isEnabled = false;
                Lock[i].transform.localPosition = new Vector3(1000, 0, -12);
                Buyed[i].transform.localPosition = new Vector3(0, 0, -12);
            }

            else
            {
                Buttons[i].isEnabled = false;
                Lock[i].transform.localPosition = new Vector3(0, 0, -12);
                Buyed[i].transform.localPosition = new Vector3(1000, 0, -12);
            }
        }
    }

    public void WeaponClient()
    {
        TouchAndEarn.I.nAllMoney -= TouchAndEarn.I.GetWeaponValue(PlayerPrefs.GetInt("nWeaponLevel") + 1);

        PlayerPrefs.SetInt("nWeaponLevel", PlayerPrefs.GetInt("nWeaponLevel") + 1);
    }
}