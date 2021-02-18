using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CauldronStirManager : MonoBehaviour
{

    public GameObject cauldron;
    public Sprite rightCauldron;
    public Sprite leftCauldron;
 
    private bool atRight = true;
    private int stirs = 0;

    private GameObject gameManager;
    public Swipe swipe;
 
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
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
            gameManager.GetComponent<GameManager>().progress++;
            SceneManager.LoadScene(sceneName:"TransitionScene");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1f);
        yield return new WaitForSecondsRealtime(5f);
        gameManager.GetComponent<GameManager>().health--;
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }

}
