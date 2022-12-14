using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState_Die_Mob : ActorState
{
   public ActorState_Die_Mob(Actor owner) : base(owner, eACTOR_STATE.DIE)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        GamePlayLogic_Battle.Instance.playData.AddBattleCoin((int)m_owner.data.GetStatValue(eSTAT_TYPE.REWARD_BATTLE_COIN));
        GamePlayLogic_Battle.Instance.playData.AddScore(1);
        m_owner.Close();
    }

}
