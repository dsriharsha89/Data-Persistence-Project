using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        setBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setBestScoreText()
    {
        if (HighScoreManager.Instance.highScorerName.Length != 0)
        {
            bestScoreText.text = "Best Score: " +
                HighScoreManager.Instance.highScorerName + " : " +
                HighScoreManager.Instance.highScore;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(string name)
    {
        HighScoreManager.Instance.playerName = name;
    }
}
