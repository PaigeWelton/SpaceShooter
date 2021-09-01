using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    [SerializeField] SettingsDialog settingsDialog;
    [SerializeField] HowToPlayDialog howToDialog;
    [SerializeField] GameManager gameManager;

    public void OpenSettings()
    {
        DialogBase dialog = Instantiate(settingsDialog);
        dialog.OpenDialog();
    }

    public void OpenHowToDialog()
    {
        DialogBase dialog = Instantiate(howToDialog);
        dialog.OpenDialog();
    }

    public void ContinuePressed()
    {
        gameManager.UnpauseGame();
    }

    public void QuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
