using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitualCandlesManager : MonoBehaviour
{

    public int candleNumber;
    public GameObject candlePrefab;
    private int litCandles;

    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
        for (int i = 0; i < candleNumber; i++)
        {
            float x = Random.Range(-64f, 64f);
            float y = Random.Range(-28f, 28f);
            Instantiate(candlePrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    public void AddLitCandle()
    {
        litCandles++;
        if (litCandles == candleNumber)
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
