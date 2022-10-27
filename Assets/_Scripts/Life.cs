using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float maximumLife;
    
    public UnityEvent onDeath;

    private float _amount;

    public float Maximum
    {
        get => maximumLife;
    }

    public float Amount
    {
        get => _amount;
    
        set
        {
            _amount = value;
      
            if (_amount <= 0)
            {
                onDeath.Invoke();
            }
        }
    }

    private void Awake()
    {
        _amount = maximumLife;
    }
}
