using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public sealed class CatalogRegistry
{
    private readonly Dictionary<Type, CatalogBase> catalogs = new Dictionary<Type, CatalogBase>();

    public void Register(CatalogBase catalog)
    {
        catalogs[catalog.GetType()] = catalog;
    }

    public T Get<T>() where T : CatalogBase
    {
        if (catalogs.TryGetValue(typeof(T), out var catalog))
            return (T)catalog;

        throw new Exception($"Catalog of type {typeof(T).Name} not registered");
    }

    public bool TryGet<T>(out T catalog) where T : CatalogBase
    {
        if (catalogs.TryGetValue(typeof(T), out var value))
        {
            catalog = (T)value;
            return true;
        }

        catalog = null;
        return false;
    }
}