using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{

    public GameObject manager;

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.tag = "dying";
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.gameObject.tag = "Untagged";
    }

}
