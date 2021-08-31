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

    private AudioManager audioManager;
    private GameManager gameManager;
    private PlayerScript player;
    private SpawnManager spawnManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive == true)
        {
            if (other.CompareTag("Player"))
                PowerupCollected();
        }
    }

    protected virtual void PowerupCollected()
    {
        audioManager.PlayPowerupPickupSFX();
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
