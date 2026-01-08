using UnityEngine;

public class MantaStyle : Item
{
    public override void Use(Champion owner)
    {
        owner.Clone(2, 0.33f, 3);
    }
}