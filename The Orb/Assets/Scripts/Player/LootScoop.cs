using System;
using UnityEngine;

public class LootScoop : MonoBehaviour
{
    public Canvas _canvas;
    public GameObject _pickupNotification;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LootBox")
        {
            var lootBox = other.GetComponent<LootBox>();
            var loot = lootBox._loot;
            other.enabled = false; // Even more hacky
            var weapon = loot.GetComponent<LootDropMonoBehaviour>();
            weapon?.Apply(gameObject);

            if (weapon is WeaponDetails)
            {
                NotifyPlayer(weapon._dropName);
            }

            lootBox.LootPilfered();
        }
    }

    private void NotifyPlayer(string dropName)
    {
        var copy = Instantiate(_pickupNotification, _canvas.transform);
        var text = copy.GetComponent<PickupWeaponAnimation>();
        text.StartAnimating(dropName);
    }
}
