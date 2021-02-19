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
            float x = Random.Range(-64f, 64f);
            float y = Random.Range(0f, 28f);
            ingredients.Add(Instantiate(ingredientPrefab, new Vector3(x, y, 0), Quaternion.identity));
        }
    }
    
    void Update()
    {
        if (Time.timeScale == 0) return;
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
        yield return new WaitForSecondsRealtime(1f);
        yield return new WaitForSecondsRealtime(5f);
        gameManager.GetComponent<GameManager>().health--;
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }

}
