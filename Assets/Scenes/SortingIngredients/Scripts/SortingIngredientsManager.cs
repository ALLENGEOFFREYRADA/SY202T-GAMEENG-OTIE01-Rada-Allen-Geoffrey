using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingIngredientsManager : MonoBehaviour
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public Sprite[] sprites;
    public GameObject leftSorter;
    public GameObject rightSorter;
    public GameObject leftDisplay;
    public GameObject rightDisplay;
    private List<GameObject> ingredients = new List<GameObject>();

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
        int leftIngredientIndex = Random.Range(0, sprites.Length);
        int rightIngredientIndex = Random.Range(0, sprites.Length);
        SpriteRenderer spriteRenderer;

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
            float x = Random.Range(-72f, 72f);
            float y = Random.Range(8f, 37);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
            ingredients[ingredients.Count - 1].tag = "leftIngredient";
            spriteRenderer = ingredients[ingredients.Count - 1].GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = sprites[leftIngredientIndex];
        }

        for (int i = 0; i < ingredientsCount / 2; i++)
        {
            float x = Random.Range(-72f, 72f);
            float y = Random.Range(8f, 37);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
            ingredients[ingredients.Count - 1].tag = "rightIngredient";
            spriteRenderer = ingredients[ingredients.Count - 1].GetComponent<Renderer>() as SpriteRenderer;
            spriteRenderer.sprite = sprites[rightIngredientIndex];
        }

        spriteRenderer = leftDisplay.GetComponent<Renderer>() as SpriteRenderer;
        spriteRenderer.sprite = sprites[leftIngredientIndex];
        spriteRenderer = rightDisplay.GetComponent<Renderer>() as SpriteRenderer;
        spriteRenderer.sprite = sprites[rightIngredientIndex];

    }

    void Update()
    {
        bool somethingDragging = false;

        foreach (GameObject ingredient in ingredients)
        {
            if (ingredient.GetComponent<DragTransform>().dragging == true)
            {
                somethingDragging = true;
            }
        } 

        if (leftSorter.GetComponent<CheckCollisions>().collisions == 2 &&
            rightSorter.GetComponent<CheckCollisions>().collisions == 2 &&
            somethingDragging == false)
        {
            gameManager.GetComponent<GameManager>().progress++;
            SceneManager.LoadScene(sceneName:"TransitionScene");
        }
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        gameManager.GetComponent<GameManager>().health--;
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }
    
}
