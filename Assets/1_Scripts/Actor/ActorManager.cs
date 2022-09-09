using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : Singleton<ActorManager>
{
    MemoryPooling<Actor> m_actorPool;
    MemoryPooling<Missile> m_missilePool;

    private void Awake()
    {
        m_actorPool = new MemoryPooling<Actor>(transform, 100);
        m_missilePool = new MemoryPooling<Missile>(transform, 100);
    }

    public void Clear()
    {
        m_actorPool.Clear();
        m_missilePool.Clear();

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
            if (actor.data.team != _findTeam)
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

      public Missile CreateMissile(string _path, eTEAM _atkTime, int _atk, Vector3 _pos, Vector3 _dir)
    {
        Missile _missle = m_missilePool.Get(_path, (GameObject _obj) => _obj.AddComponent<Missile>());
        if (_missle == null)
            return null;

        _missle.Open(_atkTime, _atk, _pos, _dir);
        return _missle;

    }

    public int GetCount(eTEAM team)
    {
        int count = 0;
        for (int i = 0; i < m_actorPool.activeList.Count; i++)
        {
            Actor _actor = m_actorPool.activeList[i].item;
            if (_actor == null)
                continue;
            if (_actor.data.team != team)
                continue;
            count++;
        }
        return count;
    }


    public void UpdateLogic()
    {
        m_actorPool.UpdateLogic();
        m_missilePool.UpdateLogic();
    }
}
