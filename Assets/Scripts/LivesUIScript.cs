using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUIScript : MonoBehaviour
{
    [SerializeField] private GameObject[] livesIcons;

    //ABSTRACTION
    public void UpdateLives(int health)
    {
        switch (health)
        {
            case 5:
                livesIcons[0].gameObject.SetActive(true);
                livesIcons[1].gameObject.SetActive(true);
                livesIcons[2].gameObject.SetActive(true);
                livesIcons[3].gameObject.SetActive(true);
                livesIcons[4].gameObject.SetActive(true);
                break;
            case 4:
                livesIcons[0].gameObject.SetActive(true);
                livesIcons[1].gameObject.SetActive(true);
                livesIcons[2].gameObject.SetActive(true);
                livesIcons[3].gameObject.SetActive(true);
                livesIcons[4].gameObject.SetActive(false);
                break;
            case 3:
                livesIcons[0].gameObject.SetActive(true);
                livesIcons[1].gameObject.SetActive(true);
                livesIcons[2].gameObject.SetActive(true);
                livesIcons[3].gameObject.SetActive(false);
                livesIcons[4].gameObject.SetActive(false);
                break;
            case 2:
                livesIcons[0].gameObject.SetActive(true);
                livesIcons[1].gameObject.SetActive(true);
                livesIcons[2].gameObject.SetActive(false);
                livesIcons[3].gameObject.SetActive(false);
                livesIcons[4].gameObject.SetActive(false);
                break;
            case 1:
                livesIcons[0].gameObject.SetActive(true);
                livesIcons[1].gameObject.SetActive(false);
                livesIcons[2].gameObject.SetActive(false);
                livesIcons[3].gameObject.SetActive(false);
                livesIcons[4].gameObject.SetActive(false);
                break;
            case 0:
                livesIcons[0].gameObject.SetActive(false);
                livesIcons[1].gameObject.SetActive(false);
                livesIcons[2].gameObject.SetActive(false);
                livesIcons[3].gameObject.SetActive(false);
                livesIcons[4].gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
