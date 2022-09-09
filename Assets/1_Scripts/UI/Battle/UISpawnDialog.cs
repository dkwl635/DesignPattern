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
        KUtil.UIUtil.SetText(textSpawnCost, m_spawnRecord.cost.ToString());
        KUtil.UIUtil.SetColor(textSpawnCost, GamePlayLogic_Battle.Instance.playData.battleCoin < m_spawnRecord.cost ? Color.red : Color.black);
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
        if (m_spawnRecord.cost > GamePlayLogic_Battle.Instance.playData.battleCoin)
            return;

        ActorData _data =new ActorData(eTEAM.PLAYER, m_spawnRecord);
        ActorManager.Instance.CreateActor(_data, new ActorFactoryCreator_Tower(), m_tile.transform.position, Quaternion.identity);

        m_tile.SetTileType(eTILE_TYPE.NONE);
        GamePlayLogic_Battle.Instance.playData.AddBattleCoin(-m_spawnRecord.cost);
        Close();
    }

    public override void Init()
    {
        base.Init();

        KUtil.UIUtil.SetBtnClick(btnSpawn, OnClick_Spawn);
        m_spawnRecord = ActorTable.Instance.Get(1);
      
    }

}
