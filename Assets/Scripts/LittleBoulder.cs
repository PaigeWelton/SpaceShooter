using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class LittleBoulder : Boulder
{
    private int scoreValue = 50;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        maxSpeed = 1.5f;
        minSpeed = 0.5f;

        SetAngle();
        SetSpeed();
        SetRotationAngles();
        SetRotationSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translateAngle * setSpeed * Time.deltaTime, Space.World);
        transform.Rotate(rotVector * rotationSpeed * Time.deltaTime);
    }

    //POLYMORPHISM
    public override void DestroyBoulder()
    {
        gameManager.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
