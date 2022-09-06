using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBATTLE_RESULT
{
    NONE,
    SUCC,
    FAILED,
}

public class BattleLogic_PlayData : Subject
{
    protected int m_hp;
    protected int m_maxHp;
    protected int m_battleCoin;
    protected eBATTLE_RESULT m_batteResult;

    public int hp { get { return m_hp; } }
    public int maxHp {  get { return m_maxHp; } }
    public int battleCoin { get { return m_battleCoin; } }
    public eBATTLE_RESULT battleResult { get { return m_batteResult; } }

    public void SetHp(int _hp)
    {
        m_hp = _hp;
        if (m_hp < 0)
            m_hp = 0;
        SetNorify();
    }
    public void AddHp(int _hp)
    {
        SetHp(m_hp + _hp);
    }

    public void SetMaxHp(int _maxHp)
    {
        m_maxHp = _maxHp;
        if (m_maxHp <= 0)
            m_maxHp = 1;

        SetNorify();
    }

    public void SetBattleCoin(int coin)
    {
        m_battleCoin = coin;
        if (m_battleCoin < 0)
        {
            m_battleCoin = 0;
        }
        SetNorify();      
    }

    public void AddBattleCoin(int coin)
    {
        SetBattleCoin(battleCoin + coin);
    }

    public void Open()
    {
        m_battleCoin = 0;
        m_batteResult = eBATTLE_RESULT.NONE;
        SetMaxHp(3);
        SetHp(maxHp);
    }

    public void SetBattleResult( eBATTLE_RESULT _battleResult)
    {
        m_batteResult = _battleResult;
    }

}
