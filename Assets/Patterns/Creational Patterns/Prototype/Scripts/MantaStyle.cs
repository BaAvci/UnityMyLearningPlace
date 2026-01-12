using UnityEngine;

public class MantaStyle : Item
{
    private int cloneCount = 2;
    private float outgoingDamageMultiplier = 0.33f;
    private float incomingDamageMultiplier = 3f;
    private float spacing = 2f;

    public override void Use(Champion owner)
    {
        for (int i = 0; i < cloneCount; i++)
        {
            var clone = owner.Clone();
            clone.ApplyModifier(new DamageModifier(outgoingDamageMultiplier,incomingDamageMultiplier));
            clone.ApplyCloneVisuals();
            clone.transform.position = owner.transform.position + new Vector3(spacing * (i + 1), 0, spacing * (i + 1));
        }
    }
}