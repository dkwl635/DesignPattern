using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData_Tower : ActorData
{
    GDTower m_data;
    public ActorData_Tower(eTEAM team, GDTower data) : base (team, data.getActorRecord)
    {
        m_data = data;
    }

    public override float GetStatValue(eSTAT_TYPE statType)
    {
        return m_data.GetStatValue(statType);
    }

}
