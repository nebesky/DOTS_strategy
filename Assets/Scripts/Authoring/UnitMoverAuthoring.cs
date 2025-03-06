using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UnitMoverAuthoring : MonoBehaviour
{
    public float value;

    public class Baker : Baker<UnitMoverAuthoring>
    {
        public override void Bake(UnitMoverAuthoring authoring) 
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            var unit = new UnitMover
            {
                moveSpeed = authoring.value,
                targetPosition = GetComponent<Transform>().position,
            };

            AddComponent(entity, unit);
        }
    }
}

public struct UnitMover : IComponentData
{
    public float moveSpeed;
    public float3 targetPosition;
}