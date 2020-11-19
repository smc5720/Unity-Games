using UnityEngine;
using System.Collections;

public class ChangeItem : MonoBehaviour {
    
    GameObject Map;
    GameObject BlockMng;
    BlockShuffle Commend;
    MapTrans ChangeFunc;

	// Use this for initialization
	void Start () {
        Map = GameObject.Find("MapObject");
        BlockMng = GameObject.Find("ResetButton");
        ChangeFunc = Map.GetComponent<MapTrans>();
        Commend = BlockMng.GetComponent<BlockShuffle>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            ChangeFunc.ShuffleMap();
            Commend.ResetPos2();
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
    }
}
