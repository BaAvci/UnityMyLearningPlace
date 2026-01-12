public class DamageModifier : IChampionModifier
{
    private readonly float outgoingDamageIncreaseModifier;
    private readonly float incomingDamageIncreaseModifier;

    public DamageModifier(float outgoing, float incoming)
    {
        outgoingDamageIncreaseModifier = outgoing;
        incomingDamageIncreaseModifier = incoming;
    }

    public void Apply(Champion champion)
    {
        champion.ApplyDamageModifiers(outgoingDamageIncreaseModifier, incomingDamageIncreaseModifier);
    }
}