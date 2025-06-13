using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    private int highScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        highScore = PlayerPrefs.GetInt("HighScore");

    }



    public void UpdateScore(int points)
    {
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
