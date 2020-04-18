using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject _zombiePrefab;

    public Transform _target;

    public GameObject _boundary;

    public float _cooldown = 5f;

    public bool _spawn = true;

    IEnumerator Start()
    {
        while (_spawn)
        {
            SpawnZombie();
            yield return new WaitForSeconds(_cooldown);
        }
    }

    void SpawnZombie()
    {
        var facing = _target.position - transform.position;
        var copy = Instantiate(_zombiePrefab, transform.position, Quaternion.LookRotation(facing.normalized));
        copy.GetComponent<Mobile>().StartWalking(_target);
        copy.GetComponent<Mobile>().IAmHit += (o, e) =>
          {
              Destroy(o as GameObject);
          };
    }
}
