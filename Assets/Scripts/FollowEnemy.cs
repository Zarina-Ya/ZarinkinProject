using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;

    [SerializeField] private Transform _target;

    [SerializeField] private Transform _ghost;

    [SerializeField] private float _minDistance;
    [SerializeField] private int _damage = 5;
    [SerializeField] private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_target.position, _ghost.position) > _minDistance && Vector3.Distance(_target.position, _ghost.position) < 5)
            _ghost.position = Vector3.MoveTowards(_ghost.position, _target.position, m_Speed * Time.deltaTime);
        _ghost.LookAt(_target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Hit(_damage);
            _rigidbody.AddForce(-Vector3.forward * 400f, ForceMode.Impulse);

        }
    }
}
