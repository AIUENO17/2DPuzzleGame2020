using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPresenter : MonoBehaviour
{
    public TextMeshProUGUI m_ScoreText = null;

    public TextMeshProUGUI m_HighScoreText = null;
    // Start is called before the first frame update
    void Start()
    {
        var Score = PlayerPrefs.GetInt("Score");

        var highScore = PlayerPrefs.GetInt("HighScore");


        m_ScoreText.text = $"{Score}";

        m_HighScoreText.text = $"{highScore}";
    }

    // Update is called once per frame
    public void GotoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
