using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private string[] sceneNames = new string[5] {"RitualCandles", "CauldronStir", "PackingIngredients", "SortingIngredients", "CatchingChickens"};
    private string nextScene;

    public GameObject heart;
    public GameObject bar;
    public GameObject speedUp;

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        int health = gameManager.GetComponent<GameManager>().health;
        int progress = gameManager.GetComponent<GameManager>().progress;

        for (int i = 0; i < health; i++)
        {
            Instantiate(heart, new Vector3(-48f + i * 48f, 12f, 0f), Quaternion.identity);
        }

        for (int i = 0; i < progress; i++)
        {
            Instantiate(bar, new Vector3(-56f + i * 16f, -24.5f, 0f), Quaternion.identity);
        }

        if (progress == 4)
        {   
            Instantiate(speedUp, transform.position, Quaternion.identity);
            Time.timeScale = 1.5f;
        }

        if (health == 0 || progress == 8)
        {
            Time.timeScale = 1f;
            gameManager.GetComponent<GameManager>().health = 3;
            gameManager.GetComponent<GameManager>().progress = 0;
            nextScene = "MainMenu";
        }
        else 
        {
            int randomIndex = Random.Range(0, sceneNames.Length);
            nextScene = sceneNames[randomIndex];
        }

        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneName:nextScene);
    }

}
