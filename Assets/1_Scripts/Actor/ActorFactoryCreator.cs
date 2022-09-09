using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class ActorFactoryCreator 
{
    public abstract FsmClass<eACTOR_STATE> CreateFsm(Actor owner);
}


public class ActorFactorCreator_Monster : ActorFactoryCreator
{
    public override FsmClass<eACTOR_STATE> CreateFsm(Actor owner)
    {
        FsmClass<eACTOR_STATE> _fsm = new FsmClass<eACTOR_STATE>();
        _fsm.AddFsm(new ActorState_Idle_Mob(owner));
        _fsm.AddFsm(new ActorState_Die_Mob(owner));
        _fsm.AddFsm(new ActorState_Attack_Mob(owner));

        return _fsm;
    }
}


public class ActorFactoryCreator_Tower : ActorFactoryCreator
{
    public override FsmClass<eACTOR_STATE> CreateFsm(Actor owner)
    {
        FsmClass<eACTOR_STATE> _fsm = new FsmClass<eACTOR_STATE>();
        _fsm.AddFsm(new ActorState_Idle_Tower(owner));
        _fsm.AddFsm(new ActorState_Attack(owner));
        _fsm.AddFsm(new ActorState_AttackReady(owner));
        _fsm.AddFsm(new ActorState_AttackEnd(owner));
        _fsm.AddFsm(new ActorSTATe_Die(owner));

        return _fsm;
    }
}
