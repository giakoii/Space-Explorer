using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        UpdateScore();
    }

    public void UpdateScore()
    {
        int highestScore = GameManager.highestScore;
        int playerScore = GameManager.playerScore;

        scoreText.text = "Highest Score: " + highestScore.ToString() + "\nYour Score: " + playerScore.ToString();
    }
}
