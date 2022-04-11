using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private GameObject _gun;

    private int _maxHealth = 10, _minHealth = 0;

    [SerializeField] private int _countKey = 0;

    public int CountKey { get => _countKey; set => _countKey = value; }
   
    [SerializeField] private HeathBar _bar;

    void Start()
    {
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


}

