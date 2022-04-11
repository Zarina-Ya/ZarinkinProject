using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private Transform _player;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnPositionBullet;

    [SerializeField] private float _coolDown;
    [SerializeField] private bool _isFire ;
    

    
    void Start()
    {
        _isFire = true;
    }
    public void Hurt(int damage)
    {
        Debug.Log("Ouch: " + damage);
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(-Vector3.forward * 500f);
        rb.AddTorque(Vector3.right * 500f);


     
        Destroy(gameObject, 1.5f);
    } 

    void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) > 3 && Vector3.Distance(_player.position, transform.position) < 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, 1.5f * Time.deltaTime);
            transform.LookAt(_player.position);
        }
            
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(_spawnPositionBullet.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Vector3.Distance(_spawnPositionBullet.position, _player.position) < 4)
            Fire(ray);
    }
    void Fire(Ray ray)
    {

        if (Physics.Raycast(ray, out RaycastHit hit, 6))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (_isFire) Fire();
            }
        }


    }

    private void Fire()
    {
        _isFire = false;
        var bull = Instantiate(_bulletPrefab, _spawnPositionBullet.position, _spawnPositionBullet.rotation);
        print("Fire");
        var bullet = bull.GetComponent<Bullet>();
        bullet.Init(3f);

        Invoke(nameof(Reloading), _coolDown);
    }

    private void Reloading()
    {
        _isFire = true;
    }
}
