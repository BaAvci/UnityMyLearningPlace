using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A Unit that has a sway when walking.
/// </summary>
public class Drunkard : Unit
{
    private readonly List<Vector3> targetPositions = new();
    private readonly int swaySteps = 5;
    private int targetIndex;
    public override void Move()
    {
        targetPositions.Clear();
        Vector3 targetposition = transform.position + new Vector3(0, 0, moveDistance);
        float swayDistance = moveDistance / swaySteps;
        int pointAmount = (int)swayDistance;

        float direction = 0.5f;
        Vector3 swayPosition = transform.position + new Vector3(direction, 0, swayDistance);
        targetPositions.Add(swayPosition);
        bool swayDirection = true; // true == right | false == left;
        for (int i = 1; i < pointAmount; i++)
        {
            direction = swayDirection ? -1 : 1;
            swayPosition = targetPositions[i - 1] + new Vector3(direction, 0, swayDistance);
            targetPositions.Add(swayPosition);
            swayDirection = !swayDirection;
        }
        targetPositions.Add(targetposition);
        targetIndex = 0;
        tragetPosition = targetPositions[targetIndex];
    }

    protected override void Initialize()
    {
        moveSpeed = 4.5f;
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, tragetPosition) < 0.001f)
        {
            targetIndex++;
            if (targetIndex >= targetPositions.Count)
            {
                return;
            }
            tragetPosition = targetPositions[targetIndex];
        }
        transform.position = Vector3.MoveTowards(transform.position, tragetPosition, moveSpeed * Time.deltaTime);
    }
}
