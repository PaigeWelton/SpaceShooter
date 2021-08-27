using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLifePowerup : Powerup
{
    private int livesToAdd = 1;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    protected override void PowerupCollected()
    {
        base.PowerupCollected();
        gameManager.AddLife(livesToAdd);

    }
}
