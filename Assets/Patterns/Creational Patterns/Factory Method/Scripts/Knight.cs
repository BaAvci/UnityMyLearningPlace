using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : Unit
{
    public override void Move()
    {
        tragetPosition = transform.position + new Vector3(0, 0, moveDistance);
    }

    protected override void Initialize()
    {
        moveSpeed = 7.5f;
    }
    protected override void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    Move();
        //}
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, tragetPosition, moveSpeed * Time.deltaTime);
    }
}
