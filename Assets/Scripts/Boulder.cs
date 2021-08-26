using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boulder : MonoBehaviour
{
    private float maxSpeed = 8.0f;
    private float minSpeed = 0.5f;

    private float setSpeed;

    private float movementAngle = 1.0f;
    private Vector3 translateAngle;

    private float rotationAngle = 1.0f;
    private float xRotAngle;
    private float yRotAngle;
    private float zRotAngle;
    private Vector3 rotVector;
    private float rotationSpeed;
    private float maxRotSpeed = 30.0f;
    private float minRotSpeed = 10.0f;

    // Start is called before the first frame update
    void Awake()
    {
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

    private float SetSpeed()
    {
        setSpeed = Random.Range(minSpeed, maxSpeed);
        return setSpeed;
    }

    private Vector3 SetAngle()
    {
        float xAngle = Random.Range(-movementAngle, movementAngle);
        float yAngle = Random.Range(-movementAngle, movementAngle);
        translateAngle = new Vector3(xAngle, yAngle, 0);
        return translateAngle;
    }

    private void SetRotationAngles()
    {
        xRotAngle = Random.Range(-rotationAngle, rotationAngle);
        yRotAngle = Random.Range(-rotationAngle, rotationAngle);
        zRotAngle = Random.Range(-rotationAngle, rotationAngle);
        rotVector = new Vector3(xRotAngle, yRotAngle, zRotAngle);
    }

    private float SetRotationSpeed()
    {
        if (setSpeed > maxSpeed/2)
        {
            rotationSpeed = Random.Range(maxRotSpeed / 2, maxRotSpeed);
        }

        else
        {
            rotationSpeed = Random.Range(minRotSpeed, maxRotSpeed / 2);
        }

        return rotationSpeed;
    }
}
