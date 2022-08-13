using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string inputText;
    public string highScoreNameText;

    public int score;

    private void Awake()
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
        public string inputText;
        public string highScoreNameText;
        public int score;
    }

    public void SaveScore()
    {
        SaveData myData = new SaveData();
        myData.inputText = inputText;
        myData.highScoreNameText = highScoreNameText;
        myData.score = score;

        string json = JsonUtility.ToJson(myData);

        File.WriteAllText(Application.persistentDataPath + "/scorefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/scorefile.json";

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        inputText = data.inputText;
        highScoreNameText = data.highScoreNameText;
        score = data.score;
    }
}
