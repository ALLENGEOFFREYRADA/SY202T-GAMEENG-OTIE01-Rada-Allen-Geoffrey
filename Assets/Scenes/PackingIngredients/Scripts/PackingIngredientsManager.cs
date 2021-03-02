using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackingIngredientsManager : MinigameManager
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public List<GameObject> ingredients = new List<GameObject>();

    void Start()
    {
        base.Init();
        for (int i = 0; i < ingredientsCount; i++)
        {
            float x = Random.Range(-64f, 64f);
            float y = Random.Range(0f, 28f);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity));
        }
    }
    
    void Update()
    {
        if (GameManager.paused == true) return;
        if (ingredients.Count == 0) 
        {
            base.Win();
        }

        GameObject[] dying = new GameObject[ingredients.Count];

        int i = 0;

        foreach (GameObject ingredient in ingredients)
        {
            if (ingredient.GetComponent<DragTransform>().dragging == false && ingredient.tag == "dying")
            {
                    dying[i] = ingredient;
                    i += 1;            
            }
        }

        foreach (GameObject ingredient in dying)
        {
            ingredients.Remove(ingredient);
            DestroyImmediate(ingredient);
        }
    }
}
