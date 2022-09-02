using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleDialog : UIDialog
{
    public Button btnPause;

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnPause, OnClick_Pause);
    }

    public void OnClick_Pause()
    {
        GamePlayLogic_Battle.Instance.fsm.SetState(eBATTLE_STATE.PAUSE);
    }

}
