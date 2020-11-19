using UnityEngine;
using System.Collections;

public class UpCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "JoyStick")
        {
            HeroStateMng.I.UpBtnPress();
        }
    }

    void OnTriggerExit(Collider col)
    {
        HeroStateMng.I.UpBtnRelease();
        HeroStateMng.I.Hero2dAniSprite.gameObject.rigidbody.velocity = new Vector3(0, 0, 0);
    }
}
