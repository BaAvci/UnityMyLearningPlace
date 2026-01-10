using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputs : MonoBehaviour
{
    public InputActionAsset inputSystem;

    private List<CreationMode> creationModes = new();
    private CreationMode currentMode;
    private int currentMapIndex = 0;
    private InputAction nextAction;
    private InputAction previousAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Awake()
    {
        var type = typeof(ICreationFactory);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

        nextAction = inputSystem.FindActionMap("Player").FindAction("Next");
        previousAction = inputSystem.FindActionMap("Player").FindAction("Previous");
        var catalogConfig = await Addressables.LoadAssetAsync<CatalogBootstrapConfig>("Catalog").Task;
        var catalogRegistry = await new CatalogBootstrap().BootstrapAsync(catalogConfig);
        
        foreach (var map in inputSystem.actionMaps)
        {
            if (map.name.Contains("Creation"))
            {
                var factoryName = map.name.Replace("Creation", "Factory");
                var foundFactory = types.FirstOrDefault(f => f.Name == factoryName);
                if (foundFactory == null) continue;
                if (Activator.CreateInstance(foundFactory,catalogRegistry) is not ICreationFactory factory) continue;
                creationModes.Add(new CreationMode()
                {
                    Factory = factory,
                    InputActionMap = map
                });
            }
        }

        currentMapIndex = 0;
        currentMode = creationModes[currentMapIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAction.WasPressedThisFrame())
        {
            currentMapIndex++;
        }
        else if (previousAction.WasPressedThisFrame())
        {
            currentMapIndex--;
        }

        if (currentMapIndex >= creationModes.Count)
        {
            currentMapIndex = 0;
            currentMode = creationModes[currentMapIndex];
        }
        else if (currentMapIndex < 0)
        {
            currentMapIndex = creationModes.Count - 1;
            currentMode = creationModes[currentMapIndex];
        }

        if (currentMode == null) return;

        foreach (var action in currentMode.InputActionMap.actions.Where(action => action.WasPressedThisFrame()))
        {
            currentMode.Factory.Create(action.name);
        }
    }
}