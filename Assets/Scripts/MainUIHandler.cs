using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI playerInfo;
    public TextMeshProUGUI playerNameInputField;

    private void Start()
    {
        playerInfo.text = "Best Score : " + SceneManagerSingleton.Instance.highScorePlayerName + " : " + SceneManagerSingleton.Instance.highScore;
    }
    public void StartGame()
    {
        SceneManagerSingleton.Instance.currentPlayerName = playerNameInputField.text;

        SceneManager.LoadScene("main");
      
    }

    public void ExitGame()
    {


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif

    }
   
}
