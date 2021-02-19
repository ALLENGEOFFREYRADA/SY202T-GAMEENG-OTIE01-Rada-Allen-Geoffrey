using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{

    public float accelerationTime = 5f;
    public float maxSpeed = 10f;
    private Vector2 movement;
    private float timeLeft;

    private Rigidbody2D rb2d;
    private GameObject gameManager;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("MinigameManager");
    }

    void OnMouseDown()
    {
        if (Time.timeScale == 0) return;
        gameManager.GetComponent<CatchingChickensManager>().RemoveChicken();
        Destroy(gameObject);
    }
 
    void Update()
    {
        if (Time.timeScale == 0) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition)) 
                {
                    gameManager.GetComponent<CatchingChickensManager>().RemoveChicken();
                    Destroy(gameObject);
                }
            }
        }      
    }

    void FixedUpdate()
    {
        rb2d.AddForce(movement * maxSpeed);
    }
}
