using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 movementInput;

    public InputActionReference move;

    private void OnEnable()
    {
        if (move != null && move.action != null) move.action.Enable();
    }
    private void OnDisable()
    {
        if (move != null && move.action != null) move.action.Disable();
    }

    void Update()
    {
        movementInput = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed);
    }
}
