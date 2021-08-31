using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class LittleAsteroid : Asteroid
{

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        maxSpeed = 0.75f;
        minSpeed = 0.2f;

        SetAngle();
        SetSpeed();
        SetRotationAngles();
        SetRotationSpeed(); 

        scoreValue = 50;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translateAngle * setSpeed * Time.deltaTime, Space.World);
        transform.Rotate(rotVector * rotationSpeed * Time.deltaTime);
    }

    //POLYMORPHISM
    public override void DestroyAsteroid()
    {
        audioManager.PlayAsteroidDestroySFX();
        gameManager.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
