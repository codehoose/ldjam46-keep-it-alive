using UnityEngine;

public class LootScoop : MonoBehaviour
{
    private CurrentWeapon _weapon;

    void Awake()
    {
        _weapon = GetComponent<CurrentWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LootBox")
        {
            var lootBox = other.GetComponent<LootBox>();
            var loot = lootBox._loot;
            var weapon = loot.GetComponent<WeaponDetails>();
            if (weapon != null)
            {
                _weapon.PickupWeapon(loot);
            }

            lootBox.LootPilfered();
        }
    }
}
