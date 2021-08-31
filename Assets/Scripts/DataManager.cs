using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public float MusicSetting;
    public float SFXSetting;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public float MusicSetting;
        public float SFXSetting;
    }

    public void SaveMusicSettings()
    {
        SaveData data = new SaveData();
        data.MusicSetting = MusicSetting;

        var json = JsonConvert.SerializeObject(MusicSetting);
        File.WriteAllText(Application.persistentDataPath + "/savemusicfile.json", json);
    }

    public void LoadMusicSettings()
    {
        string path = Application.persistentDataPath + "/savemusicfile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MusicSetting = (float)JsonConvert.DeserializeObject(json, typeof (float));
        }
    }

    public void SaveSFXSettings()
    {
        SaveData data = new SaveData();
        data.SFXSetting = SFXSetting;

        var json = JsonConvert.SerializeObject(SFXSetting);
        File.WriteAllText(Application.persistentDataPath + "/savesfxfile.json", json);
    }

    public void LoadSFXSettings()
    {
        string path = Application.persistentDataPath + "/savesfxfile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SFXSetting = (float)JsonConvert.DeserializeObject(json, typeof(float));
        }
    }
}
