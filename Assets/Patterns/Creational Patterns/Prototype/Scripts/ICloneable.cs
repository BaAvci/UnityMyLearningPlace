using UnityEngine;

public interface ICloneable<T>
{
    /// <summary>
    /// Clones the object with modifiers. Sidenote: This should be a copy of the Dota 2 mechanic that creates illusions of heroes.
    /// </summary>
    /// <param name="cloneAmount">The amount of clones that should be created</param>
    /// <param name="outgoingDamageIncrease">The amount of damage the clone does to other objects</param>
    /// <param name="incomingDamageIncrease">The amount of damage the clone receives from other objects</param>
    public T Clone(int cloneAmount, float outgoingDamageIncrease,float incomingDamageIncrease);
}
