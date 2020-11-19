using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 스크롤 메니져
/// 위치 : 각 스크롤 그룹 안
/// </summary>
public class HScrollMng : MonoBehaviour {

    /// <summary>
    /// 스크롤 컨트롤 클래스
    /// </summary>
    public List<HScrollControl> ScrolCtrllList;

    /// <summary>
    /// 스크롤 전체 속도
    /// </summary>
    public Vector2 ScrollSpeedVec2 = new Vector2(1.0f, 0.0f);

    /// <summary>
    /// 스크롤 전체 속도 제어 임시 변수
    /// </summary>
    private Vector2 ScrollSpeedTempVec2 = new Vector2(0.0f, 0.0f);


	// Use this for initialization
	void Start () 
    {
        if(ScrollSpeedVec2.x == 0.0f || ScrollSpeedVec2.y == 0.0f)
            UpdateScrollSpeed(true);
        else
            UpdateScrollSpeed(false);

        ScrollSpeedTempVec2 = ScrollSpeedVec2;
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateScrollSpeed(true);
	}   

    /// <summary>
    /// 스크를 계산 함수
    /// </summary>
    /// <param name="bCalcEnable">계산 On/off</param>
    void UpdateScrollSpeed(bool bCalcEnable)
    {
        if (ScrollSpeedVec2.x != ScrollSpeedTempVec2.x  ||
            ScrollSpeedVec2.y != ScrollSpeedTempVec2.y || bCalcEnable == true)
        {
            foreach (HScrollControl Scroll in ScrolCtrllList)
            {
                Scroll.fMngScrollSpeedVec2 = ScrollSpeedVec2;
            }

            ScrollSpeedTempVec2 = ScrollSpeedVec2;
        }
    }

    /// <summary>
    /// 스크롤 시키는 함수(스크롤 벡터를 넣어주세요^
    /// </summary>
    /// <param name="ScrollVec">스크롤벡터</param>
    public void DoScroll(Vector2 ScrollVec)
    {        
        ScrollSpeedVec2 = ScrollVec;
    }

    //public void DoScrollVec
}
