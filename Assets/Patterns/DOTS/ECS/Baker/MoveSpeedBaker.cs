using Unity.Entities;
using UnityEngine;

public class MoveSpeedBaker : Baker<UnitStatAuthoring>
{
    public override void Bake(UnitStatAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new UnitStats()
        {
            MoveSpeed = authoring.MoveSpeed,
        });
    }
}