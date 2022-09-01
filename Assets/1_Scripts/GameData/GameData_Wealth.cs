using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eWEALTH_TYPE
{
    GOLD,
    DIAMOND,
}
public class GDWealth
{
    private eWEALTH_TYPE m_type;
    private long m_count;
    public eWEALTH_TYPE type { get { return m_type; } }
    public long count { get { return m_count; } }
    public GDWealth() { }
    public GDWealth(eWEALTH_TYPE _type) { m_type = _type; }

    public void SetCount(long _count)
    {
        m_count = _count;
        if (m_count < 0)
            m_count = 0;
    }

    public void AddCount(long _count)
    {
        SetCount(m_count + _count);
    }
}

public class GameData_Wealth : GameData
{
  
    static public GameData_Wealth Instance { get { return GameDataMananger.Instance.GetData<GameData_Wealth>(); } }

    private List<GDWealth> m_wealthList = new List<GDWealth>();
    public override void Init()
    {
        base.Init();
        m_wealthList.Clear();
    }

    private GDWealth GetGDWealth(eWEALTH_TYPE _type)
    {
        return m_wealthList.Find(item => item.type == _type);
    }

    public long GetCount(eWEALTH_TYPE _type)
    {
        GDWealth _find = GetGDWealth(_type);
        if (_find == null)
            return 0;

        return _find.count;

    }

    public void SetCount(eWEALTH_TYPE _type, long _count)
    {
        GDWealth _find = GetGDWealth(_type);
        if (_find == null)
            m_wealthList.Add(_find = new GDWealth(_type));

        _find.SetCount(_count);
        SetNorify();

    }

    public void AddCount(eWEALTH_TYPE _type, long _count)
    {
        SetCount(_type, GetCount(_type) + _count);
    }

}
