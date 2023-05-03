using UnityEngine;
using System.IO;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance;

    public string currentName;
    public string bestScoreName;

    public int bestScore;

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
        public int score;

        public string theName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.score = bestScore;

        data.theName = currentName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.score;

            bestScoreName = data.theName;
        }
    }
}
