using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActorAttack 
{
    protected Actor m_owner;
    protected float m_atkTime;
    protected Actor m_target;
    public Tile preTile;

    public ActorAttack(Actor _owner)
    {
        m_owner = _owner;
    }

    public virtual void Open()
    {
        preTile = null;
        m_atkTime = m_owner.data.GetStatValue(eSTAT_TYPE.ATK_TIME);
    }
    public Tile GetCurTile()
    {      
        return GamePlayLogic_Battle.Instance.tileMap.GetTile(m_owner.getPos);
    }

    public void setAtkTime(float _time)
    {
        m_atkTime = _time;
    }

    public bool isAtkEnable
    {
        get{ return m_atkTime >= m_owner.data.GetStatValue(eSTAT_TYPE.ATK_TIME); }
    }

    public Actor getTarget { get { return m_target; } }

    public void Update()
    {
        if(m_owner.data.GetStatValue(eSTAT_TYPE.ATK_TIME) > m_atkTime)
        {
            m_atkTime += Time.deltaTime;
        }
    }

    public void SetTarget(Actor _target)
    {
        m_target = _target;
    }




}
