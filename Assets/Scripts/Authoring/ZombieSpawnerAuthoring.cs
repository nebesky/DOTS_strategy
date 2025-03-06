using Unity.Entities;
using UnityEngine;

class ZombieSpawnerAuthoring : MonoBehaviour
{
    public float timerMax;

    class Baker : Baker<ZombieSpawnerAuthoring>
    {
        public override void Bake(ZombieSpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ZombieSpawner
            {
                timerMax = authoring.timerMax,
            });
        }
    }
}

public struct ZombieSpawner : IComponentData
{
    public float timer;
    public float timerMax;
}