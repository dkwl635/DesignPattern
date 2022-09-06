using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBase
{
    static public bool IsFife(Actor _owner)
    {
        if (_owner == null)
            return false;
        if (_owner.isOpen == false)
            return false;
        if (_owner.fsm.getStateType == eACTOR_STATE.DIE)
            return false;

        return true;
    }

    public Transform center;
    public Transform dummy_attack;

    public FsmClass<eACTOR_STATE> fsm;
    public ActorData data;
    public ActorMover mover;
    public ActorAttack attack;

 

    public override void Init()
    {
        base.Init();
        mover = new ActorMover(this);
        attack = new ActorAttack(this);
        fsm = new FsmClass<eACTOR_STATE>();
        fsm.AddFsm(new ActorState_Idle_Mob(this));
        fsm.AddFsm(new ActorSTATe_Die(this));
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    
    public void SetRot(Quaternion rot)
    {
        transform.localRotation = rot;
    }

    public Vector3 getPos { get { return transform.position; } }
    public Quaternion getRot { get { return transform.localRotation;      } }

    public virtual void Open(ActorData _data, ActorFactoryCreator _creator, Vector3 _pos, Quaternion _rot)
    {
        base.Open();
        SetPos(_pos);
        SetRot(_rot);
        data = _data;
        data.Open(this);
        mover.Open();
        attack.Open();
        fsm = _creator.CreateFsm(this);
        fsm.SetState(eACTOR_STATE.IDLE);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        mover.Update();
        attack.Update();
        fsm.Update();
      
    }
}
