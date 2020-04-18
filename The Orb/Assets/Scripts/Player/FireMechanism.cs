using UnityEngine;

public class FireMechanism : MonoBehaviour
{
    private CurrentWeapon _weapon;

    public float _spawnDistance = 1.3f;

    void Awake()
    {
        _weapon = GetComponent<CurrentWeapon>();
    }

    void Update()
    {
        var x = Input.GetAxis("FireHorizontal");
        var y = Input.GetAxis("FireVertical");

        var vec = new Vector3(x, 0, y);
        if (vec.sqrMagnitude <= 0) return; // Player did not fire

        var quat = Quaternion.LookRotation(vec.normalized, Vector3.up);
        var spawnPoint = transform.position + vec.normalized * _spawnDistance;
        _weapon.FireWeapon(spawnPoint, quat);
        print(vec);
    }
}
