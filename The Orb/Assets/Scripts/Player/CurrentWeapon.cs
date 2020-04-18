using System.Collections;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    private bool _coolingDown;

    private WeaponDetails _details;

    public GameObject _defaultWeapon;

    public GameObject _currentWeapon;

    public Transform _spawnPoint;

    void Awake()
    {
        _details = _currentWeapon.GetComponent<WeaponDetails>();
    }

    public void PickupWeapon(GameObject weapon)
    {
        // TODO: Pool the objects?
        _currentWeapon = weapon;
        _details = weapon.GetComponent<WeaponDetails>();
    }

    public void FireWeapon(Vector3 spawn, Quaternion rotation)
    {
        if (_coolingDown) return;

        if (_currentWeapon == null)
        {
            _currentWeapon = _defaultWeapon;
            _details = _currentWeapon.GetComponent<WeaponDetails>();
        }

        if (_details.duration > 0)
        {
            StartCoroutine(RemoveAfter(_details.duration));
        }

        StartCoroutine(FireBullet(spawn, rotation));

    }

    IEnumerator FireBullet(Vector3 spawn, Quaternion rotation)
    {
        var copy = Instantiate(_currentWeapon, spawn /*_spawnPoint.position */, rotation); // _spawnPoint.rotation);
        var bullet = copy.GetComponent<Bullet>();
        bullet.Fire(_details.speed);
        _coolingDown = true;
        yield return new WaitForSeconds(_details.cooldown);
        _coolingDown = false;
    }

    IEnumerator RemoveAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _currentWeapon = _defaultWeapon;
        _details = _currentWeapon.GetComponent<WeaponDetails>();
    }
}
