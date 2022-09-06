using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eACTOR_STATE
{
    NONE,
    IDLE,
    DIE,
    ATTACK,
    ATTACK_READY,
    ATTACK_END,

}

public class ActorState : FsmState<eACTOR_STATE>
{
    protected Actor m_owner;
    public ActorState(Actor _owner, eACTOR_STATE _state) : base(_state)
    {
        m_owner = _owner;       
    }
        

}
