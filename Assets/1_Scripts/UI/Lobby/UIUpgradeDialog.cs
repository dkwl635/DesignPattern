using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradeDialog : UIDialog
{
    public Button btnUpgrade;
    public Text textCost;
    public Text textStat;
    public Text textLv;

    GDTower m_data;


    public override void Init()
    {
        base.Init();
        KUtil.UIUtil.SetBtnClick(btnUpgrade, OnClick_Upgrade);
    }

    public void OnClick_Upgrade()
    {
        int cost = (int)m_data.GetStatValue(eSTAT_TYPE.UPGRADE_COST);
        int have = (int)GameData_Wealth.Instance.GetCount(eWEALTH_TYPE.GOLD);
        if (cost > have)
            return;
        m_data.LevelUp();
        GameData_Wealth.Instance.AddCount(eWEALTH_TYPE.GOLD, -cost);
        ResetData(); 
    }

    public override void Open()
    {
        base.Open();
        ResetData();
    }

    public void ResetData()
    {
        m_data = GameData_Tower.Instance.GetTower(1);
        int _cost = (int)m_data.GetStatValue(eSTAT_TYPE.COST);
        int _have = (int)GameData_Wealth.Instance.GetCount(eWEALTH_TYPE.GOLD);
        int _atk = (int)m_data.GetStatValue(eSTAT_TYPE.ATK);

        KUtil.UIUtil.SetText(textCost, _cost.ToString());
        KUtil.UIUtil.SetText(textStat, _atk.ToString());
        KUtil.UIUtil.SetText(textLv, string.Format("Lv.{0}", m_data.lv));
        KUtil.UIUtil.SetColor(textCost, _cost <= _have ? Color.black : Color.red);

    }

}
