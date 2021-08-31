using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LivesUIScript livesUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private SettingsDialog settingsDialog;

    //ENCAPSULATION
    public int lives { get; private set; }
    private int score;

    public bool isGameActive { get; private set; }
    [SerializeField] private GameObject gameOverScreen;

    void Start()
    {
        ResetInfo();
    }

    private void ResetInfo()
    {
        lives = 3;
        livesUI.UpdateLives(lives);
        score = 0;
        scoreText.text = score.ToString();
        isGameActive = true;
        gameOverScreen.SetActive(false);
    }

    //ABSTRACTION
    public void RemoveLife(int livesToRemove)
    {
        lives -= livesToRemove;
        livesUI.UpdateLives(lives);
        if (lives <= 0)
            GameOver();
    }

    public void AddLife(int livesToAdd)
    {
        lives += livesToAdd;
        if (lives > 5)
            lives = 5;
        livesUI.UpdateLives(lives);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Instantiate(settingsDialog);
    }

}
