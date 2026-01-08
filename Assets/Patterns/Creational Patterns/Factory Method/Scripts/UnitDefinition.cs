using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Definition/Unit Definition")]
public class UnitDefinition : ScriptableObject
{
    public GameObject Prefab;
    public string Name;

    private void OnValidate()
    {
        if (Prefab == null) return;
        Name = Prefab.name;
    }
}