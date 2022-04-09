using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    [SerializeField] private float _speed;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();    
        _animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _animator.SetFloat("Speed", movement.normalized.magnitude);
        _rb.AddForce(movement.normalized * _speed);
    }
}
