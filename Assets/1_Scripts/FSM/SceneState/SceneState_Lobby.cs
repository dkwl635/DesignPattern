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
        UIManager.Instance.fadeDialog.FadeOut(UIManager.Instance.fadeDialog.Close);
        UIManager.Instance.dialog.OpenDlg("UI/UILobby/UILobbyDialog");
    }
}
