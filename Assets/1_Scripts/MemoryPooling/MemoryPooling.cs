using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPooling<T> where T : MonoBase
{
    public delegate T AddComponentDelegate(GameObject _obj);
    protected List<MemoryPoolingItem<T>> m_activeList = new List<MemoryPoolingItem<T>>(); //劝己拳等 
    protected List<MemoryPoolingItem<T>> m_hideList = new List<MemoryPoolingItem<T>>();    //厚劝己等

    protected Transform m_attach;
    protected int m_maxCount = 100;

    public List<MemoryPoolingItem<T>> activeList { get { return m_activeList; } }
    public List<MemoryPoolingItem<T>> hideList { get { return m_hideList; } }

    public MemoryPooling(Transform _attach, int _maxCount)
    {
        m_attach = _attach;
        m_maxCount = _maxCount;
    }

    public void DeleteList(List<MemoryPoolingItem<T>> _list)
    {
        if (_list == null)
            return;

        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] == null)
                continue;
            if (_list[i].item == null)
                continue;

            GameObject.Destroy(_list[i].item.gameObject);
           
        }
        _list.Clear();
    }

    public void Clear()
    {
        DeleteList(m_activeList);
        DeleteList(m_hideList);
    }

    public void Close()
    {
        for (int i = 0; i < m_activeList.Count; i++)
        {
            if (m_activeList[i] == null)
                continue;
            if (m_activeList[i].item == null)
                continue;

            m_activeList[i].item.Close();
            m_hideList.Add(m_activeList[i]);
        }
        m_activeList.Clear();
    }

    public MemoryPoolingItem<T> GetItem(string _path, AddComponentDelegate _addComponentDelegate)
    {
        int _resKey = _path.GetHashCode();
        MemoryPoolingItem<T> _findItem = m_hideList.Find(item => item == null ? false : item.resKey == _resKey);
        if(_findItem == null)
        {
            GameObject _loadGameObj = KUtil.ResUtil.Create(_path, m_attach);
            if (_loadGameObj == null)
                return null;

            T _componet = _loadGameObj.GetComponent<T>();
            if(_componet == null)
            {
                if(_addComponentDelegate != null)
                {
                    _componet = _addComponentDelegate(_loadGameObj);
                }
            }

            if(_componet == null)
            {
                return null;
            }

            _componet.Init();
            _findItem = new MemoryPoolingItem<T>(_resKey, _componet);           
            m_activeList.Add(_findItem);
        }
        else
        {
            m_hideList.Remove(_findItem);
            m_activeList.Add(_findItem);
            _findItem.item.gameObject.SetActive(true);
        }

        return _findItem;
    }

    public T Get(string _path, AddComponentDelegate _addComponentDelegate = null)
    {
        MemoryPoolingItem<T> _getItem = GetItem(_path, _addComponentDelegate);
        if (_getItem == null)
            return null;

        return _getItem.item;
    }

    public void UpdateLogic()
    {
        int _index = 0;
        while(m_activeList.Count > _index)
        {
            MemoryPoolingItem<T> _activeItem = m_activeList[_index];
            if(_activeItem.item == null)
            {
                m_activeList.RemoveAt(_index);
                continue;
            }
            
            if(_activeItem.item.isOpen == false)
            {
                m_activeList.RemoveAt(_index);

                if (m_maxCount <= m_hideList.Count)
                    GameObject.Destroy(_activeItem.item.gameObject);
                else
                    m_hideList.Add(_activeItem);

                continue;
            }

            _activeItem.item.UpdateLogic();
            _index++;
        }
    }





}
