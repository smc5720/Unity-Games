using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour
{
    UILabel Lable;
    // Use this for initialization
    void Start()
    {
        Lable = GameObject.Find("Label").GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        Lable.text = PlayerPrefs.GetInt("HighScore").ToString();

    }
}
