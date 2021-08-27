using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private Vector3 rotationDegrees;
    [SerializeField] private float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDegrees * rotationSpeed * Time.deltaTime);
    }
}
