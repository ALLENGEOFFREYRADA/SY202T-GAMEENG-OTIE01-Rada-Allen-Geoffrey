using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackingIngredientsManager : MonoBehaviour
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public List<GameObject> ingredients = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < ingredientsCount; i++)
        {
            int x = Random.Range(-10, 11);
            int y = Random.Range(-4, 5);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
        }
    }
    
    void Update()
    {
        if (ingredients.Count == 0) 
        {
            SceneManager.LoadScene(sceneName:"PackingIngredients");
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
