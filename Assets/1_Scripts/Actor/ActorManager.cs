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

    public Actor CreateActor(ActorData data, Vector3 pos ,Quaternion rot)
    {
        Actor actor = m_actorPool.Get(data.getActorRecord.path, null);
        if (actor == null)
            return null;

        actor.Open(data, pos, rot);
        return actor;
    }

    public void UpdateLogic()
    {
        m_actorPool.UpdateLogic();
    }
}
