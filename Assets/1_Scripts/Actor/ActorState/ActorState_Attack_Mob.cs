using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_Attack_Mob : ActorState
{
   public ActorState_Attack_Mob(Actor owner) : base (owner, eACTOR_STATE.ATTACK)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        GamePlayLogic_Battle.Instance.playData.AddHp(-(int)m_owner.data.GetStatValue(eSTAT_TYPE.ATK));
        m_owner.Close();
    }
    public override void End()
    {
        base.End();
    }

}
