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

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PowerupCollected();
    }

    protected virtual void PowerupCollected()
    {
        Destroy(gameObject);

        if (powerup == PowerupType.AddLives)
        {
            gameManager.AddLife(1);
        }

        if (powerup == PowerupType.Shield)
        {
            player.ShieldActivated();
        }
    }
}
