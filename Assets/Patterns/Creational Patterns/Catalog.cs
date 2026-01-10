using System.Collections.Generic;
using UnityEngine;

public class Catalog<T> : CatalogBase
{
    [SerializeField] protected List<T> entries;
    public IReadOnlyList<T> Entries => entries;

    public override void Merge(ICatalog other)
    {
        switch (other)
        {
            case null:
                return;
            case Catalog<T> typed:
                entries.AddRange(typed.Entries);
                break;
            default:
                Debug.LogError($"Tried to merge incompatible catalog types: {other}");
                break;
        }
    }
}