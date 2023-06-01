using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private HeroController _hero;

    private void Start()
    {
        _hero = GameObject.FindObjectOfType<HeroController>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.0f, 1 << 6);
        Debug.DrawRay(transform.position, transform.up, Color.magenta );

        if (hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
                hit.collider.GetComponent<IInteractable>().Interact();
        }
    }
}
