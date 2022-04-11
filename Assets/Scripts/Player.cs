using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private GameObject _bullet;

    private int _maxHealth = 40, _minHealth = 0;

    [SerializeField] private int _countKey = 0;

    public int CountKey { get => _countKey; set => _countKey = value; }
   
    [SerializeField] private HeathBar _bar;

    [SerializeField] private int _damage = 5;

    private bool _isFire ;
    void Start()
    {
        _isFire = true;
        _maxHealth = _health;
        _bar.SetMaxHealth(_maxHealth);
    }

    public bool AddHealth(int health)
    {
        if(_health == _maxHealth) return false;
        else
        {
            _health += health;
            _bar.SetHealth(_health);
            return true;
        }
    }


    public void Hit(int damage)
    {
        _health -= damage;
        _bar.SetHealth(_health);
        Debug.Log($"Hit( {damage})" + $"\n_health: {_health}");
        if (_health <= _minHealth)
        {
            Debug.Log("ÏÎ×ÈË");
            gameObject.SetActive(false);
        }
            

    }

    public void Fire(Transform pose)
    {
        _isFire = false;
        //var spawner = Instantiate(_gun, pose.position, pose.rotation);
        var bull = Instantiate(_bullet, pose.position, pose.rotation);
        //var rbBUllet = bull.GetComponent<Rigidbody>();
        //rbBUllet
        //rbBUllet.AddForce(transform.forward * 200f);
        print("Fire");
        var bullet = bull.GetComponent<BulletForEnemy>();
        bullet.Init(2f);

        Invoke(nameof(Reloading), 2);
    }
    private void Reloading()
    {
        _isFire = true;
    }

}




