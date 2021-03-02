using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{

    public GameObject winMark;
    public GameObject loseMark;
    private bool triggered = false;
    protected GameObject gameManager;

    protected void Init()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(Timer());
    }
    
    protected void Win()
    {
        if (triggered == true) return;
        Instantiate(winMark, transform.position, Quaternion.identity);
        gameManager.GetComponent<GameManager>().progress++;
        StartCoroutine(NextScene());
    }

    protected void Lose()
    {
        if (triggered == true) return;
        Instantiate(loseMark, transform.position, Quaternion.identity);
        gameManager.GetComponent<GameManager>().health--;
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        triggered = true;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1f);
        yield return new WaitForSecondsRealtime(5f);
        Lose();
    }

}
