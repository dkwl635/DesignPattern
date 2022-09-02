using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLogic_Battle : GamePlayLogic
{
    public static GamePlayLogic_Battle Instance { get { return GamePlayManager.Instance.GetGamePlayLogic<GamePlayLogic_Battle>(); } }

    public FsmClass<eBATTLE_STATE> fsm = new FsmClass<eBATTLE_STATE>();

    public override void Init()
    {
        base.Init();

        fsm.Clear();
        fsm.AddFsm(new BattleState_Ready(this));
        fsm.AddFsm(new BattleState_Play(this));
        fsm.AddFsm(new BattleState_Pause(this));
        fsm.AddFsm(new BattleState_Result(this));
        

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        fsm.Update();
    }

}

