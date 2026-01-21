using System;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    private Vector2 fieldSize;
    [SerializeField, Range(1, 200)] private float fieldSizeX;
    [SerializeField, Range(1, 200)] private float fieldSizeY;

    [SerializeField] private GameObject testPrefab;

    [SerializeField] private List<GameObject> createdObjects;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fieldSize = new Vector2(fieldSizeX, fieldSizeY);
        var prefabSize = testPrefab.GetComponent<MeshRenderer>().bounds.size;
        var unitAmount = CalculateUnitAmount(prefabSize);
        CreateObjects(unitAmount.x * unitAmount.y);
        MoveToFormationPosition(unitAmount);
    }

    private void CreateObjects(int unitAmount)
    {
        for (int i = 0; i < unitAmount; i++)
        {
            createdObjects.Add(Instantiate(testPrefab, testPrefab.transform.position, Quaternion.identity));
        }
    }

    private void MoveToFormationPosition(Vector2Int unitAmount)
    {
        var xUnitSizeSpaced = fieldSize.x / unitAmount.x;
        var zUnitSizeSpaced = fieldSize.y / unitAmount.y;

        var index = 0;
        for (int i = 0; i < unitAmount.x; i++)
        {
            float xSpacing = xUnitSizeSpaced;
            float xPos = 0;
            if (i == 0)
            {
                xSpacing = xUnitSizeSpaced * 0.5f;
                xPos += xSpacing;
            }
            else
            {
                xPos = createdObjects[index - unitAmount.y].transform.position.x + xSpacing;
            }

            for (int j = 0; j < unitAmount.y; j++)
            {
                float zSpacing = zUnitSizeSpaced;
                float zPos = 0;
                if (j == 0)
                {
                    zSpacing = zUnitSizeSpaced * 0.5f;
                    zPos += zSpacing;
                }
                else
                {
                    zPos = createdObjects[index - 1].transform.position.z + zSpacing;
                }

                createdObjects[index].transform.position =
                    new Vector3(xPos, testPrefab.transform.position.y, zPos);
                index++;
            }
        }
    }

    private Vector2Int CalculateUnitAmount(Vector3 prefabSize)
    {
        Vector2Int unitAmount = Vector2Int.zero;
        unitAmount.x = Mathf.FloorToInt(fieldSize.x / (prefabSize.x + 1));
        unitAmount.y = Mathf.FloorToInt(fieldSize.y / (prefabSize.z + 1));
        return unitAmount;
    }

    private void OnValidate()
    {
        fieldSize = new Vector2(fieldSizeX, fieldSizeY);
        var prefabSize = testPrefab.GetComponent<MeshRenderer>().bounds.size;
        var unitAmount = CalculateUnitAmount(prefabSize);

        if (createdObjects.Count != unitAmount.x * unitAmount.y)
        {
            foreach (var prefab in createdObjects)
            {
                UnityEditor.EditorApplication.delayCall += () => { DestroyImmediate(prefab); };
            }

            createdObjects.Clear();
            if (unitAmount.x <= 0 || unitAmount.y <= 0)
            {
                return;
            }

            CreateObjects(unitAmount.x * unitAmount.y);
            MoveToFormationPosition(unitAmount);
        }
    }
}