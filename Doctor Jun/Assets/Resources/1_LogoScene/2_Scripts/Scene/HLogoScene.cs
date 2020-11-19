using UnityEngine;
using System.Collections;

/// <summary>
/// À§Ä¡ :  SceneMng
/// </summary>
public class HLogoScene : HState 
{
    UILabel InfoLabel = null;

    public override void Enter()
    {
        //HPrefabMng.I.CreatePrefab("Etc", E_H_RESOURCELOAD.E_1_LogoScene, "HNextSceneBtnPrefab", -1.0f, "", "HNextSceneBtn");        
    }

    public override void Execute(float fDt)
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Popup/NormalPopup1Prefab");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Popup/NormalPopup2Prefab");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Popup/NormalPopup3Prefab");
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Popup/NormalPopup4Prefab");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            HPrefabMng.I.CreatePopupPrefab("PopupOffset", E_H_RESOURCELOAD.E_1_LogoScene, "Popup/ScrollPopupPrefab");
        }
    }

    public override void Exit()
    {
        HPrefabMng.I.DestroyPrefab("HNextSceneBtnPrefab(Clone)");
    }
}
