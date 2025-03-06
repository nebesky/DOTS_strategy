using Unity.Entities;
using UnityEngine;

public class SelectUnitAuthoring : MonoBehaviour
{
    public GameObject VisualGameObject;
    public float VisualScale;
    class Baker : Baker<SelectUnitAuthoring>
    {
        public override void Bake(SelectUnitAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Selected
            {
                VisualEntity = GetEntity(
                    authoring.VisualGameObject, 
                    TransformUsageFlags.Dynamic),
                Scale = authoring.VisualScale,
            });

            SetComponentEnabled<Selected>(entity, false);
        }
    }
}

public struct Selected : IComponentData, IEnableableComponent
{
    public Entity VisualEntity;
    public float Scale;

    public bool onSelected;
    public bool onDeselected;
}