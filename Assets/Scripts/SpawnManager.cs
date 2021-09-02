using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private GameObject lifePowerup;
    private float timeToNextLife = 20.0f;
    private bool isGeneratingLife = false;
    private bool isLifeOnScreen;
    //ENCAPSULATION
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
    private float timeToNextPowerup = 15.0f;

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
        StartCoroutine(WaitToNextPowerup());
        SpawnAsteroids(waveNumber);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (gameManager.isGameActive == true)
        {
            asteroidCount = FindObjectsOfType<Asteroid>().Length;
            littleAsteroidCount = FindObjectsOfType<LittleAsteroid>().Length;

            if (asteroidCount == 0 && littleAsteroidCount == 0)
            {
                waveNumber++;
                SpawnAsteroids(waveNumber);
            }

            if (gameManager.lives < 3)
                SpawnLife();
        }
    }

    private Vector3 GeneratePosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        Collider[] hitColliders = Physics.OverlapSphere(randomPos, 3.0f);
        if (hitColliders != null)
        {
            foreach (Collider hit in hitColliders)
            {
                if (hit.CompareTag("Player"))
                {
                    GeneratePosition();
                }
            }
        }
        return randomPos;
    }

    //ABSTRACTION
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
        if (gameManager.isGameActive == true)
        {
            Instantiate(powerupPrefab, GeneratePosition(), powerupPrefab.transform.rotation);
            StartCoroutine(WaitToNextPowerup());
        }
    }

    private IEnumerator WaitToNextPowerup()
    {
        yield return new WaitForSeconds(timeToNextPowerup);
        SpawnPowerup();
    }

    private void SpawnAsteroids(int asteroidsToSpawn)
    {
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Instantiate(asteroidPrefab, GeneratePosition(), asteroidPrefab.transform.rotation);
        }
    }
}
