using  UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    
    private EnemyState _currentState;
    private Transform _baseTransform;
    private NavMeshAgent _agent;
    private Weapon _weapon;
    private Animator _animator;
    private Sight _sight;

    [SerializeField]
    private float baseAttackDistance, playerAttackDistance;

    [SerializeField]
    private GameObject shootingPoint;

    void Start()
    {
        _baseTransform = GameObject.FindWithTag("Base").transform;
        _agent = GetComponentInParent<NavMeshAgent>();
        _animator = GetComponentInParent<Animator>();
        _weapon = GetComponentInParent<Weapon>();
        _sight = GetComponent<Sight>();

        _currentState = EnemyState.GoToBase;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            
            case EnemyState.AttackBase:
                AttackBase();
                break;
            
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
            
            default:
                GoToBase();
                break;
        }
    }

    private void GoToBase()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_baseTransform.position);
        
        if (_sight.detectedTarget != null)
        {
            _currentState = EnemyState.ChasePlayer;
        }
        
        float distanceToBase = Vector3.Distance(transform.position, _baseTransform.position);
        if (distanceToBase < baseAttackDistance)
        {
            _currentState = EnemyState.AttackBase;
        }
    }
    
    private void AttackBase()
    {
        _agent.isStopped = true;
        LookAt(_baseTransform.position);
        ShootTarget();
    }

    private void ChasePlayer()
    {
        if (_sight.detectedTarget == null)
        {
            _currentState = EnemyState.GoToBase;
            return;
        }
        
        _agent.isStopped = false;
        _agent.SetDestination(_sight.detectedTarget.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position,
            _sight.detectedTarget.transform.position);

        if (distanceToPlayer < playerAttackDistance)
        {
            _currentState = EnemyState.AttackPlayer;
        }
    }

    private void AttackPlayer()
    {
        _agent.isStopped = true;
        
        if (_sight.detectedTarget == null)
        {
            _currentState = EnemyState.GoToBase;
            return;
        }
        
        LookAt(_sight.detectedTarget.transform.position);
        ShootTarget();

        float distanceToPlayer = Vector3.Distance(transform.position,
            _sight.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            _currentState = EnemyState.ChasePlayer;
        }
    }
    
    void ShootTarget()
    {
        if (_weapon.ShootGun())
        {
            _animator.SetTrigger(Shoot);
        }
    }
    
    private void LookAt(Vector3 targetPos)
    {
        var directionToLook = Vector3.Normalize(targetPos - shootingPoint.transform.position);
        directionToLook.y = 0;
        shootingPoint.transform.forward = directionToLook;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
            
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
