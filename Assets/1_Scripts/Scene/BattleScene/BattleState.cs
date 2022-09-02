using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBATTLE_STATE
{ 
    READY,
    PLAY,
    PAUSE,
    RESULT,
}

public class BattleState : FsmState<eBATTLE_STATE>
{
    protected GamePlayLogic_Battle m_logic;

    public BattleState(GamePlayLogic_Battle _logic, eBATTLE_STATE _state) : base (_state)
    {
        m_logic = _logic;
    }

}
