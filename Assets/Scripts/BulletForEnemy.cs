using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForEnemy : MonoBehaviour
{
    private float _speedBullet = 300f;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private ParticleSystem _particleSystem;
    private AudioSource _audioSource; // источник звука
    [SerializeField] private AudioClip _clip;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void Init(float lifeTime)
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
       
        var player = collision.gameObject.GetComponent<Enemy>();
        if (player != null)
        {
            player.Hurt(_damage);
            Destroy(gameObject);
        }

        var tmp = collision.contacts[0];
       
        var partSystem = Instantiate(_particleSystem);
        partSystem.transform.position = tmp.point;
        partSystem.transform.rotation = /*Quaternion.Euler(tmp.normal) */ new Quaternion(0f,0f, transform.rotation.z , 1f);
        var lifetime = partSystem.main.duration + partSystem.main.startDelayMultiplier;
        _audioSource.PlayOneShot(_clip);
        Destroy(partSystem.gameObject, lifetime);
    }
}
