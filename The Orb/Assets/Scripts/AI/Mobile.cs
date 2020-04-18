using System;
using UnityEngine;
using UnityEngine.AI;

public class Mobile : MonoBehaviour
{
    private bool _followInitial;
    private Transform _target;
    private Transform _shiny;
    private NavMeshAgent _agent;

    public event EventHandler IAmHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GetComponent<Collider>().enabled = false; // TURN OFF COLLIDER
            IAmHit?.Invoke(gameObject, EventArgs.Empty);
            Destroy(collision.gameObject);
        }
    }

    public void StartWalking(Transform target, Transform shiny)
    {
        _followInitial = true;
        _target = target;
        _shiny = shiny;
        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = true;
        _agent.destination = _shiny.position;

    }

    void Update()
    {
        if (_agent != null && !_agent.pathPending && _agent.remainingDistance < 5f)
        {
            _agent.isStopped = true;
        }
    }
}