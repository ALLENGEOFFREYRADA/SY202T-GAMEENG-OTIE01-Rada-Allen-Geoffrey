using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleBehavior : MonoBehaviour
{

    private float maxEffectCooldown = 0.2f;
    private float effectCooldown = 0;

    private bool lit = false;

    public GameObject firePrefab;
    public Sprite litSprite;
    private GameObject gameManager;

    void OnMouseDown()
    {
        gameManager = GameObject.Find("MinigameManager");
        if (!lit)
        {
            lit = true;
            gameManager.GetComponent<RitualCandlesManager>().AddLitCandle();
        }
    }
 
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition)) 
            {
                GetComponent<SpriteRenderer>().sprite = litSprite;
                if (!lit)
                {
                    lit = true;
                    gameManager.GetComponent<RitualCandlesManager>().AddLitCandle();
                }
            }
        }

        if (lit)
        {
            effectCooldown += Time.deltaTime;
            if (effectCooldown > maxEffectCooldown)
            {
                Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y + 4f, 0), Quaternion.identity);
                effectCooldown = 0f;
            }
            
        }
    }

}
