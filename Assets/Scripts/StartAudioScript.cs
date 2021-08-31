using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioScript : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadMusicSettings();
        if (musicSource != null)
            musicSource.volume = DataManager.Instance.MusicSetting;

        if (sfxSource != null)
            sfxSource.volume = DataManager.Instance.SFXSetting;
    }
}
