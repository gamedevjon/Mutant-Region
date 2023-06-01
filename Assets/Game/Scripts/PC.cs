using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Animator _anim;

    void Start()
    {
        _anim = GameObject.FindObjectOfType<HeroController>().GetComponent<Animator>();
    }

    public void Interact()
    {
        _anim.SetTrigger("Interaction_Computer");  
    }
}
