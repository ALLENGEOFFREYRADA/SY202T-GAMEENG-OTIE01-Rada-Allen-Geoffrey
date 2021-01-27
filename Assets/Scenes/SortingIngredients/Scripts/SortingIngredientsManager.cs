using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingIngredientsManager : MonoBehaviour
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public Sprite[] sprites;
    public GameObject leftSorter;
    public GameObject rightSorter;
    private List<GameObject> ingredients = new List<GameObject>();

    void Start()
    {
        int leftIngredientIndex = Random.Range(0, sprites.Length);
        int rightIngredientIndex = Random.Range(0, sprites.Length);
        if (rightIngredientIndex == leftIngredientIndex) 
        {
            rightIngredientIndex++;
            if (rightIngredientIndex > sprites.Length - 1) 
            {
                rightIngredientIndex = 0;
            }
        }


        for (int i = 0; i < ingredientsCount / 2; i++)
        {
            int x = Random.Range(-10, 11);
            int y = Random.Range(-4, -1);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
            ingredients[ingredients.Count - 1].tag = "leftIngredient";
            SpriteRenderer spriteRenderer = ingredients[ingredients.Count - 1].GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = sprites[leftIngredientIndex];
        }

        for (int i = 0; i < ingredientsCount / 2; i++)
        {
            int x = Random.Range(-10, 11);
            int y = Random.Range(-4, -1);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
            ingredients[ingredients.Count - 1].tag = "rightIngredient";
            SpriteRenderer spriteRenderer = ingredients[ingredients.Count - 1].GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = sprites[rightIngredientIndex];
        }

    }

    void Update()
    {
        if (leftSorter.GetComponent<CheckCollisions>().collisions == 2 && rightSorter.GetComponent<CheckCollisions>().collisions == 2)
        {
            Debug.Log("win!");
        }
    }
    
}
