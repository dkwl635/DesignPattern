using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KUtil
{
    public static class UIUtil
    {
       public static void SetBtnClick(Button _btn, UnityEngine.Events.UnityAction _click)
        {
            if (null == _btn)
                return;

            _btn.onClick.AddListener(_click);
        }

        public static void SetBtnClick(Button[] _btn, UnityEngine.Events.UnityAction _click)
        {
            if (null == _btn)
                return;

            for (int i = 0; i < _btn.Length; i++)
            {
                _btn[i].onClick.AddListener(_click);
            }
        }

        public static void SetAlpha(Graphic _graphic, float _alpha)
        {
            if (_graphic == null)
                return;

            Color _color = _graphic.color;
            _color.a = _alpha;
            _graphic.color = _color;

        }
        public static void SetAlpha(Graphic[] _graphic, float _alpha)
        {
            if (_graphic == null)
                return;

            for (int i = 0; i < _graphic.Length; i++)
            {
                SetAlpha(_graphic[i], _alpha);
            }

        }

       public static bool IsOpen(MonoBase _mono)
        {
            if (_mono == null)
                return false;

            return _mono.isOpen;

        }




    }// public static class UIUtil
}


