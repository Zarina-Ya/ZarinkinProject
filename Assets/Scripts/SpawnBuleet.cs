using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuleet : MonoBehaviour
{
    [SerializeField] private GameObject buleet;
    [SerializeField] private Transform spawn;

    [SerializeField] private Transform _target;

    bool _isFire = true;
    [SerializeField] private float _coolDown = 3f;
    // Update is called once per frame
    void Update()
    {
        //if(Vector3.Distance(spawn.position, player.transform.position) < 4)
        //{
        //    Ray ray = new Ray(player.transform.position, spawn.position);
        //    Debug.DrawRay(player.transform.position, spawn.position, Color.red);
        //}
       
        

        // _ghost.position = Vector3.MoveTowards(_ghost.position, _target.position, m_Speed * Time.deltaTime);
        //_ghost.LookAt(_target.position)
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(spawn.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Vector3.Distance(spawn.position, _target.position) < 4)
            Fire(ray);
    }
    void Fire(Ray ray)
    {

        if (Physics.Raycast(ray, out RaycastHit hit, 6))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (_isFire) Fire();
            }
        }

        //if (Physics.Raycast(ray, out RaycastHit put))
        //{
        //    var player = put.collider.gameObject;
        //    if (player.name == "NewCharacter")
        //    {
        //        var bull = Instantiate(buleet, spawn.position, spawn.rotation);
        //        var rbBUllet = bull.GetComponent<Rigidbody>();
        //        rbBUllet.AddForce(transform.forward * 20f);
        //       // player.GetComponent<Player>().Hit(1);
        //        Debug.Log(player);
        //        return;
        //    }
        //    return;
        //}
        
        
    }

    private void Fire()
    {
        _isFire = false;
        var bull = Instantiate(buleet, spawn.position, spawn.rotation);
        //var rbBUllet = bull.GetComponent<Rigidbody>();
        //rbBUllet
         //rbBUllet.AddForce(transform.forward * 200f);
        print("Fire");
        var bullet = bull.GetComponent<Bullet>();
        bullet.Init( 5f);

        Invoke(nameof(Reloading), _coolDown);
    }

    private void Reloading()
    {
        _isFire = true;
    }
}
