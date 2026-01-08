using UnityEngine;

public abstract class CatalogBase : ScriptableObject, ICatalog
{
    public abstract void Merge(ICatalog other);
}