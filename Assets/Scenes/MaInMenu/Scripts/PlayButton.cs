using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    void StartGame()
    {
        SceneManager.LoadScene(sceneName:"TransitionScene");
    }
    
    void OnMouseDown()
    {
        StartGame();
    }
    
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0) 
            {
                Touch touch = Input.GetTouch(0);
                Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                bool onButton = false;

                if (Physics.Raycast(raycast, out raycastHit))
                {
                    onButton = true;
                }
                else
                {
                    onButton = false;
                }


                if (touch.phase == TouchPhase.Ended)
                {
                    if (onButton)
                    {
                        StartGame();
                    }
                }

            }
        }
    }
}
