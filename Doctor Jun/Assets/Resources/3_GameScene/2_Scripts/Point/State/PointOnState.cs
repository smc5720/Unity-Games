using UnityEngine;
using System.Collections;

public class PointOnState : HState {
    public AudioClip RedAudio;
    public AudioClip ClearAudio;
    public GameObject BackGroundGame;
    public GameObject PointGame;
    UISprite BackGroundSprite;
    public PointStateMng StateChange;
    PointSingleTon SingleTon;
    float fTimer;
    public override void Enter()
    {
        BackGroundSprite = BackGroundGame.GetComponent<UISprite>();
        BackGroundSprite.spriteName = "Red";
        SingleTon = PointSingleTon.I;
        AudioSource.PlayClipAtPoint(RedAudio, transform.position);
        fTimer = 0.0f;
    }

    public override void Execute(float fDt)
    {
        if (SingleTon.nCheckTag == (SingleTon.nLevel + 1))
        {
            if (SingleTon.bisClear == false)
            {
                AudioSource.PlayClipAtPoint(ClearAudio, transform.position);
            }

            SingleTon.bisClear = true;
            fTimer += Time.deltaTime;

            if (fTimer >= 1.0f)
            {
                SingleTon.nCheckTag = 13;
            }
        }

        //if (SingleTon.bisClear == true)
        //{
        //    StateChange.PointOffState();
        //    Debug.Log(gameObject.name + "is backDancing");
        //}
    }

    public override void Exit()
    {
        
    }
}