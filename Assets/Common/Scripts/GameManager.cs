using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int health = 0;
    public int progress = 0;

    void Awake()    
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("gameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
     
}
