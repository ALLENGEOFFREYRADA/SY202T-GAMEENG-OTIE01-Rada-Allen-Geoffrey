using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CauldronStirManager : MinigameManager
{

    public GameObject cauldron;
    public Sprite rightCauldron;
    public Sprite leftCauldron;
 
    private bool atRight = true;
    private int stirs = 0;

    public Swipe swipe;
 
    void Start()
    {
        base.Init();
    }

    void Update()
    {
        if (GameManager.paused == true) return;
        if (swipe.swipeLeft && atRight)
        {
            Stir();
        }
        else if (swipe.swipeRight && !atRight)
        {
            Stir();
        }
    }

    void Stir()
    {
        stirs++;
        if (atRight)
        {
            cauldron.GetComponent<SpriteRenderer>().sprite = leftCauldron; 
        }
        else
        {
            cauldron.GetComponent<SpriteRenderer>().sprite = rightCauldron; 
        }
        atRight = !atRight;
        if (stirs == 10)
        {
            base.Win();
        }
    }
}
