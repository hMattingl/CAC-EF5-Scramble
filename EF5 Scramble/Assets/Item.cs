using UnityEngine;

public enum ItemType
{
    Spouse,
    Flashlight,
    Child,
    Radio,
    Boardgames
}

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    public ItemType Type => itemType;
}

