using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActorAttack 
{
    protected Actor m_owner;
    public Tile preTile;

    public ActorAttack(Actor _owner)
    {
        m_owner = _owner;
    }

    public virtual void Open()
    {
        preTile = null;
    }
    public Tile GetCurTile()
    {      
        return GamePlayLogic_Battle.Instance.tileMap.GetTile(m_owner.getPos);
    }

}
