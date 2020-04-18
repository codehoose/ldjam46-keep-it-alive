using UnityEngine;

public class Locomotion : MonoBehaviour
{
    private Rigidbody _rb;
    //private CurrentWeapon _weapon;

    private float _speed = 20f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //_weapon = GetComponent<CurrentWeapon>();
    }

    void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    // FOR TEST -- REMOVE
        //    _weapon.FireWeapon();
        //}
    }

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (_rb.velocity.sqrMagnitude >= 144) return;

        _rb.AddForce(new Vector3(x, 0, y) * _speed);

        var newDir = Vector3.RotateTowards(transform.forward, new Vector3(x, 0, y), Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
