using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private GameObject bulletAnchor;

    [SerializeField]
    private Rigidbody playerRb;

    private float thrust = 200.0f;
    private float boostSpeed = 300.0f;

    [SerializeField] private Camera mainCam;
    private Vector3 mousePos;

    private float sideInput;
    private float forwardInput;

    [SerializeField] private GameManager gameManager;
    private bool isShielded = false;
    [SerializeField] private GameObject shield;
    private float shieldActivationTime = 5.0f;


    private void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {
        if (gameManager.isGameActive == true)
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

            if (Input.GetMouseButtonDown(0))
            {
                FireShot();
            }
        }
    }

    private void FireShot()
    {
        Vector3 relativePos = mousePos - transform.position;
        Quaternion fireRotation = Quaternion.LookRotation(relativePos, Vector3.right);
        Instantiate(bullet, bulletAnchor.transform.position, fireRotation);
    }

    public void DamageDealt()
    {
        if (!isShielded)
            gameManager.RemoveLife(1);
    }

    public void ShieldActivated()
    {
        isShielded = true;
        shield.SetActive(true);
        StartCoroutine(ShieldTimerCoroutine());
    }

    private IEnumerator ShieldTimerCoroutine()
    {
        yield return new WaitForSeconds(shieldActivationTime);
        isShielded = false;
        shield.SetActive(false);
    }
}
