using UnityEngine;
using System.Collections;


/// <summary>
/// 위치 : 여러 PopupOffset_?  에서 사용중입니다
/// 용도 : 화면해상도에따라 Scale값을 자동 조절합니다
/// </summary>
public class HAutoRatioScale : MonoBehaviour
{
    // 백그라운드 사이즈에 맞춰 Clipping 사이즈 조정
    public GameObject BackGroundGam = null;
    public UIPanel Panel = null;
    public UICenterOnChild OnChild = null;
    //public SpringPanel SPanel = null;
    public UIGrid Grid = null;
    public UIScrollBar ScrollBar = null;

    void Awake()
    {
        //HConfigMng.I.SetRadtio();
        //transform.localScale = HConfigMng.I.RatioScaleVec;

        if(BackGroundGam)
        {
            Vector4 Vec4 = new Vector4( Panel.clipRange.x, 
                                        Panel.clipRange.y, 
                                        (transform.localScale.x * BackGroundGam.transform.localScale.x)-20, 
                                        (transform.localScale.y * BackGroundGam.transform.localScale.y) );

            //float fXPos = (transform.localScale.x * BackGroundGam.transform.localScale.x) - 50;

            //Debug.Log(fXPos + "<-----------");

            //transform.localPosition = new Vector3(-fXPos/2.0f, 0.0f, 0.0f);

            //ScrollBar.scrollValue = 0.0f;
            

            Panel.clipRange = Vec4;
            //Grid.enabled = false;

            //SPanel.target = new Vector3(0.0f, 0.0f, 0.0f);
            //SPanel.enabled = true;

            OnChild.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
