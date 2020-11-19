using UnityEngine;
using System.Collections;


/// <summary>
/// ��ġ : ���� PopupOffset_?  ���� ������Դϴ�
/// �뵵 : ȭ���ػ󵵿����� Scale���� �ڵ� �����մϴ�
/// </summary>
public class HAutoRatioScale : MonoBehaviour
{
    // ��׶��� ����� ���� Clipping ������ ����
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
