using System;
using UnityEngine;

namespace Utils
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();
                }

                return m_Instance;
            }
        }

        private void Awake()
        {
            if (m_Instance != null&& m_Instance != GetComponent<T>())
            {
                Destroy(gameObject);
                return;
            }
            m_Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
            OnAwake();
        }

        public virtual void OnAwake()
        {
            
        }
    }
}