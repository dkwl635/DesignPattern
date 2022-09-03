using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public GamePlayLogic m_gamePlayLogic;
    public void SetGamePlayLogic(GamePlayLogic _gamePlayLogic)
    {
        if(m_gamePlayLogic != null)
        {
            Destroy(m_gamePlayLogic.gameObject);
            m_gamePlayLogic = null;
        }

        if(_gamePlayLogic != null)
        {
            m_gamePlayLogic = _gamePlayLogic;
            m_gamePlayLogic.Init();
        }
    }

    public T CreateGamePlayLogic<T>() where T : GamePlayLogic
    {
        GameObject _obj = new GameObject(typeof(T).Name);
        _obj.transform.SetParent(transform);
        T _component = _obj.AddComponent<T>();
        SetGamePlayLogic(_component);
        return _component;
    }

    public T GetGamePlayLogic<T>() where T : GamePlayLogic
    {
        return m_gamePlayLogic as T;
    }

    private void Update()
    {
        if (m_gamePlayLogic != null)
            m_gamePlayLogic.UpdateLogic();
    }

}
