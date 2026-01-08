using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Unit : MonoBehaviour, IMovement
{
    protected float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected float moveDistance = 20;
    protected Vector3 tragetPosition;

    protected virtual void Start()
    {
        Debug.Log($"{gameObject.name} has been spawned");
        tragetPosition = transform.position;
        Initialize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!Keyboard.current.spaceKey.wasPressedThisFrame) return;
        Move();
    }

    protected abstract void Initialize();

    public abstract void Move();
}