using UnityEngine;
using System.Collections;

public class InventoryMng : MonoBehaviour
{
    public UILabel[] Jewelrys = new UILabel[7];

    public UILabel Weapon_Font;

    public UISprite s_Weapon;

    public UISprite s_Font;
    public GameObject g_FontScale;


    public GameObject Popup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Weapon_Font.text = ((int)TouchAndEarn.I.f_NowDamage).ToString();

        Jewelrys[0].text = PlayerPrefs.GetInt("Bronze").ToString();

        Jewelrys[1].text = PlayerPrefs.GetInt("Silver").ToString();

        Jewelrys[2].text = PlayerPrefs.GetInt("Gold").ToString();

        Jewelrys[3].text = PlayerPrefs.GetInt("Amethyst").ToString();

        Jewelrys[4].text = PlayerPrefs.GetInt("Topaz").ToString();

        Jewelrys[5].text = PlayerPrefs.GetInt("Sapire").ToString();

        Jewelrys[6].text = PlayerPrefs.GetInt("Ruby").ToString();

        switch (PlayerPrefs.GetInt("nWeaponLevel"))
        {
            case 1:
                s_Weapon.spriteName = "Branch";
                s_Font.spriteName = "Branch_Font";
                g_FontScale.transform.localScale = new Vector3(51, 22, 1);
                break;

            case 2:
                s_Weapon.spriteName = "Stone";
                s_Font.spriteName = "Stone_Font";
                g_FontScale.transform.localScale = new Vector3(41, 22, 1);
                break;

            case 3:
                s_Weapon.spriteName = "Awl";
                s_Font.spriteName = "Awl_Font";
                g_FontScale.transform.localScale = new Vector3(23, 22, 1);
                break;

            case 4:
                s_Weapon.spriteName = "Sword";
                s_Font.spriteName = "Sword_Font";
                g_FontScale.transform.localScale = new Vector3(16, 22, 1);
                break;

            case 5:
                s_Weapon.spriteName = "Hom";
                s_Font.spriteName = "Hom_Font";
                g_FontScale.transform.localScale = new Vector3(25, 15, 1);
                break;

            case 6:
                s_Weapon.spriteName = "Shovel";
                s_Font.spriteName = "Shovel_Font";
                g_FontScale.transform.localScale = new Vector3(17, 22, 1);
                break;

            case 7:
                s_Weapon.spriteName = "Hammer";
                s_Font.spriteName = "Hammer_Font";
                g_FontScale.transform.localScale = new Vector3(28, 22, 1);
                break;

            case 8:
                s_Weapon.spriteName = "Crowbar";
                s_Font.spriteName = "Crowbar_Font";
                g_FontScale.transform.localScale = new Vector3(26, 16, 1);
                break;

            case 9:
                s_Weapon.spriteName = "Pickax";
                s_Font.spriteName = "Pickax_Font";
                g_FontScale.transform.localScale = new Vector3(41, 22, 1);
                break;

            case 10:
                s_Weapon.spriteName = "Drill";
                s_Font.spriteName = "Drill_Font";
                g_FontScale.transform.localScale = new Vector3(25, 22, 1);
                break;

            case 11:
                s_Weapon.spriteName = "Excavator";
                s_Font.spriteName = "Excavator_Font";
                g_FontScale.transform.localScale = new Vector3(38, 22, 1);
                break;

            case 12:
                s_Weapon.spriteName = "Flame thrower";
                s_Font.spriteName = "Flame thrower_Font";
                g_FontScale.transform.localScale = new Vector3(67, 22, 1);
                break;

            case 13:
                s_Weapon.spriteName = "RPG-7";
                s_Font.spriteName = "RPG-7_Font";
                g_FontScale.transform.localScale = new Vector3(43, 18, 1);
                break;

            case 14:
                s_Weapon.spriteName = "Dynamite";
                s_Font.spriteName = "Dynamite_Font";
                g_FontScale.transform.localScale = new Vector3(75, 15, 1);
                break;

            case 15:
                s_Weapon.spriteName = "Laser";
                s_Font.spriteName = "Laser_Font";
                g_FontScale.transform.localScale = new Vector3(42, 15, 1);
                break;

            case 16:
                s_Weapon.spriteName = "Plasma Cutters";
                s_Font.spriteName = "Plasma Cutters_Font";
                g_FontScale.transform.localScale = new Vector3(97, 22, 1);
                break;
        }
    }
}