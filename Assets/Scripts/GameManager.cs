using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    { 
        get { return instance; }
    }

    private string playerName;
    private string highScorePlayerName;
    private int highScore;

    private string savePath;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            savePath = Application.persistentDataPath + "/gamedata.json";
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public string GetHighScorePlayerName()
    {
        return highScorePlayerName;
    }

    public int GetHighScore()
    {
        return highScore;
    }



    [System.Serializable]
    class GameData
    { 
        public string highSocrePlayerName;
        public int highScore;
    }

    //  save game data
    public void SaveGameData(int score)
    {
        if(score > highScore)
        {
            highScorePlayerName = playerName;
            highScore = score;

            GameData data = new GameData();
            data.highSocrePlayerName = highScorePlayerName;
            data.highScore = highScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(savePath, json);
        }
    }

    //  load game data
    public void LoadGameData()
    {
        if(File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            highScorePlayerName = data.highSocrePlayerName;
            highScore = data.highScore;
        }
        else
        {
            highScorePlayerName = string.Empty;
            highScore = 0;
        }
    }
}
