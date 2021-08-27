using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PowerupCollected();
    }

    protected virtual void PowerupCollected()
    {
        Destroy(gameObject);
    }
}
