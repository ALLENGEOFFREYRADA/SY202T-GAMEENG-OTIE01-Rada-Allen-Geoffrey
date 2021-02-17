using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CauldronStirManager : MonoBehaviour
{

    public GameObject cauldron;
    public Sprite rightCauldron;
    public Sprite leftCauldron;

    private Vector3 firstClick;
    private Vector3 lastClick;

    private Vector3 firstTouch;   
    private Vector3 lastTouch;   
    private float dragDistance = 3f;  

    private bool atRight = true;
    private int stirs = 0;

    private GameObject gameManager;
 
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount == 1) 
            {
                Touch touch = Input.GetTouch(0); 
                switch (touch.phase)
                {
                case TouchPhase.Began:
                    firstTouch = touch.position;
                    lastTouch = touch.position;
                    break;

                case TouchPhase.Moved:                   
                    lastTouch = touch.position;

                    break;

                case TouchPhase.Ended:
                    lastTouch = touch.position;  
    
                    if (Mathf.Abs(lastTouch.x - firstTouch.x) > dragDistance || Mathf.Abs(lastTouch.y - firstTouch.y) > dragDistance)
                    {
                        if (Mathf.Abs(lastTouch.x - firstTouch.x) > Mathf.Abs(lastTouch.y - firstTouch.y))
                        { 
                            if ((lastTouch.x > firstTouch.x) && atRight)  
                            {  
                                Stir();
                            }
                            else if ((lastClick.x < firstClick.x) && atRight)
                            { 
                                Stir();
                            }
                        }
                    }
                    break;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                if (Mathf.Abs(lastClick.x - firstClick.x) > dragDistance || Mathf.Abs(lastClick.y - firstClick.y) > dragDistance)
                {
                    if (Mathf.Abs(lastClick.x - firstClick.x) > Mathf.Abs(lastClick.y - firstClick.y))
                    { 
                        if ((lastClick.x > firstClick.x) && !atRight)  
                        {  
                            Stir();
                        }
                        else if ((lastClick.x < firstClick.x) && atRight)
                        { 
                            Stir();
                        }
                    }
                }
            }
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
        yield return new WaitForSeconds(5f);
        gameManager.GetComponent<GameManager>().health--;
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }

}
