using UnityEngine;
using System.Collections;

public class BlackColAlpha : MonoBehaviour {
    UISprite BlackAlpha;
    TouchScript MapTouch;
    public AudioClip Effect1;
    public AudioClip Effect2;
    public AudioClip Effect3;
    public GameObject BlackCol;
	// Use this for initialization
	void Start () {
        BlackAlpha = BlackCol.GetComponent<UISprite>();
        MapTouch = GameObject.Find("Map2").GetComponent<TouchScript>();
        MapTouch.enabled = false;
        BlackAlpha.alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (BlackAlpha.alpha < 0.6f)
        {
            BlackAlpha.alpha += 0.06f;
        }
	}

    public void DestroyMother()
    {
        Time.timeScale = 1;
        MapTouch.enabled = true;
        HPrefabMng.I.DestroyPrefab(gameObject);
        AudioSource.PlayClipAtPoint(Effect1, transform.position);
    }

    public void GotoMain()
    {
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(Effect2, transform.position);
        Application.LoadLevel("2_MenuScene");
    }

    public void RetryTheGame()
    {
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(Effect3, transform.position);
        Application.LoadLevel("3_GameScene");
    }
}
