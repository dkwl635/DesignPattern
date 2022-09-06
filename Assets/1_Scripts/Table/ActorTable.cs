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
        record.moveSpeed = 3.0f;
        list.Add(record);

        record = new ActorRecord();
        record.index = 1;
        record.path = "Tower/Tower_1";
        record.atk = 3;
        record.atkDis = 5.0f;
        record.atkTime = 0.1f;
        list.Add(record);

        Sort();
    }
}
