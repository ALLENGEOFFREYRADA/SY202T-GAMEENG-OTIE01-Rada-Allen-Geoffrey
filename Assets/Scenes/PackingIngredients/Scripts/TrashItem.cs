using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{

    public GameObject manager;

    void OnTriggerEnter2D(Collider2D col)
    {
        manager.GetComponent<PackingIngredientsManager>().ingredients.Remove(col.gameObject);
        Destroy(col.gameObject);
    }

}
