using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleReadyDialog : UIDialog
{
    FlowCommand m_flowCommand = new FlowCommand();

    public override void Open()
    {
        base.Open();
        m_flowCommand.Clear();
        m_flowCommand.Add(new Command_DeltaTime(1.5f, Close));
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        m_flowCommand.Update();
    }
}
