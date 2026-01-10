using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class UnitFactory : ICreationFactory
{
    private readonly UnitCatalog catalog;
    private List<Unit> _createdUnits = new();

    public UnitFactory(CatalogRegistry catalogRegistry)
    {
        catalog = catalogRegistry.Get<UnitCatalog>();
    }

    public void Create(string unitName)
    {
        var selectedUnit = catalog.Entries.FirstOrDefault(e => e.name == unitName).Prefab;
        if (selectedUnit is not null)
        {
            var gameObject = GameObject.Instantiate(selectedUnit, Vector3.zero, Quaternion.identity);
            _createdUnits.Add(gameObject.GetComponent<Unit>());
        }
    }
}