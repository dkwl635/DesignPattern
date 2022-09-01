using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    protected bool m_isNotify = false;
    protected List<IObserver> m_observerList = new List<IObserver>();
    public virtual void Clear()  
    {
        m_observerList.Clear();
    }

    public virtual void Attach(IObserver _observer)
    {
        if (_observer == null)
            return;

        if (m_observerList.Contains(_observer))
            return;
        m_observerList.Add(_observer);
                
    }

    public virtual void Detach(IObserver _observer)
    {
        if (_observer == null)
            return;

        m_observerList.Remove(_observer);
    }
    public void SetNorify(bool _isNotify)
    {
        m_isNotify = _isNotify;
    }

    public void SetNorify()
    {
        SetNorify(true);
    }

    protected virtual void Notify()
    {
        for (int i = 0; i < m_observerList.Count; i++)
        {
            IObserver observer = m_observerList[i];
            if (observer == null)
                continue;

            observer.Notify(this);

        }
    }

    public virtual void Update()
    {
        if (!m_isNotify)
            return;

        Notify();
        m_isNotify = false;
    }   

}
