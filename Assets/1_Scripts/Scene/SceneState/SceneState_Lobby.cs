using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState_Lobby : SceneState
{
    public SceneState_Lobby(SceneManager _sceneManager) : base(_sceneManager, eSCENE_STATE.LOBBY)
    {

    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        UIManager.Instance.Clear();
        UIManager.Instance.fadeDialog.FadeOut(null);
        UIManager.Instance.dialog.OpenDialog("UI/UILobby/UILobbyDialog");
    }

    public override void Update()
    {
        base.Update();

     
    }

    public override void End()
    {
        base.End();
       
    }
}
