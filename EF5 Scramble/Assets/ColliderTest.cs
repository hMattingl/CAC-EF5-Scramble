using UnityEngine;
using UnityEngine.UIElements;

public class ColliderTest : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float grabRadius = 1.5f;
    private int wife, child, radio, flashL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {

        Renderer renderer = GetComponent<Renderer>();
        Collider2D hit = Physics2D.OverlapCircle(transform.position, grabRadius, objectLayer);
        if (hit != null)
        {
            if(hit.transform.parent==null)
            renderer.material.color = Color.red;
        }
        if (hit == null)
        {
            renderer.material.color = Color.blue;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DETECTED");
        Item item = other.gameObject.GetComponent<Item>();
        if (item != null && item.Type == ItemType.Wife && other.transform.parent == null)
        {
            //This is pretty funny out of context
            Debug.Log("I detect a wife");
            ItemInventory(1, 0, 0, 0);
            Destroy(other.gameObject);
            WifeNum();
        }
        else if (item != null && item.Type == ItemType.Child && other.transform.parent == null)
        {
            Debug.Log("I detect a child");
            ItemInventory(0, 1, 0, 0);
            Destroy(other.gameObject);
            ChildNum();
        }
        else if (item != null && item.Type == ItemType.Flashlight && other.transform.parent == null)
        {
            Debug.Log("I detect a flashlight");
            ItemInventory(0, 0, 0, 1);
            Destroy(other.gameObject);
            FlashLNum();
        }
        else if (item != null && item.Type == ItemType.Radio && other.transform.parent == null)
        {
            Debug.Log("I detect a radio");
            ItemInventory(0, 0, 1, 0);
            Destroy(other.gameObject);
            RadioNum();
        }
    }

    private void ItemInventory(int addWife, int addChild, int addRadio, int addFl)
    {
        wife += addWife;
        child += addChild;
        radio += addRadio;
        flashL += addFl;
    }

    //Methods to see how many of any given Items the hiding spot has
    public void WifeNum() { Debug.Log($"{wife} wife(s)"); }
    public void ChildNum() { Debug.Log($"{child} offspring"); }
    public void RadioNum() { Debug.Log($"{radio} radio(s)"); }
    public void FlashLNum() { Debug.Log($"{flashL} flashlight(s)"); }
}
