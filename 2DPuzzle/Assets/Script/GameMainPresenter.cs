using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainPresenter : MonoBehaviour
{
    public ScoreViewer m_scoreViewer = null;

    public LimitTimeCountViewer m_limitTimeCountViewer = null;

    private void Update()
    {

        if (m_limitTimeCountViewer.m_limitTime <= 0)
        {
            GotoResult();

        }
    }
    private void GotoResult()
    {
        PlayerPrefs.SetInt("Score",m_scoreViewer.Score );
        PlayerPrefs.Save();

        SceneManager.LoadScene("Result");


    }
}