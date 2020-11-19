using UnityEngine;
using System.Collections;
using System;

public class PointClick : MonoBehaviour {
    PointSingleTon SingleTon;
    public PointStateMng StateChange;
    public GameObject PointGame;
    public AudioClip FailAudio;

	// Use this for initialization
	void Start () {
        SingleTon = PointSingleTon.I;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        if (StateChange.nKeyStatesArrary[(int)E_POINT_KEY_STATE.E_PN_KEY_ON] == 0)
        {
            if (int.Parse(PointGame.tag) == SingleTon.nCheckTag)
            {
                StateChange.PointOnState();
                SingleTon.nCheckTag++;
            }

            else if (int.Parse(PointGame.tag) != SingleTon.nCheckTag)
            {
                AudioSource.PlayClipAtPoint(FailAudio, transform.position);
                SingleTon.bisFail = true;
            }
        }
    }
}
