using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] 
    private float time;
    
    void OnEnable()
    {
        Invoke(nameof(SetDisable), time);
    }

    private void SetDisable()
    {
        gameObject.SetActive(false);
    }

}
