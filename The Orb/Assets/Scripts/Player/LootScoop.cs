using UnityEngine;

public class LootScoop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LootBox")
        {
            var lootBox = other.GetComponent<LootBox>();
            var loot = lootBox._loot;
            var weapon = loot.GetComponent<LootDropMonoBehaviour>();
            weapon?.Apply(gameObject);

            lootBox.LootPilfered();
        }
    }
}
