using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class BuildingFactory : ICreationFactory
{
    private readonly BuildingCatalog buildingCatalog;

    public BuildingFactory(CatalogRegistry catalogRegistry)
    {
        buildingCatalog = catalogRegistry.Get<BuildingCatalog>();
    }

    [CanBeNull]
    public GameObject Create(string buildingName)
    {
        var selectedBuilding = buildingCatalog.Entries.FirstOrDefault(e => e.name == buildingName)?.Prefab;
        if (selectedBuilding is not null)
        {
            return GameObject.Instantiate(selectedBuilding, Vector3.zero, Quaternion.identity);
        }
        return null;
    }
}