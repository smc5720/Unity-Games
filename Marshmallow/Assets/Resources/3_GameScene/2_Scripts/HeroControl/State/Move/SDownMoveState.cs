using UnityEngine;
using System.Collections;

/// <summary>
/// 캐릭터 아래쪽 이동상태
/// </summary>
public class SDownMoveState : HState
{
    public GameObject JoyStickGame;
    UIJoystick vJoy;
    public override void Enter()
    {
        vJoy = JoyStickGame.GetComponent<UIJoystick>();
    }

    public override void Execute(float fDt)
    {
        if (vJoy.position.x != 0 || vJoy.position.y != 0)
        {
            HeroStateMng.I.fcharx = vJoy.position.x;
            HeroStateMng.I.fchary = vJoy.position.y;
        }
    }

    public override void Exit()
    {

    }
}
