using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{

    public float maxTimeLeft = 1f;
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
        if (GameManager.paused == true) return;
        gameManager.GetComponent<CatchingChickensManager>().RemoveChicken();
        Destroy(gameObject);
    }
 
    void Update()
    {
        if (GameManager.paused == true) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed));
            timeLeft = maxTimeLeft;
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
