using UnityEngine;
using UnityEngine.UIElements;

public class ColliderTest : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float grabRadius = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

            Item item = other.gameObject.GetComponent<Item>();
            if (item != null && item.Type == ItemType.Wife)
            {
                //This is pretty funny out of context
                Debug.Log("I detect a wife");
            }
            else if (item != null && item.Type == ItemType.Child)
            {
                Debug.Log("I detect a child");
            }
            else if (item != null && item.Type == ItemType.Radio)
            {
                Debug.Log("I detect a radio");
            }
            else
                Debug.Log("I detect a flashlight");
        }
        else
            renderer.material.color = Color.blue;
    }

}
