using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string userName;
    public string highName;
    public int highscore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   

    public void Save()
    {
        SaveData Data = new SaveData();
        Data.highSave = highscore;
        Data.highSaveName = userName;
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string Json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(Json);
 
            highName = data.highSaveName;
            highscore = data.highSave;
            Debug.Log(data.highSave);
            Debug.Log(data.highSaveName);
        }


    }

}
[System.Serializable]
public class SaveData
{
    public int highSave;
    public string highSaveName;
}
