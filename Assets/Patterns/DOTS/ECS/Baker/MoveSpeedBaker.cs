using Unity.Entities;
using UnityEngine;

public class MoveSpeedBaker : Baker<MoveSpeedAuthoring>
{
    public override void Bake(MoveSpeedAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MoveSpeed()
        {
            Value = authoring.Value,
        });
    }
}