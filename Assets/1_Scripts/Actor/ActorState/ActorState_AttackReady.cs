using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_AttackReady : ActorState
{
   public ActorState_AttackReady(Actor _owner) : base (_owner ,eACTOR_STATE.ATTACK_READY)
    {

    }

    public override void Update()
    {
        base.Update();
        Actor target = m_owner.attack.getTarget;
        if(Actor.IsFife(target) == false)
        {
            m_owner.fsm.SetState(eACTOR_STATE.IDLE);
            return;
        }

        Vector3 dir = target.getPos - m_owner.getPos;
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        m_owner.center.rotation = rot;
        m_owner.fsm.SetState(eACTOR_STATE.ATTACK);
    }

}
