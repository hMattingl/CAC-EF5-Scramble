using UnityEngine;
using UnityEngine.UIElements;

public class ColliderTest : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float grabRadius = 1.5f;
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

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();

        if (item != null && item.Type == ItemType.Wife)
        {
            Debug.Log("I detect a wife");
        }
    }

}
