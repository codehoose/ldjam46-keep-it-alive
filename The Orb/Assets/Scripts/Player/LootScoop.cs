using UnityEngine;

public class LootScoop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LootBox")
        {
            var lootBox = other.GetComponent<LootBox>();
            var loot = lootBox._loot;
            var weapon = GetDrop(loot);
            weapon?.Apply(gameObject);

            lootBox.LootPilfered();
        }
    }

    /// <summary>
    /// Get the item the loot box is carrying. It could be anything! A weapon,
    /// a health pack. So long as it implements ILootDrop y'all are good.
    /// </summary>
    /// <param name="other">The other game object</param>
    /// <returns>The dropped loot or null if nothing found</returns>
    private ILootDrop GetDrop(GameObject other)
    {
        foreach (var component in other.GetComponents(typeof(MonoBehaviour)))
        {
            if (component.GetType().GetInterface(typeof(ILootDrop).Name) != null)
            {
                return (ILootDrop)component;
            }
        }

        return null;
    }
}
