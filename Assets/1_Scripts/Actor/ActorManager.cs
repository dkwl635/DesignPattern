using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Singleton<ActorManager>
{
    MemoryPooling<Actor> m_actorPool;

    private void Awake()
    {
        m_actorPool = new MemoryPooling<Actor>(transform, 100);
    }

    public void Clear()
    {
        m_actorPool.Clear();
    }

    public Actor CreateActor(ActorData data, ActorFactoryCreator _creator, Vector3 pos ,Quaternion rot)
    {
        Actor actor = m_actorPool.Get(data.getActorRecord.path, null);
        if (actor == null)
            return null;

        actor.Open(data, _creator, pos, rot);
        return actor;
    }
    public Actor FindNear(Actor _owner, eTEAM _findTeam, float _atkDis)
    {
        float minDis = float.MaxValue;
        Actor nearActor = null;

        for (int i = 0; i < m_actorPool.activeList.Count; i++)
        {
            Actor actor = m_actorPool.activeList[i].item;
            if (actor == null)
                continue;
            if (actor == _owner)
                continue;
        
            float dis = (actor.getPos - _owner.getPos).magnitude;
            if(dis < minDis)
            {
                minDis = dis;
                nearActor = actor;
            }
        }

        return nearActor;
    }



    public void UpdateLogic()
    {
        m_actorPool.UpdateLogic();
    }
}
