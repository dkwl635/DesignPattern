using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMananger : Singleton<GameDataMananger>
{
    protected Dictionary<System.Type, GameData> m_dataList = new Dictionary<System.Type, GameData>();

    public void Init()
    {
        AddData<GameData_Wealth>();
        AddData<GameData_Tower>();

        Load();
    }

    public virtual void Load()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Init();
        }
    }

    public void AddData<TGameData>() where TGameData : GameData, new ()
    {
        System.Type _type = typeof(TGameData);
        if (m_dataList.ContainsKey(_type))
        {
            return;
        }

        m_dataList.Add(_type, new TGameData());
    }

    public TGameData GetData<TGameData>() where TGameData : GameData
    {
        System.Type _type = typeof(TGameData);
        if (!m_dataList.ContainsKey(_type))
            return null;

        return m_dataList[_type] as TGameData ;
    }

    public virtual void Logout()
    {
        var _var = m_dataList.GetEnumerator();
        while(_var.MoveNext())
        {
            _var.Current.Value.LogOut();
        }
    }

    public virtual void Update()
    {
        var _var = m_dataList.GetEnumerator();
        while (_var.MoveNext())
        {
            _var.Current.Value.Update();
        }
    }
}
