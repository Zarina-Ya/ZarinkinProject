using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _playerHeight = 1f;// рост
    [SerializeField] private float _jumpForce = 2f;// скрость прыжка 


    private Rigidbody _rb;

    private Animator _animator;

    [SerializeField] private float _turnspeed;
    [SerializeField] private float _moveSpeed = 6f;

    [SerializeField] private Vector3 _moveDirection;
    private float _horizontalMovement, _verticalMovement;

    [SerializeField] private float _groundDrag = 6f;// сопративление на земле 
    [SerializeField] private float _airDrag = 2f;// соправтиление в воздухе 


    [SerializeField] private bool _isGrounded;

    //ускорение
    [SerializeField] private float _moveMulti = 10f;
    [SerializeField] private float _moveAirMulti = 0.4f;


    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    [SerializeField] private Transform _spawnTransform;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();    
        _rb.freezeRotation = true;// запрещает любое вращение 
        _animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        //_isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight / 2 + 0.2f);
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight/2 + 0.5f ); 
        
        Debug.DrawRay(transform.position, Vector3.down *(_playerHeight / 2 + 0.5f), Color.red);


   
        MyInput();
        ControlDrag();

        if( _isGrounded)
        {
            if (Input.GetKeyDown(_jumpKey) /*&& _isGrounded*/)
            //{
                Jump();
            //    _animator.SetBool("isGrounded", _isGrounded);

            //}
            //else _animator.SetBool("isGrounded", !_isGrounded);

            //if(Input.GetMouseButtonDown(1))
            //{
            //    var player = GetComponent<Player>();
            //    player.Fire(_spawnTransform);
            //}
        }
       
    



    }

    private void FixedUpdate()
    {
        //Movement();
        MovePlayer();
    }

    //private void Movement()
    //{
    //    _horizontalMovement = Input.GetAxis("Horizontal");//  Input.GetAxisRaw("Horizontal") - в таком случае зачение : либо 0 , либо 1 , без сглаживания
    //    _verticalMovement = Input.GetAxis("Vertical");
       
    //    _moveDirection = transform.forward * _verticalMovement + transform.right * _horizontalMovement; 


    //    //Vector3 movement = new Vector3(_horizontalMovement, 0.0f, _verticalMovement);
    //    //_animator.SetFloat("Speed", movement.normalized.magnitude);
    //    //_rb.AddForce(movement.normalized * _speed);
    //}


    void MyInput()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");//  Input.GetAxisRaw("Horizontal") - в таком случае зачение : либо 0 , либо 1 , без сглаживания
        _verticalMovement = Input.GetAxis("Vertical");

        transform.Rotate(/*Vector3.up * _horizontalMovement * (100f * Time.deltaTime)*/transform.up * _horizontalMovement * _turnspeed);
        _moveDirection = transform.forward * _verticalMovement /*+ transform.right * _horizontalMovement*/;

        _animator.SetBool("isWalking", _moveDirection != Vector3.zero) ;
    }

    void MovePlayer()
    {
        if(_isGrounded)
            _rb.AddForce(_moveDirection.normalized* _moveSpeed * _moveMulti, ForceMode.Acceleration);//  ускорение, которое не меняет от массы тела : a = F/m;
        else if(!_isGrounded)
            _rb.AddForce(_moveDirection.normalized * _moveSpeed * _moveAirMulti * _moveMulti, ForceMode.Acceleration);//  ускорение, которое не меняет от массы тела : a = F/m;

    }

    void ControlDrag()
    {
        if (_isGrounded) _rb.drag = _groundDrag;
        else { _rb.drag = _airDrag; }
    }

    void Jump()
    {
        
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        
    }
}
