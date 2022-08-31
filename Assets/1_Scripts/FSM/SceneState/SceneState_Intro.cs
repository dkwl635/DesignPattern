using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState_Intro : SceneState
{

    public SceneState_Intro(SceneManager _sceneManager) : base(_sceneManager, eSCENE_STATE.INTRO)
    {
        
    }

    public override void Enter(FsmMsg _msg)
    {
        base.Enter(_msg);
        UIManager.Instance.dialog.OpenDlg("UI/UIIntro/UIIntroDialog");

    }

    public override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonUp(0))
        {
            UIManager.Instance.fadeDialog.FadeIn(() => m_sceneManager.fsm.SetState(eSCENE_STATE.LOBBY));
        }
    }

}