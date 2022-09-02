using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleResultDialog : UIDialog
{
    public Button btnToLobby;

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnToLobby, OnClick_ToLobby);
    }

    public void OnClick_ToLobby()
    {
        UIManager.Instance.fadeDialog.FadeIn(() => SceneManager.Instance.fsm.SetState(eSCENE_STATE.LOBBY));
    }
    

}
