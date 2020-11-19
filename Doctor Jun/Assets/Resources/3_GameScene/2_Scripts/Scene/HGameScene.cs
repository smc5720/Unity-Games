using UnityEngine;
using System.Collections;

/// <summary>
/// À§Ä¡ :  SceneMng
/// </summary>  
public class HGameScene : HState 
{
    public UILabel InfoLabel = null;

    public override void Enter()
    {
        HPrefabMng.I.CreatePrefab("PanelScroll(Bar)PrefabOffset", E_H_RESOURCELOAD.E_1_LogoScene, "HNextSceneBtnPrefab", -1.0f, "", "HNextSceneBtn");
    }

    public override void Execute(float fDt)
    {
        //Debug.Log("in HGameScene");
    }

    public override void Exit()
    {

        HPrefabMng.I.DestroyPrefab("CharacterPrefab(Clone)");
    }
}
