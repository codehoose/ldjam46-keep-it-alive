using UnityEngine;

public class MobSpawnerMonoBehaviour : MonoBehaviour
{
    public event MobEventHandler MobDead;

    protected void OnMobDead(Vector3 position)
    {
        MobDead?.Invoke(this, new MobEventArgs(position));
    }
}