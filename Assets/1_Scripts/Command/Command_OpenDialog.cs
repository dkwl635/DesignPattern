using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_OpenDialog : ICommand
{
    UIDialog uIDialog;
    string m_path;

    public Command_OpenDialog(string _path)
    {
        m_path = _path;
    }

    public void Execute()
    {
        uIDialog = UIManager.Instance.dialog.OpenDialog(m_path);
    }

    public void Update()
    {
        
    }
    public void Cancel()
    {

    }

   
    public bool IsFinished()
    {
        return KUtil.UIUtil.IsOpen(uIDialog) == false;
    }

}
