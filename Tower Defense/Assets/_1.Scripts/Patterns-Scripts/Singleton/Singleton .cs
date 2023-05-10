using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T m_instance;

    public static T instance
    {
        get
        {
            if (!m_instance)
                m_instance = FindObjectOfType<T>();

            if (m_instance) return m_instance;

            GameObject parent = GameObject.Find("GameManager");
            if (!parent) return null;

            m_instance = parent.AddComponent<T>();

            return m_instance;
        }
    }


    private void Awake()
    {
        if (!m_instance)
            m_instance = this as T;
        else
            if (m_instance != this)
                Destroy(this);
    }
}
