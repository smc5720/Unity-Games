using UnityEngine;
using System.Collections;

public class SWaveCheck : MonoBehaviour
{
    public UILabel WaveLabel;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        WaveLabel.GetComponent<UILabel>().text = "Wave " + HeroStateMng.I.nWaveNum.ToString();
    }
}