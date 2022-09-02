using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KUtil //다른 스크립과 겹치지 않게
{
    public static class ResUtil
    {
        public static T Load<T>(string _path) where T : Object
        {
            if(string.IsNullOrEmpty(_path) == true)//빈 글자인지
                return null;

            T _res = Resources.Load<T>(_path);
            if (_res == null) //리소스에 아이템 없음
                return null;
            
            return _res;
        }
    
        public static GameObject Create(string _path, Transform _parent)
        {
            GameObject _res = Load<GameObject>(_path);
            if (null == _res)
                return null;

            GameObject _instantiate = GameObject.Instantiate<GameObject>(_res);
            if (_parent != null)
                _instantiate.transform.SetParent(_parent);

            return _instantiate;
        }

        public static T Create<T>(string _path, Transform _parent) where T : Component
        {
            T _res = Load<T>(_path);
            T _ins = GameObject.Instantiate<T>(_res);
            if (_ins == null)
                return null;

            if (_parent != null)
                _ins.transform.SetParent(_parent);
            return _ins;

        }




    }
}