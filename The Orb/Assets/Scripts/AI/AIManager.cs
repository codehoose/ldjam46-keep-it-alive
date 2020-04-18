using UnityEngine;

public class AIManager : MonoBehaviour
{
    public MobSpawnerMonoBehaviour[] _spawners;

    public LootSpawner _lootSpawner;

    void Awake()
    {
        foreach (var spawner in _spawners)
        {
            spawner.MobDead += (o, e) =>
              {
                  _lootSpawner.DropLoot(e.Position);
              };
        }
    }
}
