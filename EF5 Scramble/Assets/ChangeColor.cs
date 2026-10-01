using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private LayerMask defaultLayer;
    [SerializeField] private float grabRadius = 1.5f;
    [SerializeField] private QTEBarEvent targetScriptReference;
    public string inArea = "false";
    public string layerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (layerName=="Default")
        {
            Renderer renderer = GetComponent<Renderer>();
            Collider2D hit = Physics2D.OverlapCircle(transform.position, grabRadius, defaultLayer);
            if (hit == null)
            {
                renderer.material.color = Color.red;
                inArea = "false";
            }
            else
            {
                renderer.material.color = Color.green;
                inArea = "true";
            }
        }
        if (layerName=="Objects")
        {
            Renderer renderer = GetComponent<Renderer>();
            Collider2D hit = Physics2D.OverlapCircle(transform.position, grabRadius, defaultLayer);
            if (hit != null)
            {
                targetScriptReference.movementInput *= -1;
            }
        }
    }
    // Pass the specific object into the method
    public void CheckMyLayer(GameObject targetObject)
    {
        // Use targetObject instead of gameObject
        string layerName = LayerMask.LayerToName(targetObject.layer);
        Debug.Log("Layer Name: " + layerName);
    }
}
