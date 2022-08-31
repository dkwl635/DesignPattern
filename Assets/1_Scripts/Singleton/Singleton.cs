using UnityEngine;


[DisallowMultipleComponent] //�Ѱ��� ���ӿ�����Ʈ �ȿ� �ϳ��� ��ũ��Ʈ�� ����Ҽ� ����
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    private static bool m_isApplicationQuit = false;

    public static T Instance
    {
        get
        {
            if (true == m_isApplicationQuit)
                return null;
            if(null == m_instance)
            {
                T[] _finds = FindObjectsOfType<T>();
                if(_finds.Length > 0)
                {
                    m_instance = _finds[0];
                    DontDestroyOnLoad(m_instance.gameObject);
                }
                if(_finds.Length > 1)
                {
                    for (int i = 0; i < _finds.Length; i++)
                    {
                        Destroy(_finds[i].gameObject);
                    }
                   
                }

                if(m_instance == null)
                {
                    GameObject createGameObj = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(createGameObj);
                    m_instance = createGameObj.AddComponent<T>();
                }
            }

            return m_instance;
        }
    }

    private void OnApplicationQuit() //�������α׷��� ���� �Ǹ� ȣ��Ǵ� �Լ�
    {
        m_isApplicationQuit = true;
    }


} 


