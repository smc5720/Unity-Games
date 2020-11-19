using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{

    public UISprite Back;
    public bool State;
    // Use this for initialization
    void Start()
    {
        State = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == true)
            Back.color += new Color(0, 0, 0, 5);
        else
            Back.color -= new Color(0, 0, 0, 5);
    }
}
