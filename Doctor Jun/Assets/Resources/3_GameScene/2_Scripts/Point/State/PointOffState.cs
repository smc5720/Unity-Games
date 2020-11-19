using UnityEngine;
using System.Collections;

public class PointOffState : HState {
    public GameObject BackGroundGame;
    public GameObject PointGame;
    UISprite BackGroundSprite;
    PointSingleTon SingleTon;
    public PointStateMng StateChange;
    float fTimer;
    public override void Enter()
    {
        BackGroundSprite = BackGroundGame.GetComponent<UISprite>();
        BackGroundSprite.spriteName = "White";
        SingleTon = PointSingleTon.I;
        fTimer = 0.0f;
    }

    public override void Execute(float fDt)
    {
        if (SingleTon.bPointStart == true && StateChange.bisTurned == false)
        {
            if (int.Parse(PointGame.tag) <= SingleTon.nLevel)
            {
                fTimer += Time.deltaTime;
                if ((int.Parse(PointGame.tag) * SingleTon.fPointTimer) <= fTimer)
                {
                    Debug.Log(PointGame.name + ": " + PointGame.tag + ", " + StateChange.name);
                    StateChange.PointRememberState();
                    StateChange.bisTurned = true;
                }
            }
        }
    }

    public override void Exit()
    {

    }
}
