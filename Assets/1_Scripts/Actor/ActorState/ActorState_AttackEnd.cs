using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_AttackEnd : ActorState
{
 public ActorState_AttackEnd(Actor owner ): base(owner,eACTOR_STATE.ATTACK_END)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        m_owner.attack.SetTarget(null);
        m_owner.attack.setAtkTime(0.0f);
    }

    public override void Update()
    {
        base.Update();
        m_owner.fsm.SetState(eACTOR_STATE.IDLE);
    }


}


