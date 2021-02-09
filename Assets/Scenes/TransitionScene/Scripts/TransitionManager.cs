using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private string[] sceneNames = new string[4] {"RitualCandles", "CauldronStir", "PackingIngredients", "SortingIngredients"};

    void Start()
    {
        int randomIndex = Random.Range(0, sceneNames.Length);
        SceneManager.LoadScene(sceneName:sceneNames[randomIndex]);
    }

}
