using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class ShootVictimAuthoring : MonoBehaviour
{
    public Transform bulletSpawnPositionTransform;
    
    class Baker : Baker<ShootVictimAuthoring>
    {
        public override void Bake(ShootVictimAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ShootVictim
            {
                hitLocalPosition = authoring.bulletSpawnPositionTransform.localPosition,
            });
        }
    }
}

public struct ShootVictim : IComponentData
{
    public float3 hitLocalPosition;
}