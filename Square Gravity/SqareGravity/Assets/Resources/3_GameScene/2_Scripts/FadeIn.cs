using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public UISprite Back;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Back.color -= new Color(0, 0, 0, 2);
    }
}
