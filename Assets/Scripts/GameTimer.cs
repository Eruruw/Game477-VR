using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameObject menu;
    public tutorialArrow tutorial;
    public float timeLeft;
    private float timer;
    private bool gameOver;
    private bool start;

    void Start()
    {
        timer = 0f;
        timeLeft = 120f;
    }

    void Update()
    {
        if(tutorial.currentStep == 37)
        {
            start = true;
        }
        if (timeLeft <= 0)
        {
            gameOver = true;
            savePrefs();
            menu.SetActive(true);
        }
        if (!gameOver && start)
        {
            timer += Time.deltaTime;
            timeLeft -= Time.deltaTime;
        }
    }

    private void savePrefs()
    {
        if (PlayerPrefs.HasKey("bestTime"))
        {
            if(PlayerPrefs.GetFloat("bestTime") < timer)
            {
                PlayerPrefs.SetFloat("bestTime", timer);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("bestTime", timer);
        }
        PlayerPrefs.Save();
    }
}
