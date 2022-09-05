using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eACTOR_STATE
{
    NONE,
    IDLE,
    DIE,
}

public class ActorState : FsmState<eACTOR_STATE>
{
    protected Actor m_owner;
    public ActorState(Actor _owner, eACTOR_STATE _state) : base(_state)
    {
        m_owner = _owner;       
    }
        

}
