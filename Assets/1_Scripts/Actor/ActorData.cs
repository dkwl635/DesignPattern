using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ActorData 
{
    protected Actor m_owner;
    [SerializeField] protected eTEAM m_team;
    [SerializeField] protected int m_hp;
    [SerializeField] protected int m_maxHp;
    [SerializeField] protected ActorRecord m_actorRecord;

    public eTEAM team { get { return m_team; } }
    public int hp { get { return m_hp; } }
    public int maxHp { get { return m_maxHp; } }
    public ActorRecord getActorRecord { get { return m_actorRecord; } }
    public ActorData(eTEAM _team, ActorRecord _record)
    {
        m_team = _team;
        m_actorRecord = _record;
    }

    public void SetHp(int hp)
    {
        m_hp = hp;
        if (m_hp < 0)
            m_hp = 0;
    }

    public void AddHp(int hp)
    {
        SetHp(this.hp + hp);
    }

    public void SetMaxHp(int maxHp)
    {
        m_maxHp = maxHp;
        if (m_maxHp <= 0)
            m_maxHp = 1;
    }

    public virtual void Open(Actor owner)
    {
        m_owner = owner;
        SetMaxHp(m_actorRecord.maxHp);
        SetHp(maxHp);
    }

  

}
