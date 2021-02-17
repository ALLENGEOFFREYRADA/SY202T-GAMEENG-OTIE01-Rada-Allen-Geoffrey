using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private string[] sceneNames = new string[4] {"RitualCandles", "CauldronStir", "PackingIngredients", "SortingIngredients"};

    public GameObject heart;
    public GameObject bar;

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

        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);
        int randomIndex = Random.Range(0, sceneNames.Length);
        SceneManager.LoadScene(sceneName:sceneNames[randomIndex]);
    }

}
