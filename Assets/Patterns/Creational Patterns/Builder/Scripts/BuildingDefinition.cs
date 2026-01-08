using UnityEngine;

[CreateAssetMenu(menuName = "Game/Definition/Building Definition")]
public class BuildingDefinition : ScriptableObject
{
    public GameObject Prefab;
    public string Name;

    private void OnValidate()
    {
        if (Prefab == null) return;
        Name = Prefab.name;
    }
}