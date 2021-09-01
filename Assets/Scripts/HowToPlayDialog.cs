using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayDialog : DialogBase
{
    [SerializeField] private GameObject controlsPage;
    [SerializeField] private GameObject infoPage;

    [SerializeField] private Button controlsButton;
    [SerializeField] private Button infoButton;

    // Start is called before the first frame update
    void Start()
    {
        infoPage.SetActive(true);
        controlsPage.SetActive(false);
        infoButton.interactable = false;
        controlsButton.interactable = true;
    }

    public void ControlButtonClicked()
    {
        controlsPage.SetActive(true);
        infoPage.SetActive(false);
        controlsButton.interactable = false;
        infoButton.interactable = true;
    }

    public void InfoButtonClicked()
    {
        infoPage.SetActive(true);
        controlsPage.SetActive(false);
        controlsButton.interactable = true;
        infoButton.interactable = false;
    }

}
