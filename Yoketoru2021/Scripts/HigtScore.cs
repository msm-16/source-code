using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using NCMB;

public class HigtScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI highScoreText = default;

    static int highScore;

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HIGH SCORE : {highScore:00000}";
    }

    public static void CheckHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        UpdateHighScoreText();
    }
}
