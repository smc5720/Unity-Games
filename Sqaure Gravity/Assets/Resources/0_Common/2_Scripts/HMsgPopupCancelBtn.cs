using UnityEngine;
using System.Collections;

/// <summary>
/// À§Ä¡ : MessagePopupPrefab/CancelBtn
/// </summary>
public class HMsgPopupCancelBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        HPrefabMng.I.DestroyPrefab(transform.parent.transform.parent.transform.parent.name);
    }

    void OnDestory()
    {
        
    }
}
