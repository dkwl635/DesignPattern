using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState_Battle : SceneState
{
  public SceneState_Battle(SceneManager sceneManager) : base(sceneManager , eSCENE_STATE.BATTLE)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        UIManager.Instance.Clear();
        GamePlayLogic_Battle _Battle = GamePlayManager.Instance.CreateGamePlayLogic<GamePlayLogic_Battle>();
        _Battle.fsm.SetState(eBATTLE_STATE.READY);
    }

    public override void End()
    {
        base.End();
        GamePlayManager.Instance.SetGamePlayLogic(null);
    }
}
