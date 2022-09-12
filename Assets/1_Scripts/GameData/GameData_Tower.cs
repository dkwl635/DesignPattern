using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDTower
{
    public int tableIdx;
    public int lv;

    public ActorRecord getActorRecord { get { return ActorTable.Instance.Get(tableIdx); } }
    public float GetStatValue(eSTAT_TYPE statType)
    {
        return getActorRecord.GetStatValue(statType, lv);
    }

    public GDTower() { }
    public GDTower(int tableIdx, int lv)
    {
        this.tableIdx = tableIdx;
        this.lv = lv;
    }
     
   public void LevelUp()
    {
        lv++;
    }



}

public class GameData_Tower : GameData
{
  
    static public GameData_Tower Instance { get { return GameDataMananger.Instance.GetData<GameData_Tower>(); } }
    private List<GDTower> m_towerList = new List<GDTower>();

    public override void Init()
    {
        base.Init();
        m_towerList.Clear();
        SetTower(1, 1);
    }

    public GDTower GetTower(int tableIdx)
    {
        return m_towerList.Find(item => item.tableIdx == tableIdx);
    }

    public void SetTower(int tableIdx, int lv)
    {
        GDTower find = GetTower(tableIdx);
        if(find == null)
        {
            m_towerList.Add(new GDTower(tableIdx, lv));
        }
        else
        {
            find.lv = lv; 
        }
    }


}
