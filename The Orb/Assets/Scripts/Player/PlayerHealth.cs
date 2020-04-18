using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public float _health = 100;

    public event EventHandler IAmDead;

    public void Add(float value)
    {
        _health = Mathf.Clamp(_health + value, 0, 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            _health = Mathf.Clamp(_health - 2f, 0, 100);
        }

        if (_health == 0)
        {
            IAmDead?.Invoke(this, EventArgs.Empty);
        }
    }
}
