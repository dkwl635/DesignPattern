using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobbyDialog : UIDialog
{
    public Button btnStart;
    public Button btnUpgrade;
    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnStart, OnClick_Start);
        KUtil.UIUtil.SetBtnClick(btnUpgrade, OnClick_Upgrade);
    }

    public void OnClick_Start()
    {
        UIManager.Instance.fadeDialog.FadeIn(() => SceneManager.Instance.fsm.SetState(eSCENE_STATE.BATTLE));
        Close();
    }

    public void OnClick_Upgrade()
    {
        UIManager.Instance.dialog.OpenDialog("UI/UILobby/UIUpgradeDialog");
    }
}
