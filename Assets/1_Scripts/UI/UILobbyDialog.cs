using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobbyDialog : UIDialog
{
    public Button btnStart;

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnStart, OnClick_Start);
    }

    public void OnClick_Start()
    {
        UIManager.Instance.fadeDialog.FadeIn(() => SceneManager.Instance.fsm.SetState(eSCENE_STATE.BATTLE));
    }

}
