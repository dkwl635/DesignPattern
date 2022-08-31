using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private void Awake()
    {

        SceneManager.Instance.Init();
        SceneManager.Instance.fsm.SetState(eSCENE_STATE.INTRO);
    }



}
