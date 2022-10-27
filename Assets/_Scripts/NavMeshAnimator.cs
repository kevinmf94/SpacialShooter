using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class NavMeshAnimator : MonoBehaviour
{
    private static readonly int Velocity = Animator.StringToHash("Velocity");
    
    private NavMeshAgent _agent;
    private Animator _animator;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        _animator.SetFloat(Velocity, _agent.velocity.magnitude);
    }
}
