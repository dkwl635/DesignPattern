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
    protected int m_score; 

    public int hp { get { return m_hp; } }
    public int maxHp {  get { return m_maxHp; } }
    public int battleCoin { get { return m_battleCoin; } }
    public eBATTLE_RESULT battleResult { get { return m_batteResult; } }
    public int score { get { return m_score; } }

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

    public void SetScore(int _score)
    {
        m_score = _score;
        if (m_score < 0)
            m_score = 0;
    }

    public void AddScore(int _score)
    {
        SetScore(m_score + _score);
    }


    public void AddBattleCoin(int coin)
    {
        SetBattleCoin(battleCoin + coin);
    }

    public void Open()
    {
       
        SetMaxHp(3);
        SetHp(maxHp);
        SetBattleCoin(10);
        SetBattleResult(eBATTLE_RESULT.NONE);
        SetScore(0);
    }

    public void SetBattleResult( eBATTLE_RESULT _battleResult)
    {
        m_batteResult = _battleResult;
    }

}
