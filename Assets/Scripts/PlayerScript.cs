using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRb;

    private float thrust = 200.0f;
    private float boostSpeed = 300.0f;

    [SerializeField] private Camera mainCam;
    private Vector3 mousePos;

    private float sideInput;
    private float forwardInput;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        sideInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //rotate to look at mouse
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.LookAt(mousePos, Vector3.back);

        // player movement
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * thrust, ForceMode.Force);
        playerRb.AddRelativeForce(Vector3.right * sideInput * thrust, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.AddRelativeForce(Vector3.forward * boostSpeed, ForceMode.Impulse);
        }
    }
}
