using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public float _health = 100;

    public void Add(float value)
    {
        _health = Mathf.Clamp(_health + value, 0, 100);
    }
}
