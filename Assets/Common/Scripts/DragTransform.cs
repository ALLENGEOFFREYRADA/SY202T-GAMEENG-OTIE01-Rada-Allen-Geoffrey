
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
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
            case TouchPhase.Began:
                //if you touch the car
                if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition)) 
                {
                    //get the offset between position you touch
                    deltax = touchPosition.x - transform.position.x;
                    deltay = touchPosition.y - transform.position.y;

                    //if touch began within  the car collider
                    //then it is allowed to move

                    dragging = true;

                }
                break;

            //you move your finger
            case TouchPhase.Moved:                   
                //if you touches the car and move is allowed
                if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPosition) && dragging)
                    transform.position = new Vector2(0, touchPosition.y - deltay);

                break;

            //you released your finger
            case TouchPhase.Ended:
                //restore intial parameters
                //when touch is ended
                dragging = false;
                break;
            }

        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }
}