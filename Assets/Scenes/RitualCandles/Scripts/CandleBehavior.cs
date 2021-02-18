using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleBehavior : MonoBehaviour
{
    public Sprite litSprite;
    private GameObject gameManager;

    private bool lit = false;

    void OnMouseDown()
    {
        gameManager = GameObject.Find("MinigameManager");
        GetComponent<SpriteRenderer>().sprite = litSprite;
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
    }

}
