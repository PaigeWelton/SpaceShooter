using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boulder : MonoBehaviour
{
    protected float maxSpeed = 1.0f;
    protected float minSpeed = 0.25f;

    public float setSpeed;

    protected float movementAngle = 10.0f;
    protected Vector3 translateAngle;

    protected float rotationAngle = 1.0f;
    protected float xRotAngle;
    protected float yRotAngle;
    protected float zRotAngle;
    protected Vector3 rotVector;
    protected float rotationSpeed;
    protected float maxRotSpeed = 60.0f;
    protected float minRotSpeed = 10.0f;

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

    protected float SetSpeed()
    {
        setSpeed = Random.Range(minSpeed, maxSpeed);
        return setSpeed;
    }

    protected Vector3 SetAngle()
    {
        float xAngle = Random.Range(-movementAngle, movementAngle);
        float yAngle = Random.Range(-movementAngle, movementAngle);
        translateAngle = new Vector3(xAngle, yAngle, 0);
        return translateAngle;
    }

    protected void SetRotationAngles()
    {
        xRotAngle = Random.Range(-rotationAngle, rotationAngle);
        yRotAngle = Random.Range(-rotationAngle, rotationAngle);
        zRotAngle = Random.Range(-rotationAngle, rotationAngle);
        rotVector = new Vector3(xRotAngle, yRotAngle, zRotAngle);
    }

    protected float SetRotationSpeed()
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
