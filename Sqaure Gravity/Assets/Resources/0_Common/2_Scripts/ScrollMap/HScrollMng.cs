using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// ��ũ�� �޴���
/// ��ġ : �� ��ũ�� �׷� ��
/// </summary>
public class HScrollMng : MonoBehaviour {

    /// <summary>
    /// ��ũ�� ��Ʈ�� Ŭ����
    /// </summary>
    public List<HScrollControl> ScrolCtrllList;

    /// <summary>
    /// ��ũ�� ��ü �ӵ�
    /// </summary>
    public Vector2 ScrollSpeedVec2 = new Vector2(1.0f, 0.0f);

    /// <summary>
    /// ��ũ�� ��ü �ӵ� ���� �ӽ� ����
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
    /// ��ũ�� ��� �Լ�
    /// </summary>
    /// <param name="bCalcEnable">��� On/off</param>
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
    /// ��ũ�� ��Ű�� �Լ�(��ũ�� ���͸� �־��ּ���^
    /// </summary>
    /// <param name="ScrollVec">��ũ�Ѻ���</param>
    public void DoScroll(Vector2 ScrollVec)
    {        
        ScrollSpeedVec2 = ScrollVec;
    }

    //public void DoScrollVec
}
