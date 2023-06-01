using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> _items = new List<Item>();

    public void AddItem(Item item)
    {
        var newItem = item;
        _items.Add(newItem);
    }
}
