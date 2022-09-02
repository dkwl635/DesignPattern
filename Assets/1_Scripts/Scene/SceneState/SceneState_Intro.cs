using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState_Intro : SceneState
{
    FlowCommand m_flowCommand = new FlowCommand();

    public SceneState_Intro(SceneManager _sceneManager) : base(_sceneManager, eSCENE_STATE.INTRO)
    {
        
    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        UIManager.Instance.Clear();
        UIManager.Instance.dialog.OpenDialog("UI/UIIntro/UIIntroDialog");

        m_flowCommand.Add(new Command_FadeDialog(UIFadeDialog.eSTATE.FADE_OUT, null));
        m_flowCommand.Add(new Command_DeltaTime(1.5f, null));
        m_flowCommand.Add(new Command_OpenDialog("UI/UIIntro/UITabpToStartDialog"));
        m_flowCommand.Add(new Command_FadeDialog(UIFadeDialog.eSTATE.FADE_IN, () => m_sceneManager.fsm.SetState(eSCENE_STATE.LOBBY)));

    }

    public override void Update()
    {
        base.Update();
        m_flowCommand.Update();
    }

}