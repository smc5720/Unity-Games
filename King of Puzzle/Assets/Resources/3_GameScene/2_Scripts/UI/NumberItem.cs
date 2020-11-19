using UnityEngine;
using System.Collections;

public class NumberItem : MonoBehaviour {

    float fTimer;
    BoxCollider BoxGame;
    public GameObject GlassObject;
    GlassNum GetGlass;

	// Use this for initialization
	void Start () {
        GlassObject = GameObject.Find("GlassNum");
        BoxGame = gameObject.GetComponent<BoxCollider>();
        BoxGame.enabled = false;
        fTimer = 0.0f;
        GetGlass = GlassObject.GetComponent<GlassNum>();
	}
	
	// Update is called once per frame
	void Update () {
        fTimer += Time.deltaTime;

        if (fTimer >= 0.25f)
        {
            BoxGame.enabled = true;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            TweenAlpha.Begin(GlassObject, 0.2f, 1.0f);
            GlassObject.transform.localPosition = new Vector3(0, 0, -7);
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
    }
}
