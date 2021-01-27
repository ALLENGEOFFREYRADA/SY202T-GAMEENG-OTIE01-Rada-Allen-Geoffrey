using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRandomIngredientSprite : MonoBehaviour
{
    
    public Sprite[] sprites;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

}
