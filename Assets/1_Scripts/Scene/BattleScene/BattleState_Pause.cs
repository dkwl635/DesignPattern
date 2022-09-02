using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState_Pause : BattleState
{
    public BattleState_Pause(GamePlayLogic_Battle _logic) : base(_logic, eBATTLE_STATE.PAUSE)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        UIManager.Instance.dialog.OpenDialog("UI/UIBattle/UIBattlePauseDialog");
    }
}
