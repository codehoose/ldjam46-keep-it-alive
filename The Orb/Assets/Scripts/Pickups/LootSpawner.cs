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

    public float _chanceOfDrop = 0.2f;

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
        if (Random.Range(0, 1f) > _chanceOfDrop) return;

        position.y = 0; // HACKY :D
        var copy = Instantiate(_lootBoxPrefab, position, Quaternion.identity);
        var lootBox = copy.GetComponent<LootBox>();
        lootBox._loot = Instantiate(WeightedRandomizer.From(_weighted).TakeOne());

        var visual = lootBox._loot.GetComponent<LootDropMonoBehaviour>()._containerPrefab;
        var visualCopy = Instantiate(visual, lootBox.transform);
        visualCopy.transform.localPosition = Vector3.zero;
    }
}
