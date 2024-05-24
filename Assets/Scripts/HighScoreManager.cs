using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public string highScorerName;
    public string playerName;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class HighScoreData
    {
        public string name;
        public int score;
    }

    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.name = highScorerName;
        data.score = highScore;

        string dataJson = JsonUtility.ToJson(data);
        File.WriteAllText(
            Application.persistentDataPath + "/highScoreData.json", dataJson);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highScoreData.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            HighScoreData data = JsonUtility.FromJson<HighScoreData>(jsonData);
            highScorerName = data.name;
            highScore = data.score;
        }
    }
}
