using System.Collections.Generic;
using UnityEngine.Events;

public class WaveManager : Singleton<WaveManager>
{
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

    protected override void Awake()
    {
        base.Awake();
        _waves = new List<WaveSpawner>();
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
