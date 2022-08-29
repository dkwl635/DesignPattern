using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState_Intro : SceneState
{
    float m_time = 0.0f;

    public SceneState_Intro(SceneManager _sceneManager) : base(_sceneManager, eSCENE_STATE.INTRO)
    {
        
    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        Debug.Log(m_ststeType.ToString());

    }

    public override void Update()
    {
        base.Update();
        m_time += Time.deltaTime;
        if(m_time >= 1.0f)
        {
           m_sceneManager.fsm.SetState(eSCENE_STATE.LOBBY);
        }
    }

}