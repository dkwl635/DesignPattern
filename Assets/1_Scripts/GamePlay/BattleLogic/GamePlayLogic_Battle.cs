using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLogic_Battle : GamePlayLogic
{
    public static GamePlayLogic_Battle Instance { get { return GamePlayManager.Instance.GetGamePlayLogic<GamePlayLogic_Battle>(); } }

    public FsmClass<eBATTLE_STATE> fsm = new FsmClass<eBATTLE_STATE>();
    public TileMap tileMap;
    public BattleLogic_MonsterSpawn monsterSpawn = new BattleLogic_MonsterSpawn();
    public BattleLogic_PlayData playData = new BattleLogic_PlayData();

    public override void Init()
    {
        base.Init();

        fsm.Clear();
        fsm.AddFsm(new BattleState_Ready(this));
        fsm.AddFsm(new BattleState_Play(this));
        fsm.AddFsm(new BattleState_Pause(this));
        fsm.AddFsm(new BattleState_Result(this));
        

    }

    public void DeleteTileMap()
    {
        if (tileMap == null)
            return;

        Destroy(tileMap.gameObject);
        tileMap = null;

    }

    public void CreateTileMap(TileMapRecord _record)
    {
        DeleteTileMap();
        tileMap = new GameObject("TileMap").AddComponent<TileMap>();
        tileMap.transform.SetParent(transform);
        tileMap.Load(_record);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        playData.Update(); 
        fsm.Update();
    }

}

