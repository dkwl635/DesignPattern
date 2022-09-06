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
        if (m_logic.playData.hp <= 0)
        {
            m_logic.playData.SetBattleResult(eBATTLE_RESULT.FAILED);
            m_logic.fsm.SetState(eBATTLE_STATE.RESULT);
            return; 
        }

        m_logic.monsterSpawn.Update();
        ActorManager.Instance.UpdateLogic();
    }

}
