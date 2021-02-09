using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitualCandlesManager : MonoBehaviour
{

    public int candleNumber;
    public GameObject candlePrefab;
    private int litCandles;

    void Start()
    {
        for (int i = 0; i < candleNumber; i++)
        {
            float x = Random.Range(-4.5f, 4.5f);
            float y = Random.Range(-2f, 2f);
            Instantiate(candlePrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    public void AddLitCandle()
    {
        litCandles++;
        if (litCandles == candleNumber)
        {
            SceneManager.LoadScene(sceneName:"TransitionScene");
        }
    }

}
