using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KUtil //�ٸ� ��ũ���� ��ġ�� �ʰ�
{
    public static class ResUtil
    {
        public static T Load<T>(string _path) where T : Object
        {
            if(string.IsNullOrEmpty(_path) == true)//�� ��������
                return null;

            T _res = Resources.Load<T>(_path);
            if (_res == null) //���ҽ��� ������ ����
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