using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmClass<T> where T : System.Enum
{
    protected Dictionary<T, FsmState<T>> m_stateList = new Dictionary<T, FsmState<T>>(); //상태에 따른 FsmState
    protected FsmState<T> m_state; //현재 상태

    protected bool m_isStateChangeing = false; //상태변경 가능한지
    

    public FsmState<T> getStste { get { return m_state; } }
    public T getStateType
    {
        get
        {
            if (m_state == null)
                return default(T);

            return m_state.stateType;
        }
    }

    public virtual void Init()
    {

    }

    public virtual void Clear()
    {
        m_stateList.Clear();
        m_state = null;
    }

    public virtual void AddFsm(FsmState<T> _state)
    {
        if(_state == null)
            return;

        if (m_stateList.ContainsKey(_state.stateType))//이미 등록된
            return;

        m_stateList.Add(_state.stateType, _state);
    }

    public virtual void SetState(T _stateType, FsmMsg _msg = null)
    {
        if (!m_stateList.ContainsKey(_stateType))
            return;

        if (m_isStateChangeing) //상태 변경중일때
            return;

        FsmState<T> _nextState = m_stateList[_stateType];
        if(_nextState == m_state) //같은 상태 일때
        {
            return;
        }

        m_isStateChangeing = true;
        if (m_state != null)
            m_state.End();

        m_state = _nextState;
        m_state.Enter(_msg);
        m_isStateChangeing = false;
     }

    public virtual void SetMsg(FsmMsg _msg)
    {
        if (m_state == null)
            return;
        if (_msg == null)
            return;
        m_state.SetMsg(_msg);

    }

    public virtual void Update()
    {
        if (m_state == null)
            return;

        m_state.Update();
    }


} 

