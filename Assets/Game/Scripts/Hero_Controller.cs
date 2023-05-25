using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private Animator _anim;

    private enum DirectionToFace
    {
        N = 180,
        NE = 135,
        E = 90,
        SE = 45, 
        S = 0,
        SW = -45,
        W = -90,
        NW = -135
    }

    private DirectionToFace _directionToFace = DirectionToFace.S;

    private void Start()
    {
        if (_anim == null)
            Debug.LogError("Animator Component Not Assigned");

       
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var direction = new Vector2(h, v);

        _anim.SetFloat("Move", Mathf.Abs(direction.magnitude));

        //what direction do we face?
        var currentRot = transform.localEulerAngles;

        //check north
        if (v > 0 && h == 0)
            _directionToFace = DirectionToFace.N;
        //check north east
        else if (v > 0 && h > 0)
            _directionToFace = DirectionToFace.NE;
        //check east
        else if (v == 0 && h > 0)
            _directionToFace = DirectionToFace.E;
        //check South east
        else if (v < 0 && h > 0)
            _directionToFace = DirectionToFace.SE;
        //check south
        else if (v < 0 && h == 0)
            _directionToFace = DirectionToFace.S;
        //check south west
        else if (v < 0 && h < 0)
            _directionToFace = DirectionToFace.SW;
        //check west
        else if (v == 0 && h < 0)
            _directionToFace = DirectionToFace.W;
        //check north west
        else if (v > 0 && h < 0)
            _directionToFace = DirectionToFace.NW;

        currentRot.z = (int)_directionToFace;
        transform.localEulerAngles = currentRot;
        
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }
}
