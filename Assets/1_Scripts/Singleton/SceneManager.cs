using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    public FsmClass<eSCENE_STATE> fsm = new FsmClass<eSCENE_STATE>();

    public void Init()
    {
        fsm.AddFsm(new SceneState_Intro(this));
        fsm.AddFsm(new SceneState_Lobby(this));
        fsm.AddFsm(new SceneState_Battle(this));
    }

    private void Update()
    {
        fsm.Update();
    }
}
