using UnityEngine;
using System.Collections;

public class HMessagePopupBtn : MonoBehaviour {

	void Start () {
        Time.timeScale = 1;
	}
	
	void Update () {
	
	}

    void OnClick()
    {
        switch(transform.name)
        {
            case "Popup1Btn":
                HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup2Prefab");
                break;

            case "Popup2Btn":
                HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup3Prefab");
                break;

            case "Popup3Btn":
                HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup4Prefab");
                break;

            case "Popup4Btn":
                HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup5Prefab");
                //HPrefabMng.I.CreatePrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Scroll/CameraScrollPrefab");
                break;
        }
    }
}
