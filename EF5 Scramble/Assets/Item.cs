using UnityEngine;

public enum ItemType
{
    Wife,
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

