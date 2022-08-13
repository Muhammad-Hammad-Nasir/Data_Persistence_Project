using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject highScore;
    public Text highScoreText;

    private void Start()
    {
        string path = Application.persistentDataPath + "/scorefile.json";

        if (File.Exists(path))
        {
            MenuManager.Instance.LoadScore();
        }

        if (MenuManager.Instance.score > 0)
        {
            highScore.SetActive(true);
        }

        if (MenuManager.Instance != null)
        {
            highScoreText.text = MenuManager.Instance.highScoreNameText + " has the best score: " + MenuManager.Instance.score;
        }
    }

    public void StartGame()
    {
        if (inputField.text != "")
        {
            MenuManager.Instance.inputText = inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
