using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState<T> where T : System.Enum
{
    protected T m_ststeType;
    public T stateType { get { return m_ststeType; } }
    public FsmState(T _stateType)
    {
        m_ststeType = _stateType;
    }

    public virtual void Enter(FsmMsg _msg)//���°� ����ɶ� ȣ��Ǵ� �Լ�
    {

    }

    public virtual void Update() //���¿� ���� ������Ʈ �Լ�
    {

    }

    public virtual void End()//���°� ���� �ɶ� ȣ��Ǵ� �Լ�
    {

    }

    public virtual void SetMsg(FsmMsg msg) //���� �����϶� ó���ϴ� �Լ�
    {
    }
}
