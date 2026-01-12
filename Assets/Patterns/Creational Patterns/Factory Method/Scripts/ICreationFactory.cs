using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public interface ICreationFactory
{
    [CanBeNull] public GameObject Create(string buildingName);
}