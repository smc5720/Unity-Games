using UnityEngine;
using System.Collections;

public class PointRememberState : HState {
    public AudioClip YellowAudio;
    public GameObject BackGroundGame;
    public GameObject PointGame;
    UISprite BackGroundSprite;
    float fTimer;
    PointSingleTon SingleTon;
    public PointStateMng StateChange;
    public override void Enter()
    {
        BackGroundSprite = BackGroundGame.GetComponent<UISprite>();
        BackGroundSprite.spriteName = "Yellow";
        fTimer = 0.0f;
        AudioSource.PlayClipAtPoint(YellowAudio, transform.position);
        SingleTon = PointSingleTon.I;
    }

    public override void Execute(float fDt)
    {
        fTimer += Time.deltaTime;
        if (fTimer >= SingleTon.fPointTimer)
        {
            if (PointGame.tag == SingleTon.nLevel.ToString())
            {
                SingleTon.bPointStart = false;
                SingleTon.bAnswerStart = true;
            }
            StateChange.PointOffState();
        }
    }

    public override void Exit()
    {

    }
}
