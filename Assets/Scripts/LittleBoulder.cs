using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBoulder : Boulder
{
    // Start is called before the first frame update
    void Awake()
    {
        maxSpeed = 2.0f;
        minSpeed = 1.0f;

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
}
