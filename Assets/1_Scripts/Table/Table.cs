using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table<T> : ITable where T : Record, new ()
{
    public class CompareRecord : IComparer<T>
    {
        public int Compare(T x , T y)
        {
            return x.index.CompareTo(y.index);
        }
    }

    public List<T> list = new List<T>();
    T m_search = new T();
    CompareRecord m_compare = new CompareRecord();

    public virtual void Sort()
    {
        list.Sort(m_compare);
    }
    public T Get(int _index, bool _isShowLog = true)
    {
        m_search.index = _index;
        int _searchIndex = list.BinarySearch(m_search, m_compare);
        if(_searchIndex < 0 )//¸øÃ£À½
        {
            if(_isShowLog == true)
            {
                Debug.Log("Not Find");
            }
            return null;
        }

        return list[_searchIndex];
    }
    
    public bool IsHas(int _index)
    {
        m_search.index = _index;
        return list.BinarySearch(m_search, m_compare) >= 0;

    }


    public  virtual void LoadFile(string _path)
    {
       
    }

    public virtual void SaveFile(string _path)
    {
     
    }

    public void  Save(string _path)
    {
        SaveFile(_path);
    }

    public void Load(string _path)
    {
        LoadFile(_path);
    }



}
