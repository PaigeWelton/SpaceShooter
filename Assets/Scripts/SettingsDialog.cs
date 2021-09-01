using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDialog : DialogBase
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private AudioSource musicSource;
    private AudioSource sfxSource;

    private float musicSetData;
    private float sfxSetData;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        if (GameObject.FindGameObjectWithTag("AudioManager"))
            sfxSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();

        SetFromData();

        musicSlider.onValueChanged.AddListener(MusicChange);
        sfxSlider.onValueChanged.AddListener(SFXChange);
    }

    private void SetFromData()
    {
        DataManager.Instance.LoadMusicSettings();
        DataManager.Instance.LoadSFXSettings();
        musicSetData = DataManager.Instance.MusicSetting;
        sfxSetData = DataManager.Instance.SFXSetting;

        musicSlider.value = musicSetData;
        if (musicSource != null)
            musicSource.volume = musicSetData;

        sfxSlider.value = sfxSetData;
        if (sfxSource != null)
            sfxSource.volume = sfxSetData;
    }

    private void MusicChange(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = musicSlider.value;
            DataManager.Instance.MusicSetting = musicSource.volume;
        }

        DataManager.Instance.SaveMusicSettings();
    }

    private void SFXChange(float value)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = sfxSlider.value;
        }

        DataManager.Instance.SFXSetting = sfxSlider.value;
        DataManager.Instance.SaveSFXSettings();
    }

}
