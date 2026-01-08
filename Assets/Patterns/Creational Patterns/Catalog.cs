using System.Collections.Generic;
using UnityEngine;

public class Catalog<T> : CatalogBase
{
    [SerializeField] protected List<T> entries;
    public IReadOnlyList<T> Entries => entries;
    public override void Merge(ICatalog other)
    {
        if  (other is Catalog<T> typed)
        {
            entries.AddRange(typed.Entries);
        }
        else
        {
            Debug.LogError($"Tried to merge incompatible catalog types: {other}");
        }
    }
}