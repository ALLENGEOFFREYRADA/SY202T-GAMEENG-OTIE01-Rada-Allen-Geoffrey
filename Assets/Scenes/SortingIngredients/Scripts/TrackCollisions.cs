using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollisions : MonoBehaviour
{
    
    List<GameObject> currentCollisions = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D col)
    {
        currentCollisions.Add(col.gameObject);

        foreach (GameObject gObject in currentCollisions)
        {

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentCollisions.Remove(col.gameObject);

        foreach (GameObject gObject in currentCollisions)
        {
            
        }
    }
}
