using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip powerupPickupSFX;
    [SerializeField] private AudioClip asteroidDestroySFX;
    [SerializeField] private AudioClip playerShotSFX;
    [SerializeField] private AudioClip playerDestroySFX;
    [SerializeField] private AudioClip playerHitSFX;

    public void PlayPowerupPickupSFX()
    {
        audioSource.PlayOneShot(powerupPickupSFX);
    }

    public void PlayAsteroidDestroySFX()
    {
        audioSource.PlayOneShot(asteroidDestroySFX);
    }

    public void PlayPlayerShotSFX()
    {
        audioSource.PlayOneShot(playerShotSFX);
    }

    public void PlayPlayerDestroySFX()
    {
        audioSource.PlayOneShot(playerDestroySFX);
    }

    public void PlayPlayerHitSFX()
    {
        audioSource.PlayOneShot(playerHitSFX);
    }
}
