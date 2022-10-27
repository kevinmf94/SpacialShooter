using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] 
    private GameObject prefab;

    [SerializeField] 
    private float startTime, endTime;

    [SerializeField] 
    private float spawnRate;


    // Start is called before the first frame update
    void Start()
    {
        WaveManager.Instance.AddWave(this);
        InvokeRepeating(nameof(SpawnEnemy), startTime, spawnRate);
        Invoke(nameof(EndWave), endTime);
    }

    void SpawnEnemy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
    
    void EndWave()
    {
        WaveManager.Instance.RemoveWave(this);
        CancelInvoke();
    }
}
