using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RadialMenuController : MonoBehaviour
{
    private static RadialMenuController _instance;
    public static RadialMenuController Instance
    {
        get
        {
            return _instance;
        }
    }


    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private Transform _radialCenter;
    [SerializeField]
    private Transform _selectImage;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private bool _menuActive = false;
    [SerializeField]
    private GameObject _min, _max;
    bool _outOfBounds = false;

    [SerializeField]
    private Slot[] _slots;


    private void Awake()
    {
        _instance = this;
    }

    public void UpdateInventoryDisplay(int itemID)
    {
        _slots[itemID].Activate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _menuActive = !_menuActive;
            _menu.SetActive(_menuActive);
        }

        if (_menuActive == true)
        {
            //only work if within radius 
            
            if (Vector3.Distance(Input.mousePosition, _radialCenter.position) < Vector3.Distance(_max.transform.position, _radialCenter.position)
                && Vector3.Distance(Input.mousePosition, _radialCenter.position) > Vector3.Distance(_min.transform.position, _radialCenter.position))
            {
                if (_outOfBounds == true)
                {
                    _outOfBounds = false;
                    _selectImage.gameObject.SetActive(true);
                }
                //calculate angle of the mouse for inventory selection
                //grab the difference from the center of the radius to the mouse position
                var delta = _radialCenter.position - Input.mousePosition;
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
                angle += 180;
                //Debug.Log("Angle: " + angle);

                int _activeSlot = 0;

                for (int i = 0; i < 360; i += 30)
                {
                    if (angle >= i && angle < i + 30)
                    {
                        _selectImage.eulerAngles = new Vector3(0, 0, i - 90);
                        //_text.text = "" + _slots[_activeSlot].sprite.name;

                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Selected " + _activeSlot);
                        }
                    }
                    _activeSlot++;
                }
            }
            else
            {
                _selectImage.gameObject.SetActive(false);
                _outOfBounds = true;
            }
        }
    }
}
