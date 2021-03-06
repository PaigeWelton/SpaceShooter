using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private ParticleSystem engineTrail;
    [SerializeField] private GameObject destroyParticles;

    [SerializeField] private AudioManager audioManager;


    private void Start()
    {
        shield.SetActive(false);
        engineTrail.Stop();
    }

    void Update()
    {
        if (gameManager.isGameActive == true && gameManager.isPaused == false)
        {
            sideInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            //rotate to look at mouse
            mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            transform.LookAt(mousePos, Vector3.back);

            // player movement
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * thrust);
            playerRb.AddRelativeForce(Vector3.right * sideInput * thrust, ForceMode.Force);

            //handle particle trail on ship
            if (Input.GetKeyDown(KeyCode.W))
                engineTrail.Play();
            else if (Input.GetKeyUp(KeyCode.W))
                engineTrail.Stop();

            //boost speed
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRb.AddRelativeForce(Vector3.forward * boostSpeed, ForceMode.Impulse);
                engineTrail.Play();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
                engineTrail.Stop();

            //fire a shot
            if (Input.GetMouseButtonDown(0))
            {
                FireShot();
            }
        }
    }

    private void FireShot()
    {
        audioManager.PlayPlayerShotSFX();
        Vector3 relativePos = mousePos - transform.position;
        Quaternion fireRotation = Quaternion.LookRotation(relativePos, Vector3.right);
        Instantiate(bullet, bulletAnchor.transform.position, fireRotation);
    }

    public void DamageDealt()
    {
        if (!isShielded)
            gameManager.RemoveLife(1);
        PlayHitSound();
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

    private void PlayHitSound()
    {
        if (gameManager.lives == 0)
            audioManager.PlayPlayerDestroySFX();
        else
            audioManager.PlayPlayerHitSFX();
    }

    public void DestroyShip()
    {
        GameObject particles = Instantiate(destroyParticles, transform.position, destroyParticles.transform.rotation);
        gameObject.SetActive(false);
    }
}
