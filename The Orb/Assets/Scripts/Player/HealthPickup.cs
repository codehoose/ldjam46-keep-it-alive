using UnityEngine;

public class HealthPickup : LootDropMonoBehaviour
{
    public float _healthRestored = 100f;

    public override void Apply(GameObject target)
    {
        var health = target.GetComponent<PlayerHealth>();
        health?.Add(_healthRestored);
    }
}
