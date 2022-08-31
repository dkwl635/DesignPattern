using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogManagement : MonoBehaviour
{
    MemoryPooling<UIDialog> m_pooling;

    private void Awake()
    {
        m_pooling = new MemoryPooling<UIDialog>(transform, 100);

    }

    public void Close()
    {
        m_pooling.Close();
    }

    public void Clear()
    {
        m_pooling.Clear();
    }

    public UIDialog OpenDlg(string _path)
    {
        UIDialog _dlg = m_pooling.Get(_path);
        if(_dlg == null)
        {
            return null;
        }

        _dlg.Open();
        return _dlg;

    }

    public T GetDlg<T>(string _path) where T : UIDialog
    {
        return m_pooling.Get(_path) as T;
    }

    private void Update()
    {
        m_pooling.UpdateLogic();  
    }



}
