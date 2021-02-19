using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchingChickensManager : MonoBehaviour
{

    public GameObject chickenPrefab; 
    public int chickenCount = 4;
    public List<GameObject> chickens = new List<GameObject>();

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
        for (int i = 0; i < chickenCount; i++)
        {
            float x = Random.Range(-64f, 64f);
            float y = Random.Range(-28f, 28f);
            chickens.Add(Instantiate(chickenPrefab, new Vector3(x, y, 0), Quaternion.identity));
        }
    }
    
    public void RemoveChicken()
    {
        chickenCount--;
        if (chickenCount == 0)
        {
            gameManager.GetComponent<GameManager>().progress++;
            SceneManager.LoadScene(sceneName:"TransitionScene");
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
