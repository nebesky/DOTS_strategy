using Unity.Entities;
using UnityEngine;

class UnitAuthoring : MonoBehaviour
{
    public Faction Faction;
    class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Unit {
                faction = authoring.Faction });
        }
    }
}

public struct Unit : IComponentData
{
    public Faction faction;
}


