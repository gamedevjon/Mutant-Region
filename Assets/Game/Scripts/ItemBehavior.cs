using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _itemID = -1;

    public static event Action<int> onCollectItem;

    public void Interact()
    {
        //collect this item
        onCollectItem?.Invoke(_itemID);
        Destroy(this.gameObject, 0.3f);
    }

    
}
