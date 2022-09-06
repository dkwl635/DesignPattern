using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{

    public eSCENE_STATE startState;
    private void Awake()
    {
        TableManager.Instance.Load();
       

        GameDataMananger.Instance.Init();
        SceneManager.Instance.Init();
        SceneManager.Instance.fsm.SetState(startState);
    }



}
