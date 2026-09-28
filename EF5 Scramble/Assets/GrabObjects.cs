using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    //Position above player's head
    [SerializeField] private Transform grabPoint;
    //How far can I grab
    [SerializeField] private float grabRadius = 1.5f;
    //drop object this far from player
    [SerializeField] private float dropOffset = 1.0f;
    //Object layer
    [SerializeField] private LayerMask objectLayer;
    //Variable for movement
    private Vector2 movementInput;

    private GameObject grabbedObject;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (grabbedObject == null)
                TryGrab();
            else
                Drop();
        }

        // Keep grabbed object attached to the grabPoint
        if (grabbedObject != null)
            grabbedObject.transform.position = grabPoint.position;
    }

    private void TryGrab()
    {
        // Detects grabbable objects in all directions within grabRadius
        Collider2D hit = Physics2D.OverlapCircle(transform.position, grabRadius, objectLayer);
        if (hit != null)
        {
            grabbedObject = hit.gameObject;
            Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.zero;
            }
            grabbedObject.transform.SetParent(transform);
        }
    }
    public void OnMove(InputValue value)
    {
        // Read the movement vector (WASD or D-Pad)
        movementInput = value.Get<Vector2>();
        Debug.Log($"Vector2 Value: {movementInput}");
    }
    private void Drop()
    {

        // Places object in front of the direction the player is moving (transform.right)
        grabbedObject.transform.SetParent(null);

        if (movementInput != Vector2.zero)
        {
            // Normalize the vector so diagonal movement drops at the exact same distance as straight lines
            Vector3 dropDirection = new Vector3(movementInput.x, movementInput.y, 0f).normalized;

            // Position = Player Position + (Direction Vector * Offset Distance)
            grabbedObject.transform.position = transform.position + (dropDirection * dropOffset);

            Debug.Log($"Dropped item in direction: {dropDirection}");
        }
        else
        {
            // Fallback: If standing completely still, default to the grabPoint
            grabbedObject.transform.position = grabPoint.position;

            Debug.Log("Dropped item at grab point (Idle)");
        }

        Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.bodyType = RigidbodyType2D.Dynamic;

        grabbedObject = null;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizer circle for grab area in Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRadius);
    }
}
