using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LoadGameRankScript : MonoBehaviour
{
    public Text BestPlayerName;

    //static variables for holding best player data
    private static int BestScore;
    private static string BestPlayer;

    private void Awake()
    {
        LoadGameRank();
    }

    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = "";
        }
        else
        {
            BestPlayerName.text = $"Best Score - {BestPlayer}: {BestScore}";
        }
    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighestScore;
            SetBestPlayer();
        }
    }
    class SaveData
    {
        public int HighestScore;
        public string TheBestPlayer;
    }
}
