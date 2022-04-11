using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private int i;
    [SerializeField] List<Transform> _points;



    [SerializeField] private float m_Speed = 5f;

    [SerializeField] private Transform _target;

    [SerializeField] private float _minDistance;


    private float _timer = 0f;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


   

    void Update()
    {
        _timer += Time.deltaTime;

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (_timer > 3)
            {
                _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
                _timer = 0;
            }

        }
    }

    private void FixedUpdate()
    {

        if (Vector3.Distance(_target.position, transform.position) > _minDistance && Vector3.Distance(_target.position, transform.position) < 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, m_Speed * Time.deltaTime);
        }
        transform.LookAt(_target.position);
    
    }
}
