using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    //Position above player's head
    [SerializeField] private Transform grabPoint;
    //Position to player right
    [SerializeField] private Transform RightDrop;
    //Position of player's bottom
    [SerializeField] private Transform DownDrop;
    //Position to player left
    [SerializeField] private Transform LeftDrop;
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

        // Places object in front of the direction the player is facing (transform.right)
        if (movementInput.x < 0f)
        {
            grabbedObject.transform.position = LeftDrop.transform.position;
        }
        else if (movementInput.x > 0f)
        {
            grabbedObject.transform.position = RightDrop.transform.position;
        }
        else if (movementInput.y < 0f)
        {
            grabbedObject.transform.position = DownDrop.transform.position;
        }
        else
        {
            grabbedObject.transform.position = grabPoint.transform.position;
        }

        grabbedObject.transform.SetParent(null);

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
