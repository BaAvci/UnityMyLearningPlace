using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct UnitMoverSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (localTransform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
        {
            var targetPosition = localTransform.ValueRO.Position + new float3(10, 0, 0);
            var moveDirection = targetPosition - localTransform.ValueRO.Position;
            moveDirection = math.normalizesafe(moveDirection);

            localTransform.ValueRW.Rotation = quaternion.LookRotation(moveDirection, math.up());
            localTransform.ValueRW.Position += moveDirection * moveSpeed.ValueRO.Value * SystemAPI.Time.DeltaTime;
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
}