using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private SpriteRenderer _shadowSprite;
    private SpriteRenderer _parentSprite;
    [SerializeField]
    private Vector2 _offSet = new Vector2(-0.1f, -0.1f);

    // Start is called before the first frame update
    void Start()
    {
        _shadowSprite = GetComponent<SpriteRenderer>();
        _parentSprite = transform.parent.GetComponent<SpriteRenderer>();

        _shadowSprite.transform.localPosition = _offSet;
        _shadowSprite.transform.localRotation = Quaternion.identity;

        _shadowSprite.sprite = _parentSprite.sprite;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _shadowSprite.transform.localPosition = Quaternion.Inverse(_parentSprite.transform.rotation) * -(_offSet);
        

        if (_shadowSprite.sprite != _parentSprite.sprite)
            _shadowSprite.sprite = _parentSprite.sprite;
    }
}