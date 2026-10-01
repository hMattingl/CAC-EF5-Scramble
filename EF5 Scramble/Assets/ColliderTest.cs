using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderTest : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float grabRadius = 1.5f;
    [SerializeField] private Transform player;
    private int spouse, child, radio, flashL;
    private Boolean inSZ = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

        Renderer rendererPlayer = GetComponent<Renderer>();
        Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position, grabRadius, playerLayer);
        if (hitPlayer!=null)
        {
            inSZ = true;
            InSafeZone();
        }
        Renderer renderer = GetComponent<Renderer>();
        Collider2D hit = Physics2D.OverlapCircle(transform.position, grabRadius, objectLayer);
        if (hit != null)
        {
            if(hit.transform.parent==null)
            renderer.material.color = Color.red;
        }
        else
            renderer.material.color = Color.blue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Make sure its working
        Debug.Log("DETECTED");
        //Make an item labeled other attached to the detected game object and search for an Item class within them
        Item item = other.gameObject.GetComponent<Item>();
        //If our item is filled, and its a wife, and its not parented; log it, destroy, and affirm its accounted for
        if (item != null && item.Type == ItemType.Spouse && other.transform.parent == null)
        {
            //This is pretty funny out of context
            Debug.Log("I detect a spouse");
            ItemInventory(1, 0, 0, 0);
            Destroy(other.gameObject);
            Debug.Log($"{SpouseNum()} spouse(s)");
        }
        //otherwise If our item is filled, and its a child, and its not parented; log it, destroy, and affirm its accounted for
        else if (item != null && item.Type == ItemType.Child && other.transform.parent == null)
        {
            Debug.Log("I detect a child");
            ItemInventory(0, 1, 0, 0);
            Destroy(other.gameObject);
            Debug.Log($"{child} offspring");
        }
        //otherwise If our item is filled, and its a flashlight, and its not parented; log it, destroy, and affirm its accounted for
        else if (item != null && item.Type == ItemType.Flashlight && other.transform.parent == null)
        {
            Debug.Log("I detect a flashlight");
            ItemInventory(0, 0, 0, 1);
            Destroy(other.gameObject);
            Debug.Log($"{flashL} flashlight(s)");
        }
        //otherwise If our item is filled, and its a radio, and its not parented; log it, destroy, and affirm its accounted for
        else if (item != null && item.Type == ItemType.Radio && other.transform.parent == null)
        {
            Debug.Log("I detect a radio");
            ItemInventory(0, 0, 1, 0);
            Destroy(other.gameObject);
            Debug.Log($"{radio} radio(s)");
        }
    }

    private void ItemInventory(int addSpouse, int addChild, int addRadio, int addFl)
    {
        spouse += addSpouse;
        child += addChild;
        radio += addRadio;
        flashL += addFl;
    }

    public Boolean InSafeZone()
    {
        return inSZ;
    }

    //Methods to see how many of any given Items the hiding spot has
    public int SpouseNum() { return spouse; }
    public int ChildNum() { return child; }
    public int RadioNum() { return radio; }
    public int FlashLNum() { return flashL; }
}
