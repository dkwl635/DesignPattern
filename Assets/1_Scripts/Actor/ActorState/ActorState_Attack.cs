using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_Attack : ActorState
{
  public ActorState_Attack(Actor _owner) : base (_owner, eACTOR_STATE.ATTACK)
    {

    }

    public override void Update()
    {
        base.Update();
        m_owner.fsm.SetState(eACTOR_STATE.ATTACK_END);
    }
}
