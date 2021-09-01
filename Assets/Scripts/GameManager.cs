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
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerScript player;

    private float waitForDeath = 2.0f;

    public bool isPaused { get; private set; }

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
        pauseMenu.SetActive(false);
        isPaused = false;
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
        player.DestroyShip();
        StartCoroutine(WaitForDeath());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(waitForDeath);
        gameOverScreen.SetActive(true);
    }

}
