using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowWealth : MonoBehaviour, IObserver
{
    public eWEALTH_TYPE wealthType;
    public Text textCount;

    private long m_count = long.MinValue;
    private bool m_isApplicationQuit = false;


    void ResetData()
    {
        long _count = GameData_Wealth.Instance.GetCount(wealthType);
        if (m_count == _count)
            return;

        m_count = _count;
        KUtil.UIUtil.SetText(textCount, m_count.ToString());
    }

    void OnEnable()
    {
        GameData_Wealth.Instance.Attach(this);
    }

    void OnDisable()
    {
        if (m_isApplicationQuit)
            return;

        GameData_Wealth.Instance.Detach(this);
    }

    void OnApplicationQuit()
    {
        m_isApplicationQuit = true;
    }

    public void Notify(Subject _sub)
    {
        ResetData();
    }

}