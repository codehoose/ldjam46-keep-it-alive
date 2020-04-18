using UnityEngine;

public class LootBox : MonoBehaviour
{
    [Tooltip("The loot the player will pickup")]
    public GameObject _loot;


    public void LootPilfered()
    {
        // TODO: Particle effect!?
        Destroy(gameObject);
    }
}
