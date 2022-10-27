using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField] 
    private int poolSize;

    private List<GameObject> _pool;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _pool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(prefab);
            bullet.SetActive(false);
            _pool.Add(bullet);
        }
    }

    public GameObject GetFirstAvailable()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!_pool[i].activeInHierarchy)
            {
                return _pool[i];
            }
        }

        return null;
    }

}
