using UnityEngine;

public abstract class LootDropMonoBehaviour : MonoBehaviour
{
    [Tooltip("The weight that the item can be chosen Between 0 and 100")]
    public int _weight = 100;

    [Tooltip("The name of the item")]
    public string _dropName;

    public abstract void Apply(GameObject target);
}