using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState_Ready : BattleState
{
    FlowCommand flowCommand = new FlowCommand();

    public BattleState_Ready(GamePlayLogic_Battle _logic) : base(_logic,  eBATTLE_STATE.READY)
    {

    }
    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);

        m_logic.monsterSpawn.Open();
        m_logic.playData.Open();
        m_logic.CreateTileMap(TileMapTable.Instance.Get(1));

        UIManager.Instance.dialog.OpenDialog("UI/UIBattle/UIBatlleDialog");
        UIManager.Instance.fadeDialog.FadeOut(null);
        flowCommand.Add(new Command_OpenDialog("UI/UIBattle/UIBattleReadyDialog"));
        flowCommand.Add(new Command_Delegate(() => m_logic.fsm.SetState(eBATTLE_STATE.PLAY)));
    }

    public override void Update()
    {
        base.Update();
        flowCommand.Update();
    }

}
