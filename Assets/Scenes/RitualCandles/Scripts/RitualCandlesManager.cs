using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitualCandlesManager : MinigameManager
{

    public int candleNumber;
    public GameObject candlePrefab;
    private int litCandles;

    void Start()
    {
        base.Init();
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
            base.Win();
        } 
    }
}
