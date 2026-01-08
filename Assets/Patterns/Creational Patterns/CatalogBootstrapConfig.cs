using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Bootstrap/Catalog Bootstrap Config")]
public class CatalogBootstrapConfig : ScriptableObject
{
    public List<CatalogLoadEntry> catalogs;
}