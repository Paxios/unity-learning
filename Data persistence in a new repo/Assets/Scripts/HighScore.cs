using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class HighScore
{
    public int score;
    public string name;

    public HighScore()
    {
        LoadHighScore();

    }
    int LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);
            score = data.score;
            name = data.name;
            return score;
        }
        else return 0;
    }

    public void SaveHighScore(int score, string name)
    {
        HighScore hs = new HighScore();
        hs.score = score;
        hs.name = name;
        string json = JsonUtility.ToJson(hs);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }
}
