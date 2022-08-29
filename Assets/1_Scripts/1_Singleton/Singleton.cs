using UnityEngine;


[DisallowMultipleComponent] //한개의 게임오브젝트 안에 하나의 스크립트만 사용할수 있음
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

    private void OnApplicationQuit() //게임프로그램이 종료 되면 호출되는 함수
    {
        m_isApplicationQuit = true;
    }


} 


