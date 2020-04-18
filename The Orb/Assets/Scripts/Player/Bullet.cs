using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire(float speed)
    {
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        GetComponent<SelfDestruct>().enabled = true;
    }
}
