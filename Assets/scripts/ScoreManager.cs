using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;

    private int score;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        HighScoreManager.Instance.UpdateScore(score);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score:" + score;
        highScoreText.text = "HighScore:" + HighScoreManager.Instance.GetHighScore();
    }


}

