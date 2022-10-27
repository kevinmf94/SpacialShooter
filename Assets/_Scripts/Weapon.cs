using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    
    [SerializeField]
    private GameObject shootingPoint;

    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = BulletPooling.Instance.GetFirstAvailable();
            if (bullet) {
                bullet.transform.position = shootingPoint.transform.position;
                bullet.transform.rotation = shootingPoint.transform.rotation;
                bullet.layer = LayerMask.NameToLayer($"{transform.tag}Bullet");
                bullet.SetActive(true);
                _animator.SetTrigger(Shoot);
            }
        }
    }
}
