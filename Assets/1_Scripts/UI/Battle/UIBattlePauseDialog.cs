using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattlePauseDialog : UIDialog
{

    public Button btnExit;

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnExit, OnClick_Exit);
    }

    public void OnClick_Exit()
    {
        Close();
        GamePlayLogic_Battle.Instance.playData.SetBattleResult(eBATTLE_RESULT.FAILED);
        GamePlayLogic_Battle.Instance.fsm.SetState(eBATTLE_STATE.RESULT);
    }

    public override void OnClick_Close()
    {
        base.OnClick_Close();
        GamePlayLogic_Battle.Instance.fsm.SetState(eBATTLE_STATE.PLAY);
    }
}
