using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeLeft;
    private float timer;
    private bool gameOver;

    void Start()
    {
        timer = 0f;
        timeLeft = 120f;
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            gameOver = true;
            savePrefs();
        }
        if (!gameOver)
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
