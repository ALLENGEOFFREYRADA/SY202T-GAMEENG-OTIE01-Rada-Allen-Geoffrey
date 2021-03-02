
using System.Collections;
using UnityEngine;
 
class DragTransform : MonoBehaviour
{

    public bool dragging = false;
    private float distance;
    private float deltax, deltay;
    private Vector3 startDist;
 
    void OnMouseDown()
    {
        if (GameManager.paused == true) return;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        if (GameManager.paused == true) return;
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
            case TouchPhase.Began:
                if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition)) 
                {
                    deltax = touchPosition.x - transform.position.x;
                    deltay = touchPosition.y - transform.position.y;
                }
                dragging = true;
                break;

            case TouchPhase.Moved:                   
                if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition) && dragging)
                    transform.position = new Vector2(touchPosition.x - deltax, touchPosition.y - deltay);

                break;

            case TouchPhase.Ended:
                dragging = false;
                break;
            }

        }
        else
        {
            if (dragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                transform.position = rayPoint + startDist;
            }
        }
        
    }
}