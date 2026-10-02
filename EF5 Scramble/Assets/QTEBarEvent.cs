using UnityEngine;
using UnityEngine.InputSystem;

public class QTEBarEvent : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    public Vector2 movementInput;

    [SerializeField] private ChangeColor targetScriptReference;

    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInput = Vector2.left;

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && targetScriptReference.inArea=="true")
        {
            score += 1;

            Debug.Log($"{score} Point(s)");
            if (score <= 2)
            {
                movementInput *= score;
            }
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame && targetScriptReference.inArea == "false")
        {
            score *= 0;
            Debug.Log($"{score} Point(s)");
            movementInput *= 0;
            if (targetScriptReference.currentDirection == "left")
                movementInput = Vector2.left;
            else movementInput = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, movementInput.y * moveSpeed);
    }
}
