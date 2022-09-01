using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_FadeDialog : ICommand
{
    UIFadeDialog.eSTATE m_state;
    UnityEngine.Events.UnityAction m_complete;
    float m_duration;
    bool m_isComplete;

    public Command_FadeDialog(UIFadeDialog.eSTATE _state, UnityEngine.Events.UnityAction _complete, float _duration = 0.8f)
    {
        m_state = _state;
        m_complete = _complete;
        m_duration = _duration;
    }

    public void Execute()
    {
        m_isComplete = false;
        UIManager.Instance.fadeDialog.Open(m_state, OnComplate, m_duration);

    }

    void OnComplate()
    {
        if (m_complete != null)
            m_complete();
        m_isComplete = true;
    }
    public void Update()
    {

    }

    public void Cancel()
    {

    }

    public bool IsFinished()
    {
        return m_isComplete;
    }
}
