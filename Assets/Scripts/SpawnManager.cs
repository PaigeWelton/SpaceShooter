using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject lifePowerup;
    private float timeToNextLife = 15.0f;
    private bool isGeneratingLife = false;
    private bool isLifeOnScreen;
    public bool IsLifeOnScreen 
    { 
        get
        {
            return isLifeOnScreen;
        }
        set
        {
            if (value == true)
                isLifeOnScreen = false;
            else
                isLifeOnScreen = value;
        }
    }

    [SerializeField] private GameObject powerupPrefab;
    private float timeToNextPowerup = 30.0f;

    [SerializeField] private GameObject asteroidPrefab;
    private int waveNumber = 1;
    private int asteroidCount;
    private int littleAsteroidCount;

    [SerializeField] private GameManager gameManager;

    private float spawnRangeX = 9.0f;
    private float spawnRangeY = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", 30.0f, timeToNextPowerup);
        SpawnAsteroids(waveNumber);
    }

    private void Update()
    {
        asteroidCount = FindObjectsOfType<Boulder>().Length;
        littleAsteroidCount = FindObjectsOfType<LittleBoulder>().Length;

        if (asteroidCount == 0 && littleAsteroidCount == 0)
        {
            waveNumber++;
            SpawnAsteroids(waveNumber);
        }

        if (gameManager.lives < 3)
            SpawnLife();
    }

    private Vector3 GeneratePosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    public void SpawnLife()
    {
        if (!isGeneratingLife && !isLifeOnScreen)
            StartCoroutine(TimeToLifeCorouotine());
    }

    private IEnumerator TimeToLifeCorouotine()
    {
        isGeneratingLife = true;
        yield return new WaitForSeconds(timeToNextLife);
        if (!isLifeOnScreen)
        {
            Instantiate(lifePowerup, GeneratePosition(), lifePowerup.transform.rotation);
            isLifeOnScreen = true;
        }
        isGeneratingLife = false;
    }

    public void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GeneratePosition(), powerupPrefab.transform.rotation);
    }

    private void SpawnAsteroids(int asteroidsToSpawn)
    {
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Instantiate(asteroidPrefab, GeneratePosition(), asteroidPrefab.transform.rotation);
        }
    }
}
