 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    private int highScore;
    [Header("Score elements")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;
    [Header("Gameover elements")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button quitButton;
    
    private void GetHighscore()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highScore.ToString();
    }
    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("Highscore",score);
            highscoreText.text = "Best: " + score.ToString();
        }
    }
    
    public void OnBombHit()
    {
        quitButton.gameObject.SetActive(false);
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene"); 
    }

    public void Quit()
    {
        Application.Quit(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        GetHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
