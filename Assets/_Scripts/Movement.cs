using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{

    [SerializeField]
    [Range(0, 2000)]
    private float speed;
    
    [SerializeField]
    [Range(0, 360)]
    private float rotationSpeed;

    private Rigidbody _rigidbody;
    private Animator _animator;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float space = speed * Time.deltaTime;
        float rotation = rotationSpeed * Time.deltaTime;
        
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(moveX, 0, moveY);
        _rigidbody.AddRelativeForce(dir.normalized * space);
        _rigidbody.AddRelativeTorque(0, rotation * mouseX, 0);
        
        _animator.SetFloat("MoveX", moveX);
        _animator.SetFloat("MoveY", moveY);
        _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);
    }
}
