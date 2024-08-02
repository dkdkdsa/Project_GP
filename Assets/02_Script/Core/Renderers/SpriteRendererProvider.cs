using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererProvider : MonoBehaviour, IRenderer
{

    private SpriteRenderer _renderer;

    private void Awake()
    {
        
        _renderer = GetComponent<SpriteRenderer>();

    }

    public bool2 GetFlip()
    {

        return new bool2( _renderer.flipX, _renderer.flipY );

    }

    public void SetFlip(bool2 flip)
    {

        _renderer.flipX = flip.x;
        _renderer.flipY = flip.y;

    }

}
