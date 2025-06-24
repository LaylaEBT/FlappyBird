using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;

    private int score;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();

    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.gameObject.SetActive(true); 

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.gameObject.SetActive(false); 
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();

    }


    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
