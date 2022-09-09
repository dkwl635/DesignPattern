using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eTEAM
{
    PLAYER,
    MONSTER,
}

[System.Serializable]
public class ActorRecord : Record
{
    public string path;
    public int maxHp;
    public float moveSpeed;
    public int atk;
    public float atkDis;
    public float atkTime;
    public int rewardBattleCoin;
    public int cost;
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
        record.maxHp = 10;
        record.moveSpeed = 1.5f;
        record.rewardBattleCoin = 5;
        record.atk = 1; 
        list.Add(record);

        record = new ActorRecord();
        record.index = 1;
        record.path = "Tower/Tower_1";
        record.atk = 3;
        record.atkDis = 10.0f;
        record.atkTime = 1.0f;
        record.cost = 10;
        list.Add(record);

        Sort();
    }
}
