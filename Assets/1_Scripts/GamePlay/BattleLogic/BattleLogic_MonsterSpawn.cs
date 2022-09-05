using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogic_MonsterSpawn
{
    protected float m_monsterSpawnTime = 0.0f;
    protected float m_monsterMaxSpawnTime = 3.0f;

    protected int m_monsterSpawnCount = 0;
    protected int m_monsterMaxSpawnCount = 10;

    public virtual void Open()
    {
        m_monsterSpawnCount = 0;
        m_monsterSpawnTime = 0.0f;
    }

    public virtual void Update()
    {
        if (m_monsterMaxSpawnCount <= m_monsterSpawnCount)
            return;

        m_monsterSpawnTime += Time.deltaTime;
        if (m_monsterSpawnTime < m_monsterMaxSpawnTime)
            return;
        m_monsterSpawnTime = 0.0f;
        m_monsterMaxSpawnCount++;

        Tile startTile = GamePlayLogic_Battle.Instance.tileMap.GetTile(eTILE_TYPE.START);
        ActorManager.Instance.CreateActor(new ActorData(eTEAM.MONSTER, ActorTable.Instance.Get(10)), startTile.transform.position, Quaternion.AngleAxis(-90.0f, Vector3.up));
        
    }

}
