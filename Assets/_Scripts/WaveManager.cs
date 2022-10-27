using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public UnityEvent onWaveChanged;
    
    private List<WaveSpawner> _waves;
    private int _maxWaves;

    public int WavesCount
    {
        get => _waves.Count;
    }

    
    public int MaxWaves
    {
        get => _maxWaves;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _waves = new List<WaveSpawner>();
        }
        else
        {
            Debug.Log("Exists another WaveManager");
            Destroy(this);
        }
    }

    public void AddWave(WaveSpawner wave)
    {
        _maxWaves++;
        _waves.Add(wave);
        onWaveChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        _waves.Remove(wave);
        onWaveChanged.Invoke();
    }
}
