using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    private float _speedBullet = 300f;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _rb;

    // Start is called before the first frame update
    public void Init( float lifeTime)
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        _rb.AddForce(transform.forward * _speedBullet);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //// var player = collision.gameObject.GetComponent<Player>();
    
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Hit(_damage);
            Destroy(gameObject);
        }
    }
}
