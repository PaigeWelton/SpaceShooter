using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    private float maxPosX = 9.0f;
    private float maxPosY = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxPosX)
        {
            transform.position = new Vector3(-maxPosX, transform.position.y, 0);
        }

        if (transform.position.x < -maxPosX)
        {
            transform.position = new Vector3(maxPosX, transform.position.y, 0);
        }

        if (transform.position.y > maxPosY)
        {
            transform.position = new Vector3(transform.position.x, -maxPosY, 0);
        }

        if (transform.position.y < -maxPosY)
        {
            transform.position = new Vector3(transform.position.x, maxPosY, 0);
        }
    }
}
