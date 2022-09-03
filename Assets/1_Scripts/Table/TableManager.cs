using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : Singleton<TableManager>
{
    private Dictionary<System.Type, ITable> m_tableList = new Dictionary<System.Type, ITable>();
    
    public void Load()
    {
        //초기화
        m_tableList.Clear();
        m_tableList.Add(typeof(TileMapTable), new TileMapTable());

        //셋팅
        var _var = m_tableList.GetEnumerator();
        while(_var.MoveNext())
        {
            _var.Current.Value.Load(string.Format("Table/{0}", _var.Current.Key.Name));
        }

    }

    public T GetTable<T>() where T : class, ITable
    {
        System.Type _type = typeof(T);
        ITable _find = null;
        if(m_tableList.TryGetValue(_type, out _find) == false)
        {
            Debug.Log("TableMananger::GetTable() ; " + _type.ToString());
            return null;
        }
        return _find as T;

    }

}
