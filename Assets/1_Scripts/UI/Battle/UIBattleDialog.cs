using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleDialog : UIDialog , IObserver
{
    public Button btnPause;
    public Slider sliderHp;
    public Text textHp;
    public Text textBattleCoin;
    public Text textScore; 
    
    private bool m_isApplicationQuit = false;

    private void OnApplicationQuit()
    {
        m_isApplicationQuit = true;
    }

    private void OnEnable()
    {
        GamePlayLogic_Battle.Instance.playData.Attach(this); 
    }

    private void OnDisable()
    {
        if (m_isApplicationQuit)
            return;

        GamePlayLogic_Battle.Instance.playData.Detach(this);
    }

    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnPause, OnClick_Pause);
    }

    public void Notify(Subject _sub)
    {
        ResetData();
    }

    public void ResetData()
    {
        BattleLogic_PlayData _PlayData = GamePlayLogic_Battle.Instance.playData;
        KUtil.UIUtil.SetText(textHp, string.Format("{0}/{1}", _PlayData.hp, _PlayData.maxHp));
        KUtil.UIUtil.SetValue(sliderHp, _PlayData.hp / (float)_PlayData.maxHp);
        KUtil.UIUtil.SetText(textBattleCoin, _PlayData.battleCoin.ToString());
        KUtil.UIUtil.SetText(textScore, _PlayData.score.ToString());
    }

    public void OnClick_Pause()
    {
        GamePlayLogic_Battle.Instance.fsm.SetState(eBATTLE_STATE.PAUSE);
    }

    public override void Open()
    {
        base.Open();
        ResetData(); 
    }

}
