using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerShooting : MonoBehaviour
{
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    
    private Weapon _weapon;
    private Animator _animator;
    
    void Start()
    {
        _weapon = GetComponent<Weapon>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _weapon.ShootGun();
            _animator.SetTrigger(Shoot);
        }
    }
}
