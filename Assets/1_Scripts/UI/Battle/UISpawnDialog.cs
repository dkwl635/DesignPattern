using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnDialog : UIDialog,IObserver
{
    public GameObject parentButton;
    public Button btnSpawn;
    public Text textSpawnCost;

    ActorRecord m_spawnRecord;
    Tile m_tile;
    private bool m_isApplicationQuit;
    private void OnApplicationQuit()
    {
        m_isApplicationQuit = true;
    }

    private void OnEnable()
    {
        GamePlayLogic_Battle.Instance.playData.Attach(this);
    }

    public void OnDisable()
    {
        if (m_isApplicationQuit)
            return;
        GamePlayLogic_Battle.Instance.playData.Detach(this);

    }

   
    public void Notify(Subject _sub)
    {
        ResetData();
    }

    public void ResetData()
    {
        int cost = (int)m_spawnRecord.GetStatValue(eSTAT_TYPE.COST, 1);
        KUtil.UIUtil.SetText(textSpawnCost, cost.ToString());
        KUtil.UIUtil.SetColor(textSpawnCost, GamePlayLogic_Battle.Instance.playData.battleCoin < cost ? Color.red : Color.black);
    }

    public virtual void Open(Tile _tile)
    {
        base.Open();
        m_tile = _tile;
        parentButton.transform.position = Camera.main.WorldToScreenPoint(m_tile.transform.position);
        ResetData();
    }

    public void OnClick_Spawn()
    {
        int cost = (int)m_spawnRecord.GetStatValue(eSTAT_TYPE.COST, 1);
        if (cost > GamePlayLogic_Battle.Instance.playData.battleCoin)
            return;

        ActorData _data = new ActorData_Tower(eTEAM.PLAYER, GameData_Tower.Instance.GetTower(m_spawnRecord.index));  
        ActorManager.Instance.CreateActor(_data, new ActorFactoryCreator_Tower(), m_tile.transform.position, Quaternion.identity);

        m_tile.SetTileType(eTILE_TYPE.NONE);
        GamePlayLogic_Battle.Instance.playData.AddBattleCoin(-cost);
        Close();
    }

    public override void Init()
    {
        base.Init();

        KUtil.UIUtil.SetBtnClick(btnSpawn, OnClick_Spawn);
        m_spawnRecord = ActorTable.Instance.Get(1);
      
    }

}
