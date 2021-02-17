using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackingIngredientsManager : MonoBehaviour
{

    public GameObject ingredientPrefab; 
    public int ingredientsCount = 4;
    public List<GameObject> ingredients = new List<GameObject>();

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
        for (int i = 0; i < ingredientsCount; i++)
        {
            float x = Random.Range(-4.5f, 1.5f);
            float y = Random.Range(-2f, 1f);
            if (x > -1.5f && x < 1.5f) 
            {
                x += 3f;
            }
            if (y > -0.5f && y < 0.5f)
            {
                y += 1f;
            }
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity));
        }
    }
    
    void Update()
    {
        if (ingredients.Count == 0) 
        {
            gameManager.GetComponent<GameManager>().progress++;
            SceneManager.LoadScene(sceneName:"TransitionScene");
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

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        gameManager.GetComponent<GameManager>().health--;
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }

}
