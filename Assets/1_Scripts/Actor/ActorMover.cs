using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActorMover 
{
    protected Actor m_owner;
    [SerializeField] protected bool m_isStop;
    [SerializeField] protected Vector3 m_target;
    public bool isStop { get { return m_isStop; } }
    public ActorMover(Actor owner)
    {
        m_owner = owner;
    }

    public virtual void Stop()
    {
        m_isStop = true;
    }

    public virtual void Open()
    {
        Stop();
    }

    public virtual bool Move(Vector3 _target)
    {
        m_isStop = false;
        m_target = _target;
        return true;
    }

    public void SetRotate(Vector3 dir)
    {
        if (dir.x == 0.0f && dir.y == 0.0f && dir.z == 0.0f)
            return;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        m_owner.SetRot(Quaternion.Lerp(m_owner.getRot, rot, Time.deltaTime * 10.0f));
       
    }

    public virtual void Update()
    {
        if (m_isStop)
            return;

        float speed = Time.deltaTime * m_owner.data.GetStatValue(eSTAT_TYPE.MOVE_SPEED);
        Vector3 movement = m_target - m_owner.getPos;
        SetRotate(movement);
        if(speed < movement.magnitude)
        {
            m_owner.SetPos(m_owner.getPos + movement.normalized * speed);
        }
        else 
        {
            m_owner.SetPos(m_target);
            Stop();
        }


    }


}
