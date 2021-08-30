using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Powerup : MonoBehaviour
{
    public enum PowerupType
    {
        AddLives,
        Shield
    }
    public PowerupType powerup;

    private GameManager gameManager;
    private PlayerScript player;
    private SpawnManager spawnManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PowerupCollected();
    }

    protected virtual void PowerupCollected()
    {
        Destroy(gameObject);

        if (powerup == PowerupType.AddLives)
        {
            gameManager.AddLife(1);
            spawnManager.IsLifeOnScreen = false;
            
        }

        if (powerup == PowerupType.Shield)
        {
            player.ShieldActivated();
        }
    }
}
