using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreenUIHandler : MonoBehaviour
{
    [SerializeField] private SettingsDialog settingsDialog;
    [SerializeField] private GameObject howToPlayDialog;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OpenSettings()
    {
        Instantiate(settingsDialog);
    }

    public void OpenHowToPlay()
    {
        Instantiate(howToPlayDialog);
    }
}
