using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBase
{
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

    public virtual void Open(ActorData _data, Vector3 _pos, Quaternion _rot)
    {
        base.Open();
        SetPos(_pos);
        SetRot(_rot);
        data = _data;
        data.Open(this);
        mover.Open();
        attack.Open();
        fsm.SetState(eACTOR_STATE.IDLE);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        fsm.Update();
        mover.Update();
    }
}
