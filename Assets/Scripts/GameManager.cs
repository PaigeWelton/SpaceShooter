using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LivesUIScript livesUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private SpawnManager spawnManager;

    public int lives { get; private set; }
    private int score;

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
    }

    public void RemoveLife(int livesToRemove)
    {
        lives -= livesToRemove;
        livesUI.UpdateLives(lives);
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

}
