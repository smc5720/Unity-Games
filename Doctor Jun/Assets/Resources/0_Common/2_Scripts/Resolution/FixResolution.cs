using UnityEngine;
using System.Collections;


/// <summary>
/// ver 1.0  / date 14.04.01
/// </summary>
/// 
public class FixResolution : MonoBehaviour 
{
    public Camera _Camera;

    private int Width;
    private int Height;

    private int RatioWidth;
    private int RatioHeight;

    private int CurScreenRatioHeight;

    private int FixWidth;
    private int FixHeight;

	void Start()
    {
        Width = SetResolution.I.Width;
        Height = SetResolution.I.Height;
        RatioWidth = SetResolution.I.RatioWidth;
        RatioHeight = SetResolution.I.RatioHeight;

        //Width = 800;
        //Height = 400;
        //RatioWidth = 5;
        //RatioHeight = 3;

        UIRoot root = GetComponent<UIRoot>();

        if (root != null)
        {
            root.manualHeight = Height;
            root.minimumHeight = Height;
            root.maximumHeight = Height;
        }

        CurScreenRatioHeight = (Screen.width / RatioWidth) * RatioHeight;


        if (Screen.height > CurScreenRatioHeight)
        {
            int A = Screen.height - CurScreenRatioHeight;
            FixWidth = Screen.width - ((A / RatioHeight) * RatioWidth);
            FixHeight = CurScreenRatioHeight;

            if (Screen.width > FixWidth
                && Screen.height > Height)
            {
                //float perx = (float)Screen.width / (float)Width;
                //float pery = (float)Screen.height / (float)Height;
                //float v = (perx < pery) ? perx : pery;
                //_Camera.orthographicSize = v;
                //if (_Camera.GetComponent<UIViewport>() != null)
                //{
                //    _Camera.GetComponent<UIViewport>().fullSize = v;
                //}
                float perx = (float)FixWidth / (float)Screen.width;
                float pery = (float)FixHeight / (float)Screen.height;
                float v = (perx < pery) ? perx : pery;
                _Camera.orthographicSize = 1.0f + (1.0f - v);
                if (_Camera.GetComponent<UIViewport>() != null)
                {
                    _Camera.GetComponent<UIViewport>().fullSize = 1.0f + (1.0f - v);
                }
            }
        }
        else if (Screen.height < CurScreenRatioHeight)
        {
            int A = CurScreenRatioHeight - Screen.height;
            FixWidth = Screen.width + ((A / RatioHeight) * RatioWidth);
            FixHeight = CurScreenRatioHeight;

            if (Screen.width < FixWidth)
            {
                float perx = (float)FixWidth / (float)Screen.width;
                float pery = (float)FixHeight / (float)Screen.height;
                float v = (perx < pery) ? perx : pery;
                _Camera.orthographicSize = 1.0f + (1.0f - v);
                if (_Camera.GetComponent<UIViewport>() != null)
                {
                    _Camera.GetComponent<UIViewport>().fullSize = 1.0f + (1.0f - v);
                }
            }
        }
        else if (Screen.height == CurScreenRatioHeight)
        {
            FixWidth = Width;
            FixHeight = Height;
        }
        else
        {

        }

        //Debug.Log("Application Screen Resolution : " + Screen.width + " " + Screen.height);
        //Debug.Log("Fix Screen Resolution : " + FixWidth + " " + FixHeight);
	}
}