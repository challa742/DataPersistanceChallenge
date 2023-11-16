using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif


public class SceneManagerSingleton : MonoBehaviour
{
    // Start is called before the first frame update

    public string currentPlayerName;

    public string highScorePlayerName;
    public int highScore;

    public static SceneManagerSingleton Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class PlayerData
    {
        public string name;

        public int score;

    }

    public void SavePlayerData()
    {

        var data = new PlayerData();

        data.name = highScorePlayerName;

        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savePlayerData.json", json);


        
    }

    public void LoadPlayerData()
    {

        string path = Application.persistentDataPath + "/savePlayerData.json";


        if (File.Exists(path))
        {

            string json = File.ReadAllText(path);

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            highScorePlayerName = playerData.name;
            highScore = playerData.score;

        }


    }



}
