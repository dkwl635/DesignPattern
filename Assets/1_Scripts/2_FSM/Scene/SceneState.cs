using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSCENE_STATE
{
    INTRO,
    LOBBY,
    BATTLE,
}

public class SceneState : FsmState<eSCENE_STATE>
{
    protected SceneManager m_sceneManager;
    public SceneState(SceneManager _sceneManager, eSCENE_STATE _stateType) : base(_stateType)
    {
        m_sceneManager = _sceneManager;
    }
}

    

