using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UIDialogManagement dialog;
    public UIDialogManagement fade;

    private UIFadeDialog m_FadeDialog;
    public UIFadeDialog fadeDialog
    {
        get
        { 
            if(KUtil.UIUtil.IsOpen(m_FadeDialog) == false)
            {
                m_FadeDialog = fade.GetDlg<UIFadeDialog>("UI/UIFade/UIFadeDialog");
            }

            return m_FadeDialog;
        }

    }


    public void Clear()
    {
        dialog.Clear();
    }


}
