using UnityEngine;
using System.Collections;

public class BackMove : MonoBehaviour {
    
    public GameObject[] BackSwap = new GameObject[2];
    public GameObject Camera2D;
    public string[] cSpriteName = new string[5];
    StartBtn MoveMng;
    float fTimer = 0.0f;

    void Awake()
    {
        for (int i = 1; i < 6; i++)
        {
            if (i == 1)
            {
                cSpriteName[i - 1] = "png";
            }

            else
            {
                cSpriteName[i - 1] = "png" + i.ToString();
            }
        }

        for (int i = 0; i < 2; i++)
        {
            BackSwap[i].GetComponent<UISprite>().spriteName = cSpriteName[PlayerPrefs.GetInt("BackGround")];
        }
    }

    // Use this for initialization
    void Start()
    {
        MoveMng = GameObject.Find("StartButton").GetComponent<StartBtn>();
    }

    // Update is called once per frame
    void Update()
    {
        fTimer += Time.deltaTime;

        if (fTimer >= 2.0f)
        {
            Camera2D.rigidbody.velocity = new Vector3(0.8f, 0, 0) * MoveMng.fSpeed;
        }

        for (int i = 0; i < 2; i++)
        {
            if (BackSwap[i].transform.localPosition.x + 800 <= Camera2D.transform.localPosition.x)
            {
                BackSwap[i].transform.localPosition = new Vector3(BackSwap[i].transform.localPosition.x + 1600, 0, 0);
            }
        }
    }
}
