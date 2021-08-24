using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody playerRb;

    [SerializeField] private float thrust;
    [SerializeField] private float turnSpeed;

    private float turnInput;
    private float forwardInput;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        turnInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward, Time.deltaTime * turnSpeed * turnInput);
        playerRb.AddRelativeForce(Vector3.up * forwardInput * thrust, ForceMode.Force);
    }
}
