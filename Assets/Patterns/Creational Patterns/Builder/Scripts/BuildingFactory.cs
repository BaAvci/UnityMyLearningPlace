using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingFactory : ICreationFactory
{
    private readonly BuildingCatalog buildingCatalog;
    private List<Unit> createdBuildings = new List<Unit>();

    public BuildingFactory(CatalogRegistry catalogRegistry)
    {
        buildingCatalog = catalogRegistry.Get<BuildingCatalog>();
    }

    public void Create(string buildingName)
    {
        var selectedBuilding = buildingCatalog.Entries.FirstOrDefault(e => e.name == buildingName)?.Prefab;
        if (selectedBuilding is not null)
        {
            var gameObject = GameObject.Instantiate(selectedBuilding, Vector3.zero, Quaternion.identity);
            createdBuildings.Add(gameObject.GetComponent<Unit>());
        }
    }
}