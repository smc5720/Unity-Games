using UnityEngine;
using System.Collections;

/// <summary>
/// À§Ä¡ :  SceneMng
/// </summary>  
public class HMenuScene : HState 
{

    public UILabel InfoLabel = null;

    public override void Enter()
    {
        //HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_1_LogoScene, "HNextSceneBtnPrefab", -1.0f, "", "MessagePopupBtn");
    }

    public override void Execute(float fDt)
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup2Prefab");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup3Prefab");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup4Prefab");
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_2_MenuScene, "HMessagePopup5Prefab");
        }
    }

    public override void Exit()
    {
        //HPrefabMng.I.DestroyPrefab("HNextSceneBtnPrefab(Clone)");        
    }
}
