using  UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFSM : MonoBehaviour
{

    private Transform _baseTransform;
    private NavMeshAgent _agent;
    
    void Start()
    {
        _baseTransform = GameObject.FindWithTag("Base").transform;
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_baseTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
