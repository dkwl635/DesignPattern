using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eTEAM
{
    PLAYER,
    MONSTER,
}

public enum eSTAT_TYPE
{
    MAX_HP,
    MOVE_SPEED,
    ATK,
    ATK_TIME,
    ATK_DIS,
    COST,
    REWARD_BATTLE_COIN,
    UPGRADE_COST
}
public class  StatData
{
    public eSTAT_TYPE statType;
    public float statValue;
    public float statAddValue;

    public StatData(eSTAT_TYPE statType , float statValue , float statAddValue)
    {
        this.statType = statType;
        this.statValue = statValue;
        this.statAddValue = statAddValue;
    }

}

[System.Serializable]
public class ActorRecord : Record
{
    public string path;
    public List<StatData> statList = new List<StatData>();
    public float GetStatValue(eSTAT_TYPE _statType, int lv)
    {
        StatData _find = statList.Find(item => item.statType == _statType);
        if (_find == null)
            return 0.0f;

        return _find.statValue + _find.statAddValue * (lv -1);
 
    }
}

[System.Serializable]
public class ActorTable  : Table<ActorRecord>
{
    static public ActorTable Instance { get { return TableManager.Instance.GetTable<ActorTable>(); } }
    public override void LoadFile(string _path)
    {
        base.LoadFile(_path);
        ActorRecord record = new ActorRecord();
        record.index = 10;
        record.path = "Monster/Monster_1";
        record.statList.Add(new StatData(eSTAT_TYPE.MAX_HP, 10, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.MOVE_SPEED, 1.5f, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.ATK, 1.0f, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.REWARD_BATTLE_COIN, 5.0f, 0));
        list.Add(record);

        record = new ActorRecord();
        record.index = 1;
        record.path = "Tower/Tower_1";
        record.statList.Add(new StatData(eSTAT_TYPE.ATK, 5.0f, 5.0f));
        record.statList.Add(new StatData(eSTAT_TYPE.ATK_DIS, 10.0f, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.ATK_TIME, 1.0f, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.COST, 10.0f, 0));
        record.statList.Add(new StatData(eSTAT_TYPE.UPGRADE_COST, 10.0f, 10.0f));

        list.Add(record);

        Sort();
    }
}
