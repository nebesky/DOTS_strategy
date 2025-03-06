using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct ZombieSpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntitiesReferences entitiesReferences = SystemAPI.GetSingleton<EntitiesReferences>();
        
        foreach ((
            RefRO<LocalTransform> localTransform, 
            RefRW<ZombieSpawner> zombieSpawner) in 
                 SystemAPI.Query<
                     RefRO<LocalTransform>, 
                     RefRW<ZombieSpawner>>())
        {
            zombieSpawner.ValueRW.timer -= SystemAPI.Time.DeltaTime;
            if (zombieSpawner.ValueRW.timer > 0f) continue;
            zombieSpawner.ValueRW.timer = zombieSpawner.ValueRW.timerMax;

            Entity zombieEntity = state.EntityManager.Instantiate(entitiesReferences.zombiePrefabEntity);
            SystemAPI.SetComponent(zombieEntity, LocalTransform.FromPosition(localTransform.ValueRO.Position));
            
        }

    }
}
