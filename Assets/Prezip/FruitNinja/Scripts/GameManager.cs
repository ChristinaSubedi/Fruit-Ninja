using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOvertext;
    public Button restartButton;
    public bool gameIsOver;
    // Start is called before the first frame update
    void Start()
    {
        score= 0;
        lives = 3;
        gameIsOver = false;
    }

    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text= score.ToString();
    }
    public void UpdateLives()
    {
        if (gameIsOver == false)
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();

            if (lives == 0)
            {
                GameOver();
            }
        }
       
    }

    public void GameOver()
    {
        gameIsOver= true;
        gameOvertext.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


