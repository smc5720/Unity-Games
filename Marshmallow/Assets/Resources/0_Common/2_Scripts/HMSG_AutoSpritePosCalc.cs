using UnityEngine;
using System.Collections;


public enum E_H_POS
{
    E_LEFT_TOP,
    E_RIGHT_TOP,
    E_LEFT_BOTTOM,
    E_RIGHT_BOTTOM
}

/// <summary>
/// À§Ä¡ : Sprite0~5
/// </summary>
public class HMSG_AutoSpritePosCalc : MonoBehaviour {

    public GameObject RankingLayoutGam = null;

    public E_H_POS e_hPos = E_H_POS.E_LEFT_TOP;

	// Use this for initialization
	void Start () 
    {
        //RankingLayoutGam = transform.parent.gameObject;
        UpdateSpritePos();
	}
	
	// Update is called once per frame
	void Update () 
    {
                	    
	}

    void UpdateSpritePos()
    {
        Vector3 LayOutScale = RankingLayoutGam.transform.localScale;
        
        Vector3 CalcLayOUtPos = new Vector3(LayOutScale.x/2.0f, LayOutScale.y/2.0f, 1.0f);

        Vector3 RankingLayoutPos = RankingLayoutGam.transform.localPosition;

        CalcLayOUtPos = new Vector3(CalcLayOUtPos.x -15.0f, CalcLayOUtPos.y - 15.0f, CalcLayOUtPos.z);

        switch (e_hPos)
        {
            case E_H_POS.E_LEFT_TOP:
                transform.localPosition = new Vector3(-CalcLayOUtPos.x, CalcLayOUtPos.y, RankingLayoutPos.z);
                break;

            case E_H_POS.E_LEFT_BOTTOM:
                transform.localPosition = new Vector3(-CalcLayOUtPos.x, -CalcLayOUtPos.y, RankingLayoutPos.z);
                break;

            case E_H_POS.E_RIGHT_TOP:
                transform.localPosition = new Vector3(CalcLayOUtPos.x, CalcLayOUtPos.y, RankingLayoutPos.z);
                break;

            case E_H_POS.E_RIGHT_BOTTOM:
                transform.localPosition = new Vector3(CalcLayOUtPos.x, -CalcLayOUtPos.y, RankingLayoutPos.z);
                break;
        }
    }
}
