using System;
using UnityEngine;
using UnityEngine.AI;

public class Mobile : MonoBehaviour
{
    private bool _walking;
    private Transform _target;
    private NavMeshAgent _agent;

    public event EventHandler IAmHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            IAmHit?.Invoke(gameObject, EventArgs.Empty);
            Destroy(collision.gameObject);
        }
    }

    public void StartWalking(Transform target)
    {
        _walking = true;
        _target = target;
        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = true;
    }

    private void LateUpdate()
    {
        if (!_walking) return;

        _agent.SetDestination(_target.position);
    }
}