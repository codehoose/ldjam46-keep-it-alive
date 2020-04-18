using UnityEngine;

public class WeaponDetails : MonoBehaviour
{
    [Tooltip("Duration of weapon in seconds. -1 for default weapon")]
    public float duration;

    [Tooltip("Cooldown period (in seconds) between bullet emission")]
    public float cooldown;

    [Tooltip("The speed of the bullet. Or force..?")]
    public float speed;
}
