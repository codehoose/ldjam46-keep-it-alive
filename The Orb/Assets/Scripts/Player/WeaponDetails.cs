using UnityEngine;

public class WeaponDetails : MonoBehaviour, ILootDrop
{
    [Tooltip("Duration of weapon in seconds. -1 for default weapon")]
    public float duration;

    [Tooltip("Cooldown period (in seconds) between bullet emission")]
    public float cooldown;

    [Tooltip("The speed of the bullet. Or force..?")]
    public float speed;

    public void Apply(GameObject target)
    {
        var weapon = target.GetComponent<CurrentWeapon>();
        if (weapon != null)
        {
            weapon.PickupWeapon(gameObject);
        }
    }
}
