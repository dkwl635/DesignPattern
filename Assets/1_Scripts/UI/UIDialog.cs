using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialog : MonoBase
{
    public Button[] btnCloses;
    protected RectTransform m_rectTr;

    public override void Init()
    {
        base.Init();
        m_rectTr = transform as RectTransform;
        m_rectTr.offsetMin = Vector2.zero;
        m_rectTr.offsetMax = Vector2.zero;
        KUtil.UIUtil.SetBtnClick(btnCloses, OnClick_Close);
    }

    public override void Open()
    {
        base.Open();
        transform.SetAsLastSibling();
    }

    public virtual void OnClick_Close()
    {
        Close();

    }
}
