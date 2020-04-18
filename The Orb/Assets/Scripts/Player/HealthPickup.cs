using UnityEngine;

public class HealthPickup : MonoBehaviour, ILootDrop
{
    public float _healthRestored = 100f;

    public void Apply(GameObject target)
    {
        var health = target.GetComponent<PlayerHealth>();
        health?.Add(_healthRestored);
    }
}
