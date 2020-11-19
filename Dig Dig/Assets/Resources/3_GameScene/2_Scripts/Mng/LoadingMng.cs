using UnityEngine;
using System.Collections;

public class LoadingMng : MonoBehaviour {

    float fTimer;
    int nRandom;
    public UISprite s_Text;
    public GameObject g_Text;
    
    
	// Use this for initialization
	void Start () {
        fTimer = 0.0f;
        nRandom = Random.Range(1, 5);

        switch (nRandom)
        {
            case 1:

                s_Text.spriteName = "Txt_1";

                g_Text.transform.localScale = new Vector3(368,44,1);

                break;

            case 2:

                s_Text.spriteName = "Txt_2";

                g_Text.transform.localScale = new Vector3(343, 21, 1);

                break;

            case 3:

                s_Text.spriteName = "Txt_3";

                g_Text.transform.localScale = new Vector3(338, 43, 1);

                break;

            case 4:

                s_Text.spriteName = "Txt_4";

                g_Text.transform.localScale = new Vector3(329, 45, 1);

                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= Random.Range(3.0f, 5.0f))
        {
            Application.LoadLevel("3_GameScene");
        }
	}
}
