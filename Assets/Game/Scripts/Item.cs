using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private string _itemDescription;

    private Inventory _heroInventory;
    private Animator _anim;

    void Start()
    {
        _heroInventory = GameObject.FindObjectOfType<HeroController>().GetComponent<Inventory>();
        _anim = _heroInventory.GetComponent<Animator>();
    }

    public void Interact()
    {
        //pickup item and add to Inventory
        _anim.SetTrigger("Pickup_Floor");
        _heroInventory.AddItem(this);
        Destroy(this.gameObject, 0.4f);
    }
}
