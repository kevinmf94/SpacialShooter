using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Debug.Log($"Exists another {typeof(T)}");
            Destroy(this);
        }
    }


}