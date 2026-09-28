using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    //Position above player's head
    [SerializeField] private Transform grabPoint;
    //Position above player's head
    [SerializeField] private Transform LeftPoint;
    //Position above player's head
    [SerializeField] private Transform RightPoint;
    //Position above player's head
    [SerializeField] private Transform DownPoint;
    //How far can I grab
    [SerializeField] private float grabRadius = 1.5f;
    //drop object this far from player
    [SerializeField] private float dropOffset = 1.0f;
    //Object layer
    [SerializeField] private LayerMask objectLayer;
    //Variable for movement
    private Vector2 movementInput;

    private GameObject grabbedObject;

    private Boolean rightKey = false;
    private Boolean leftKey = false;
    private Boolean downKey = false;
    private Boolean upKey = false;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (grabbedObject == null)
                TryGrab();
            else
                Drop();
        }

        leftKey = Keyboard.current.aKey.isPressed;
        rightKey = Keyboard.current.dKey.isPressed;
        downKey = Keyboard.current.sKey.isPressed;
        upKey = Keyboard.current.wKey.isPressed;

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
    private void Drop()
    {

        // Places object in front of the direction the player is moving (transform.right)
        grabbedObject.transform.SetParent(null);

        if (leftKey)
        {
            Debug.Log("Dropped item at grab point Left");
            grabbedObject.transform.position = LeftPoint.position;
        }
        else if(rightKey)
        {
            Debug.Log("Dropped item at grab point Right");
            grabbedObject.transform.position = RightPoint.position;
        }
        else if(downKey)
        {
            Debug.Log("Dropped item at grab point Down");
            grabbedObject.transform.position = DownPoint.position;
        }
        else
        {
            Debug.Log("Dropped item at grab point Idle/Up");
            grabbedObject.transform.position = grabPoint.position;
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
