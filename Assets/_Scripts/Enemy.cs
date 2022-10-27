using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly int Die = Animator.StringToHash("Die");
    
    [SerializeField]
    [Tooltip("Cantidad de puntos que se obtienen al derrotar al enemigo")]
    private int pointsAmount = 10;
    
    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }

    private void Start()
    {
        EnemyManager.Instance.AddEnemy(this);
    }

    void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(Die);
        
        Invoke("PlayDestruction", 0.0f);
        
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);
        
        Destroy(gameObject, 1);

        EnemyManager.Instance.RemoveEnemy(this);
        ScoreManager.Instance.Amount += pointsAmount;
    }
    
    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
    
}
