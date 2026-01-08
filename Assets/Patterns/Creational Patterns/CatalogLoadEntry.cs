using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
[Serializable]
public class CatalogLoadEntry
{
    public CatalogBase coreCatalog;
    public AssetReferenceT<CatalogBase> modelCatalog;
}