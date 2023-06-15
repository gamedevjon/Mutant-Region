using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _rotationSpeed = 360f;
    [SerializeField]
    private Animator _anim;

    private int _punch, _kick;

    private bool _holdingBar = false;

    [SerializeField]
    private List<Item> _inventory = new List<Item>();

    private void OnEnable()
    {
        ItemBehavior.onCollectItem += ItemBehavior_onCollectItem;
    }

    private void OnDisable()
    {
        ItemBehavior.onCollectItem -= ItemBehavior_onCollectItem;
    }


    private void Start()
    {
        if (_anim == null)
            Debug.LogError("Animator Component Not Assigned");
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.RightControl))
            Punch();
        else if (Input.GetKeyDown(KeyCode.RightAlt))
            Kick();
       
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var direction = new Vector2(h, v);

        _anim.SetFloat(_holdingBar == false ? "Move" : "MoveWithBar", Mathf.Abs(direction.magnitude));

        float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        if (h != 0 || v != 0)
        {
            var targetRot = Quaternion.Euler(0f, 0f, angle + 90f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, _rotationSpeed * Time.deltaTime);

        }

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    void Punch()
    {
        _anim.SetTrigger(_holdingBar == false ? "Punch_" + _punch : "Punch_With_Bar_" + _punch );

        _punch++;

        if (_punch > 1)
            _punch = 0;
    }

    void Kick()
    {
        _anim.SetTrigger("Kick_" + _kick);

        _kick++;

        if (_kick > 1)
            _kick = 0;
    }

    private void ItemBehavior_onCollectItem(int itemID)
    {
        //play animation
        _anim.SetTrigger("Pickup_Floor");
        //verify valid item
        Debug.Log("Picked Up: " + itemID);

        if (ItemDatabase.Instance.VerifyItem(itemID) == true)
        {
            var item = ItemDatabase.Instance.GetItem(itemID);
            _inventory.Add(item);
            Debug.Log("Added Item to Inventory: " + itemID);

            //update UI to display item at slot 0
            RadialMenuController.Instance.UpdateInventoryDisplay(item.GetID);
        }

        //equip bar
        _holdingBar = true;
    }
}
