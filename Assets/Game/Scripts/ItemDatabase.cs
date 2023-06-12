using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private static ItemDatabase _instance;
    public static ItemDatabase Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    private List<Item> _items;

    private void Awake()
    {
        _instance = this;
    }

    public bool VerifyItem(int itemID)
    {
        return _items.Any(x => x.GetID == itemID);
    }

    public Item GetItem(int itemID)
    {
        return _items.First(x => x.GetID == itemID);
    }
}
