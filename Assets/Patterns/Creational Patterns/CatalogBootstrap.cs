using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CatalogBootstrap 
{
    //[SerializeField] private CatalogBootstrapConfig config;

    public async Task<CatalogRegistry> BootstrapAsync(CatalogBootstrapConfig config)
    {
        var registry = new CatalogRegistry();

        foreach (var catalog in config.catalogs)
        {
            if (catalog.modelCatalog == null)
                continue;

            var handle = catalog.modelCatalog.LoadAssetAsync();
            var modCatalog = await handle.Task;
            catalog.coreCatalog.Merge(modCatalog);
            Addressables.Release(handle);

            registry.Register(catalog.coreCatalog);
        }

        return registry;
    }
}