using UnityEngine;
using System.Collections;

public class HPBarChase : MonoBehaviour
{
    public GameObject HeroGame;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(HeroGame.transform.localPosition.x - 30, HeroGame.transform.localPosition.y - 30, -1.0f);
    }
}