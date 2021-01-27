using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingIngredientsManager : MonoBehaviour
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public List<GameObject> ingredients = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < ingredientsCount; i++)
        {
            int x = Random.Range(-10, 11);
            int y = Random.Range(-4, -1);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
        }
    }
    
}
