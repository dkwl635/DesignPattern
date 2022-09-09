using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleResultDialog : UIDialog
{
    public Button btnToLobby;
    public Text textRewardGold;

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnToLobby, OnClick_ToLobby);
    }

    public override void Open()
    {
        base.Open();
        int rewardGold = GamePlayLogic_Battle.Instance.playData.score; 
        if(GamePlayLogic_Battle.Instance.playData.battleResult == eBATTLE_RESULT.SUCC)
        {
            rewardGold *= 2;
        }

        KUtil.UIUtil.SetText(textRewardGold, rewardGold.ToString());
        GameData_Wealth.Instance.AddCount(eWEALTH_TYPE.GOLD , rewardGold);
    }

    public void OnClick_ToLobby()
    {
        UIManager.Instance.fadeDialog.FadeIn(() => SceneManager.Instance.fsm.SetState(eSCENE_STATE.LOBBY));
    }
    

}
