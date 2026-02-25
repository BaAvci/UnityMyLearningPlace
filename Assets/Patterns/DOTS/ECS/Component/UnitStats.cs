using Unity.Entities;

public struct UnitStats : IComponentData
{
    public float MoveSpeed;
    public float AttackDamage;
    public float Defence; // Flat damage reduction
    public float Health;
    public float MaxHealth;
}
