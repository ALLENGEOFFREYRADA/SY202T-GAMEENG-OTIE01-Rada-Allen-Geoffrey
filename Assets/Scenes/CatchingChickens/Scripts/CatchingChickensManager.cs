using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchingChickensManager : MinigameManager
{
    public GameObject chickenPrefab; 
    public int chickenCount = 4;
    public List<GameObject> chickens = new List<GameObject>();

    void Start()
    {
        base.Init();
        for (int i = 0; i < chickenCount; i++)
        {
            float x = Random.Range(-64f, 64f);
            float y = Random.Range(-28f, 28f);
            chickens.Add(Instantiate(chickenPrefab, new Vector3(x, y, 0), Quaternion.identity));
        }
    }
    
    public void RemoveChicken()
    {
        chickenCount--;
        if (chickenCount == 0)
        {
            base.Win();
        }
    }
}
