using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Sprite _offIcon;
    [SerializeField]
    private Sprite _activeIcon;
    [SerializeField]
    private Image _iconImg;


   

    public void Activate()
    {
        _iconImg.sprite = _activeIcon;
        Debug.Log("Activate Called() ");
    }
}
