using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class RadialMenuController : MonoBehaviour
{
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
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _menuActive = !_menuActive;
            _menu.SetActive(_menuActive);
        }

        if (_menuActive == true)
        {
            //calculate angle of the mouse for inventory selection
            //grab the difference from the center of the radius to the mouse position
            var delta = _radialCenter.position - Input.mousePosition;
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            angle += 180;
            //Debug.Log("Angle: " + angle);
  
            int _activeSlot = 0;

            for(int i = 0; i < 360; i+=30)
            {
                if (angle >= i && angle < i + 30)
                {
                    _selectImage.eulerAngles = new Vector3(0, 0, i -90);
                    _text.text = ""+_activeSlot;
                }
                _activeSlot++;

            }
        }
    }
}
