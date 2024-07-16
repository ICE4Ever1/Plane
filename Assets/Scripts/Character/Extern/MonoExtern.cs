using UnityEngine;

public static class MonoExtern
{
    public static bool HasComponent<T>(this MonoBehaviour mono) where T : MonoBehaviour
    {
        if (mono.TryGetComponent<T>(out var t))
        {
            return true;
        }

        return false;
    }
    public static T GetComponentAdd<T>(this MonoBehaviour mono) where T:MonoBehaviour
    {
        T t;
        if (mono.TryGetComponent<T>(out t))
        {
            return t;
        }

        t = mono.gameObject.AddComponent<T>();
        return t;
    }
}
