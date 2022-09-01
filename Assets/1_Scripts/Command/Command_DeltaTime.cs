using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_DeltaTime : ICommand
{
    UnityEngine.Events.UnityAction m_delegate;
    float m_maxTime;
    float m_tiem;
    bool m_isComplete;

    public Command_DeltaTime(float _maxTime, UnityEngine.Events.UnityAction _delegate)
    {
        m_delegate = _delegate;
        m_maxTime = _maxTime;
    }

    public void Execute()
    {
        m_tiem = 0.0f;
        m_isComplete = false;
    }

    public void Update()
    {
        if (m_isComplete)
            return;

        m_tiem += Time.deltaTime;
        if(m_tiem >= m_maxTime)
        {
            if (m_delegate != null)
                m_delegate();

            m_isComplete = true;
        }

    }
    public void Cancel()
    {
       
    }

    public bool IsFinished()
    {
        return m_isComplete;
    }

 
}
