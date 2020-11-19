using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour 
{
    private static SetResolution m_Instance = null;

    public static SetResolution I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(SetResolution)) as SetResolution;

                if (null == m_Instance)
                {
                    Debug.Log("SetResolution Mng Fail to get Manager Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public int Width;
    public int Height;

    public int RatioWidth;
    public int RatioHeight;
}
