using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public Vector2 swipeDelta { get; private set; }
    public Vector2 startTouch { get; private set; }
    public bool isDragging = false;
    public bool swipeUp { get; private set; }
    public bool swipeDown { get; private set; }
    public bool swipeRight { get; private set; }
    public bool swipeLeft { get; private set; }
    public bool tap { get; private set; }

    void Update()
    {
        tap = swipeUp = swipeDown = swipeRight = swipeLeft = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            } 
        }
        #endregion

        CalculateSwipeDirection();
        
    }

    private void CalculateSwipeDirection()
    {
        
        swipeDelta = Vector2.zero;

        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = (Vector2)Camera.main.ScreenToWorldPoint(Input.touches[0].position) - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - startTouch;
            }
        }

        

        if (swipeDelta.magnitude > 50)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    swipeRight = true;
                }
                else
                {
                    swipeLeft = true;
                }
            }
            else 
            {
                if (y > 0 )
                {
                    swipeUp = true;
                }
                else 
                {
                    swipeDown = true;
                }
            }
            Reset();
        } 
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
