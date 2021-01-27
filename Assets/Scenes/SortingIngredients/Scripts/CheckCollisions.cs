using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    
    public int collisions = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == gameObject.tag) {
            collisions++;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == gameObject.tag) {
            collisions--;
        }
    }
}
