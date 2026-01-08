using UnityEngine;

public abstract class Item : IItem
{
    public abstract void Use(Champion owner);
}