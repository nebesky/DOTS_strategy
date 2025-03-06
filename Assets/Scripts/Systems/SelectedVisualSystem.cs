using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(LateSimulationSystemGroup))]
[UpdateBefore(typeof(ResetEventSystem))]
partial struct SelectedVisualSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRO<Selected> selected in SystemAPI.Query<RefRO<Selected>>().WithPresent<Selected>())
        {
            if (selected.ValueRO.onSelected && selected.ValueRO.onDeselected)
                continue;
            
            if (selected.ValueRO.onSelected)
            {
                RefRW<LocalTransform> visualLocalTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.VisualEntity);
                visualLocalTransform.ValueRW.Scale = selected.ValueRO.Scale;
            }
            
            if (selected.ValueRO.onDeselected)
            {
                RefRW<LocalTransform> visualLocalTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.VisualEntity);
                visualLocalTransform.ValueRW.Scale = 0f;
            }
        }
    }
}