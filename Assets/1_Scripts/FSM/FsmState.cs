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

    public virtual void Enter(FsmMsg _msg)//상태가 변경될때 호출되는 함수
    {

    }

    public virtual void Update() //상태에 따른 업데이트 함수
    {

    }

    public virtual void End()//상태가 종료 될때 호출되는 함수
    {

    }

    public virtual void SetMsg(FsmMsg msg) //현재 상태일때 처리하는 함수
    {
    }
}
