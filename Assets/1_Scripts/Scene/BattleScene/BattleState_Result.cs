using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState_Result : BattleState
{
    public BattleState_Result (GamePlayLogic_Battle _logic):base(_logic,eBATTLE_STATE.RESULT)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
   
    }

}
