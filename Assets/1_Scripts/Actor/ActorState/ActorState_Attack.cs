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
        ActorManager.Instance.CreateMissile("Missile/missile_1", eTEAM.MONSTER, m_owner.data.getActorRecord.atk,
            m_owner.dummy_attack.position, m_owner.dummy_attack.rotation * Vector3.forward * 5.0f);
        m_owner.fsm.SetState(eACTOR_STATE.ATTACK_END);
    }
}
