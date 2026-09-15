using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint; // Position above player's head
    [SerializeField] private float grabRadius = 1.5f;
    [SerializeField] private float dropOffset = 1.0f;
    [SerializeField] private LayerMask objectLayer;

    private GameObject grabbedObject;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (grabbedObject == null)
            {
                TryGrab();
            }
            else
            {
                Drop();
            }
        }

        // Keep grabbed object attached to the grabPoint
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPoint.position;
        }
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

    private void Drop()
    {
        grabbedObject.transform.SetParent(null);

        // Places object in front of the direction the player is facing (transform.right)
        grabbedObject.transform.position = transform.position + (transform.right * dropOffset);

        Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        grabbedObject = null;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizer circle for grab area in Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRadius);
    }
}
