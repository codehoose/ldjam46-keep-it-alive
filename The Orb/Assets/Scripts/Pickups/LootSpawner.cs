using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    struct Weighting
    {
        public float weight;
        public GameObject prefab;
    }

    private Dictionary<GameObject, int> _weighted = new Dictionary<GameObject, int>();

    public GameObject _lootBoxPrefab;

    public GameObject[] _prefabs;

    void Awake()
    {
        foreach (var prefab in _prefabs)
        {
            var loot = prefab.GetComponent<LootDropMonoBehaviour>();
            if (loot != null)
            {
                _weighted.Add(prefab, loot._weight);
            }
        }
    }

    public void DropLoot(Vector3 position)
    {
        // 1 in 5 chance of winning a prize!
        if (Random.Range(0, 1f) < 0.8f) return;

        var copy = Instantiate(_lootBoxPrefab, position, Quaternion.identity);
        var lootBox = copy.GetComponent<LootBox>();
        lootBox._loot = WeightedRandomizer.From(_weighted).TakeOne();
    }
}
