using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState_Play : BattleState
{
    public BattleState_Play(GamePlayLogic_Battle _logic) : base(_logic, eBATTLE_STATE.PLAY)
    {
    }

    public override void Update()
    {
        base.Update();
        m_logic.monsterSpawn.Update();
        ActorManager.Instance.UpdateLogic();
    }

}
