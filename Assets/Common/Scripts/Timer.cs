using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public Sprite[] sprites;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(ChangeSprite());
    }

    IEnumerator ChangeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[1];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[2];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[3];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[4];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[5];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[6];
        yield return new WaitForSecondsRealtime(0.625f);
        spriteRenderer.sprite = sprites[7];
        yield return new WaitForSecondsRealtime(0.625f);
        Destroy(gameObject);
    }
}
