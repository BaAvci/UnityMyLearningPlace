using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class UnitFactory : ICreationFactory
{
    private readonly UnitCatalog catalog;

    public UnitFactory(CatalogRegistry catalogRegistry)
    {
        catalog = catalogRegistry.Get<UnitCatalog>();
    }

    [CanBeNull]
    public GameObject Create(string unitName)
    {
        var selectedUnit = catalog.Entries.FirstOrDefault(e => e.name == unitName).Prefab;
        if (selectedUnit is not null)
        {
            return GameObject.Instantiate(selectedUnit, Vector3.zero, Quaternion.identity);
        }

        return null;
    }
}