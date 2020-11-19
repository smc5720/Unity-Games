using UnityEngine;
using System.Collections;

public class ShopAniMng : MonoBehaviour
{
    public GameObject[] Buttons = new GameObject[4];
    public GameObject[] indexs = new GameObject[4];
    UISprite[] indexSprite = new UISprite[4];

    public AudioClip Indexclick;

    public GameObject ShopClose;
    BoxCollider ShopCollider;

    // Use this for initialization
    void Start()
    {
        ShopCollider = ShopClose.GetComponent<BoxCollider>();
        ShopCollider.enabled = false;

        for (int i = 0; i < 4; i++)
        {
            indexSprite[i] = indexs[i].GetComponent<UISprite>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpBtnClick(GameObject Button)
    {
        PlayerPrefs.SetString("IsShopClicked", "Yes");

        ShopCollider.enabled = true;

        AudioSource.PlayClipAtPoint(Indexclick, transform.position);

        switch (Button.tag)
        {
            case "Red":

                indexSprite[0].spriteName = "Exchange2";
                indexSprite[1].spriteName = "Equipment";
                indexSprite[2].spriteName = "Minion1";
                indexSprite[3].spriteName = "Set";

                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, 0, 0);
                        indexs[i].transform.localScale = new Vector3(120, 56, 1);
                    }

                    else
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, -1000, 0);
                        indexs[i].transform.localScale = new Vector3(120, 36, 1);
                    }
                }
                break;

            case "Yellow":

                indexSprite[0].spriteName = "Exchange1";
                indexSprite[1].spriteName = "Equipment2";
                indexSprite[2].spriteName = "Minion1";
                indexSprite[3].spriteName = "Set";

                for (int i = 0; i < 4; i++)
                {
                    if (i == 1)
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, 0, 0);
                        indexs[i].transform.localScale = new Vector3(120, 56, 1);
                    }

                    else
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, -1000, 0);
                        indexs[i].transform.localScale = new Vector3(120, 36, 1);
                    }
                }
                break;

            case "Green":

                indexSprite[0].spriteName = "Exchange1";
                indexSprite[1].spriteName = "Equipment";
                indexSprite[2].spriteName = "Minion2";
                indexSprite[3].spriteName = "Set";

                for (int i = 0; i < 4; i++)
                {
                    if (i == 2)
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, 0, 0);
                        indexs[i].transform.localScale = new Vector3(120, 56, 1);
                    }

                    else
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, -1000, 0);
                        indexs[i].transform.localScale = new Vector3(120, 36, 1);
                    }
                }
                break;

            case "Blue":

                indexSprite[0].spriteName = "Exchange1";
                indexSprite[1].spriteName = "Equipment";
                indexSprite[2].spriteName = "Minion1";
                indexSprite[3].spriteName = "Set2";

                for (int i = 0; i < 4; i++)
                {
                    if (i == 3)
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, 0, 0);
                        indexs[i].transform.localScale = new Vector3(120, 56, 1);
                    }

                    else
                    {
                        Buttons[i].transform.localPosition = new Vector3(0, -1000, 0);
                        indexs[i].transform.localScale = new Vector3(120, 36, 1);
                    }
                }
                break;
        }
        if (transform.localPosition.y <= -300)
        {
            animation["Shop"].speed = 1;
            animation.Play("Shop");
        }
    }

    void DownBtnClick()
    {
        ShopCollider.enabled = false;
        PlayerPrefs.SetString("IsShopClicked", "No");
        animation["Shop"].normalizedTime = 1f;
        animation["Shop"].speed = -1;
        animation.Play("Shop");

        indexSprite[0].spriteName = "Exchange1";
        indexSprite[1].spriteName = "Equipment";
        indexSprite[2].spriteName = "Minion1";
        indexSprite[3].spriteName = "Set";

        for (int i = 0; i < 4; i++)
        {
            indexs[i].transform.localScale = new Vector3(120, 36, 1);
        }
    }
}
