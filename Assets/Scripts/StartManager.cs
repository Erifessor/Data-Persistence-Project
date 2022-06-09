using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static StartManager Instance;
    public string userName;
    public int highestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserInfo();
    }
    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int highestScore;
    }
    public void SaveUserInfo()
    {
        SaveData saveData = new SaveData();
        saveData.userName = userName;
        saveData.highestScore = highestScore;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveUserInfo.json", json);
        Debug.Log("--------------" + Application.persistentDataPath);
    }
    public void LoadUserInfo()
    {
        string path = Application.persistentDataPath + "/saveUserInfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            userName = saveData.userName;
            highestScore = saveData.highestScore;
        }
    }
}
