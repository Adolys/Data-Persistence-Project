using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInputText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadGameData();
        SetBestScore();
    }

    private void SetBestScore()
    {
        string playerName = GameManager.Instance.GetHighScorePlayerName();
        int highScore = GameManager.Instance.GetHighScore();

        if(highScore > 0)
        {
            string bestScoreStr = "Best Score : " + playerName + " : " + highScore;
            bestScoreText.SetText(bestScoreStr);
        }
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayerNameValueChanged()
    {
        GameManager.Instance.SetPlayerName(nameInputText.text);
    }

    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
