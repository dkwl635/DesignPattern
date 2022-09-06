using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_Idle_Tower : ActorState
{
   public ActorState_Idle_Tower(Actor owner) : base (owner, eACTOR_STATE.IDLE)
    {

    }

    public override void Update()
    {
        base.Update();
        if (m_owner.attack.isAtkEnable == false)
            return;

        Actor target = ActorManager.Instance.FindNear(m_owner, eTEAM.MONSTER, m_owner.data.getActorRecord.atkDis);
        if (Actor.IsFife(target) == false)
            return;

        m_owner.attack.SetTarget(target);
        m_owner.fsm.SetState(eACTOR_STATE.ATTACK_READY);

    }

}
